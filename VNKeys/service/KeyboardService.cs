using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNKeys.service
{
    internal class KeyboardService
    {
        //private const int KEYEVENTF_KEYUP = 0x02;
        private const byte VK_LEFT = 0x25;
        private const byte VK_BACK = 0x08;
        private const byte VK_CONTROL = 0x11;
        private const byte VK_V = 0x56;
        private const byte VK_RIGHT = 0x27;
        const int INPUT_MOUSE = 0;
        const int INPUT_KEYBOARD = 1;
        const int INPUT_HARDWARE = 2;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;
        const uint KEYEVENTF_UNICODE = 0x0004;
        const uint KEYEVENTF_SCANCODE = 0x0008;
        const uint XBUTTON1 = 0x0001;
        const uint XBUTTON2 = 0x0002;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_VIRTUALDESK = 0x4000;
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public void sendKey(Keys key)
        {
            keybd_event((byte)key, 0x45, 0, 0);
            keybd_event((byte)key, 0x45, KEYEVENTF_KEYUP, 0);
        }

        public void sendKeyDown(Keys key)
        {
            keybd_event((byte)key, 0x45, 0, 0);
        }

        public void sendKeyUp(Keys key)
        {
            keybd_event((byte)key, 0x45, KEYEVENTF_KEYUP, 0);
        }


        public char getCharFromKeyValue(int vkCode)
        {
            byte[] keyboardState = new byte[256];
            GetKeyboardState(keyboardState);

            uint scanCode = MapVirtualKey((uint)vkCode, 0);
            StringBuilder sb = new StringBuilder(2);

            int result = ToUnicode((uint)vkCode, scanCode, keyboardState, sb, sb.Capacity, 0);
            if (result > 0)
            {
                return sb[0];
            }

            return (char)0; // Return null character if conversion failed
        }

        public void sendStringToCurrentCursor(string s)
        {
            try
            {
                // Construct a list of inputs to send through a single SendInput call.
                var inputs = new List<INPUT>();

                // Loop through each Unicode character in the string.
                foreach (char c in s)
                {
                    // Create key down and key up events for the character.
                    foreach (bool keyUp in new[] { false, true })
                    {
                        var input = new INPUT
                        {
                            type = INPUT_KEYBOARD,
                            u = new InputUnion
                            {
                                ki = new KEYBDINPUT
                                {
                                    wVk = 0, // Virtual-key code must be 0 for Unicode.
                                    wScan = c, // The Unicode character to send.
                                    dwFlags = KEYEVENTF_UNICODE | (keyUp ? KEYEVENTF_KEYUP : 0),
                                    dwExtraInfo = GetMessageExtraInfo()
                                }
                            }
                        };

                        inputs.Add(input);
                    }
                }

                // Check if inputs are not empty.
                if (inputs.Count > 0)
                {
                    // Send all inputs together.
                    uint inputsSent = SendInput((uint)inputs.Count, inputs.ToArray(), Marshal.SizeOf(typeof(INPUT)));

                    if (inputsSent == 0)
                    {
                        // If SendInput fails, use GetLastError to diagnose the issue.
                        //int error = Marshal.GetLastWin32Error();
                        //throw new InvalidOperationException($"SendInput failed with error code {error}.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging.
                // Console.WriteLine($"Error sending string to current cursor: {ex.Message}");
            }
        }


        struct INPUT
        {
            public int type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            /*Virtual Key code.  Must be from 1-254.  If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0.*/
            public ushort wVk;
            /*A hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application.*/
            public ushort wScan;
            /*Specifies various aspects of a keystroke.  See the KEYEVENTF_ constants for more information.*/
            public uint dwFlags;
            /*The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.*/
            public uint time;
            /*An additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this information.*/
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);


        [DllImport("user32.dll")]
        private static extern int ToUnicode(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags);

        [DllImport("user32.dll")]
        private static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint MapVirtualKey(uint uCode, int uMapType);

    }
}

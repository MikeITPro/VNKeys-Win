using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

public class GlobalKeyboardListener
{
    public event EventHandler<KeyPressedEventArgs> KeyPressed;

    private readonly HashSet<Keys> _keysToCapture;

    private IntPtr _hookId = IntPtr.Zero;
    private LowLevelKeyboardProc _proc;

    public GlobalKeyboardListener(IEnumerable<Keys> keysToCapture = null)
    {
        _keysToCapture = keysToCapture != null ? new HashSet<Keys>(keysToCapture) : null;
        _proc = HookCallback;
    }

    public void Start()
    {
        if (_hookId == IntPtr.Zero)
        {
            _hookId = SetHook(_proc);
        }
    }

    public void Stop()
    {
        if (_hookId != IntPtr.Zero)
        {
            UnhookWindowsHookEx(_hookId);
            _hookId = IntPtr.Zero;
        }
    }

    private IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (var currentProcess = Process.GetCurrentProcess())
        using (var currentModule = currentProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(currentModule.ModuleName), 0);
        }
    }

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
        {
            int vkCode = Marshal.ReadInt32(lParam);
            Keys key = (Keys)vkCode;

            if (_keysToCapture == null || _keysToCapture.Contains(key))
            {
                string character = GetCharacterFromKey(vkCode);

                var args = new KeyPressedEventArgs(key, character);
                KeyPressed?.Invoke(this, args);

                if (args.Handled)
                {
                    return (IntPtr)1; // Block the keypress
                }
            }
        }

        return CallNextHookEx(_hookId, nCode, wParam, lParam);
    }

    private string GetCharacterFromKey(int vkCode)
    {
        // Get the current keyboard state
        byte[] keyboardState = new byte[256];
        if (!GetKeyboardState(keyboardState))
        {
            return null;
        }

        // Check if Shift is pressed and update keyboard state
        bool shiftPressed = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
        if (shiftPressed)
        {
            keyboardState[(int)Keys.ShiftKey] = 0x80; // Set Shift key as pressed
        }
        else
        {
            keyboardState[(int)Keys.ShiftKey] = 0; // Ensure Shift is not considered
        }

        // Ignore CapsLock if Shift is pressed (standard behavior)
        if (Control.IsKeyLocked(Keys.CapsLock) && !shiftPressed)
        {
            keyboardState[(int)Keys.Capital] = 0x01; // Set CapsLock state
        }
        else
        {
            keyboardState[(int)Keys.Capital] = 0; // Disable CapsLock effect
        }

        // Translate the virtual key to a scan code
        uint scanCode = MapVirtualKey((uint)vkCode, MAPVK_VK_TO_VSC);
        if (scanCode == 0)
        {
            return null; // Mapping failed
        }

        // Translate the virtual key code and keyboard state to a character
        StringBuilder buffer = new StringBuilder(2);
        int result = ToUnicode((uint)vkCode, scanCode, keyboardState, buffer, buffer.Capacity, 0);
        if (result > 0)
        {
            return buffer.ToString();
        }

        return null;
    }

    ~GlobalKeyboardListener()
    {
        Stop();
    }

    #region Windows API Definitions

    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const int WM_SYSKEYDOWN = 0x0104;
    private const int MAPVK_VK_TO_VSC = 0;

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
    private static extern bool GetKeyboardState(byte[] keystate);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int ToUnicode(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out] StringBuilder pwszBuff, int cchBuff, uint wFlags);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern uint MapVirtualKey(uint uCode, uint uMapType);

    #endregion
}

public class KeyPressedEventArgs : EventArgs
{
    public Keys Key { get; }
    public string Character { get; }
    public bool Handled { get; set; }

    public KeyPressedEventArgs(Keys key, string character)
    {
        Key = key;
        Character = character;
        Handled = false;
    }
}

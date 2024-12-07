using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VNKeys.service
{

    public static class WinService
    {
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("user32.dll")]
        private static extern uint AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        private const int SW_RESTORE = 9; // Restore a minimized window
        private const int SW_SHOW = 5;    // Show a hidden window
        private const int SW_SHOWNA = 8;  // Show the window without activating

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// Brings an existing application instance to the front, ensuring it is restored.
        /// </summary>
        public static bool BringExistingInstanceToFront(string titleStartsWith)
        {
            var result = false;
            IntPtr hWnd = FindWindowByTitleStartsWith(titleStartsWith);

            if (hWnd != IntPtr.Zero)
            {
                result = EnsureWindowIsRestoredAndForeground(hWnd);
            }

            return result;
        }

        /// <summary>
        /// Ensures the specified window is restored, visible, and brought to the foreground.
        /// </summary>
        private static bool EnsureWindowIsRestoredAndForeground(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero) return false;

            IntPtr foregroundWindow = GetForegroundWindow();
            uint foregroundThreadId = GetWindowThreadProcessId(foregroundWindow, out _);
            uint currentThreadId = GetCurrentThreadId();

            // If another application is in focus, attach input threads
            if (foregroundThreadId != currentThreadId)
            {
                AttachThreadInput(foregroundThreadId, currentThreadId, true);

                ShowWindow(hWnd, SW_RESTORE); // Restore the window
                SetForegroundWindow(hWnd);   // Bring it to the front

                AttachThreadInput(foregroundThreadId, currentThreadId, false);
            }
            else
            {
                // Directly restore and bring to the foreground
                ShowWindow(hWnd, SW_RESTORE);
                SetForegroundWindow(hWnd);
            }

            return true;
        }

        /// <summary>
        /// Finds a window handle by its title, matching windows that start with the specified prefix.
        /// </summary>
        private static IntPtr FindWindowByTitleStartsWith(string titleStartsWith)
        {
            IntPtr result = IntPtr.Zero;

            EnumWindows((hWnd, lParam) =>
            {
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder windowTitle = new StringBuilder(length + 1);
                GetWindowText(hWnd, windowTitle, windowTitle.Capacity);

                if (windowTitle.ToString().StartsWith(titleStartsWith, StringComparison.OrdinalIgnoreCase))
                {
                    result = hWnd;
                    return false; // Stop enumerating windows
                }

                return true; // Continue enumerating
            }, IntPtr.Zero);

            return result;
        }
    }


}

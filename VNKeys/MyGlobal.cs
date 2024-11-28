using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VNKeys.service;
using VNKeys.ui;

namespace VNKeys
{
    internal static class MyGlobal
    {        
        private static KeyboardService _keyboardService;
        private static FormMain _formMain;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(getFormMain());
        }

        public static FormMain getFormMain()
        {
            if (_formMain == null)
            {
                _formMain = new FormMain();
            }
            return _formMain;
        }

        public static KeyboardService getKeyboardService()
        {
            if (_keyboardService == null)
            {
                _keyboardService = new KeyboardService();
            }
            return _keyboardService;
        }

        public static void gotoUrl(string url)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentException("URL cannot be null or empty.", nameof(url));
                }

                // Ensure the URL has a valid scheme (http or https)
                if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                    !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    url = "http://" + url;
                }

                // Open the URL in the default web browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensures it uses the system shell to open the browser
                });
            }
            catch (Exception ex)
            {
                //  Console.WriteLine($"Failed to open URL: {ex.Message}");
            }
        }

        public static string getAppName()
        {

            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);

        }

        public static string getAppVersion()
        {

            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}

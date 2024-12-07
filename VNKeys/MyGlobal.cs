using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

        private static Mutex mutex;


        [STAThread]
        static void Main()
        {          
            bool isNewInstance;
            // Create a Mutex to check for a single instance
            mutex = new Mutex(true, getAppName(), out isNewInstance);

            if (!isNewInstance)
            {
                showInfo(MyGlobal.getAppName() + " đang chạy, nhớ kiểm tra ở taskbar hay system tray.");
                WinService.BringExistingInstanceToFront(getAppName());
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(getFormMain());
        }


        public static void showInfo(string message)
        {
            showMessage(message, "Info");
        }

        public static void showMessage(string message, string caption)
        {
            MessageBox.Show(message, caption);
        }


        public static string checkForLatestVersion()
        {
            return "";
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
        

        public static string getAppDataPath()
        {
            var dPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), getAppName());
            if (!Directory.Exists(dPath))
            {
                Directory.CreateDirectory(dPath);
            }
            return dPath;
        }

        public static string getAppSettingFilePath()
        {
            return getAppDataPath() + "\\setting.bin";
        }
       
    }
}

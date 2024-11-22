using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VNKeys.ui;

namespace VNKeys
{
    internal static class MyGlobal
    {
        public const string APPLICATION_NAME = "VNKeys v0.1.0";
        private static FormMain _formMain;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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
        
        
    }
}

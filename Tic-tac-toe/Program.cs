using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;//CultureInfo.GetCultureInfo(System.Configuration.ConfigurationManager.AppSettings["Language"]);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainWindow.GetInstance());
        }
    }
}

using System;
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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainWindow = MainWindow.GetInstance();
            Application.Run(mainWindow);
        }
    }
    public enum Values
    {
        Null,
        X,
        O
    }
}

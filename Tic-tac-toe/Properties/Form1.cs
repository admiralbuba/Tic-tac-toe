using System;
using System.Linq;
using System.Windows.Forms;
using Tic_tac_toe.Properties;

namespace Tic_tac_toe
{
    public partial class MainWindow : Form
    {
        private static MainWindow Instance;
        private MainWindow()
        {
            InitializeComponent();
        }
        public static MainWindow GetInstance() => Instance ??= new MainWindow();
        private void ButtonClick(object sender, EventArgs e)
        {
            TicTacToe.GetInstance().MakeTurn(sender);
        }
        public void DisableAllButtons()
        {
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
        }
        private void NewGameClick(object sender, EventArgs e)
        {
            TicTacToe.GetInstance().ResetGame();
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Text = String.Empty;
                button.Enabled = true;
            }
        }
        private void AboutClick(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
            //MessageBox.Show("This game is created by buba\rAll rights reserved 2020");
        }
    }
}

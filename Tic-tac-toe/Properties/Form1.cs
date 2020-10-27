using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_tac_toe.Properties;

namespace Tic_tac_toe
{
    public partial class MainWindow : Form
    {
        TicTacToe game { get; set; }
        private static MainWindow Instance;
        private MainWindow()
        {
            InitializeComponent();
            game = new TicTacToe();
        }
        public static MainWindow GetInstance() => Instance ?? new MainWindow();

        private void ButtonClick(object sender, EventArgs e)
        {
            game.ButtonClick(sender);
        }

        public void DisableAllButtons()
        {
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Enabled = false;
            } 
        }
        private void newGame_Clicked(object sender, EventArgs e)
        {
            game = new TicTacToe();
            foreach(Button button in Controls.OfType<Button>())
            {
                button.Text = String.Empty;
                button.Enabled = true;
            }
        }
    }
}

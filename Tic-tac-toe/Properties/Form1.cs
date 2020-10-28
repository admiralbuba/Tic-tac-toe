﻿using System;
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
        private static MainWindow Instance;
        private MainWindow()
        {
            InitializeComponent();
        }
        public static MainWindow GetInstance()
        {
            if (Instance == null)
                Instance = new MainWindow();
            return Instance;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            TicTacToe.GetInstance().ButtonClick(sender);
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
            TicTacToe.GetInstance().ResetGame();
            foreach(Button button in Controls.OfType<Button>())
            {
                button.Text = String.Empty;
                button.Enabled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tic_tac_toe.Properties;
using Tic_tac_toe.Savers;

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
        public Button GetButton(string name)
        {
            return Controls.OfType<Button>().Where(x => x.Name.ToString() == name).FirstOrDefault();
        }
        public List<Button> GetAllButtons()
        {
            return Controls.OfType<Button>().ToList();
        }
        public string GetButtonText(string name)
        {
            var buttonText = Controls.OfType<Button>().Where(x => x.Name.ToString() == name).Select(x => x.Text).FirstOrDefault();
            return buttonText;
        }
        public void SetButtonText(string name, string value)
        {
            var button = Controls.OfType<Button>().Where(x => x.Name == name).FirstOrDefault();
            button.Text = value;
            button.Enabled = String.IsNullOrEmpty(button.Text) ? true : false;
        }
        public void ChangeTurnLabel(MapValues value)
        {
            PlayerLable.Text = $"Turn now: PLayer {value}";
        }
        public void UpdateTurnLabel()
        {
            if(TicTacToe.GetInstance().Turn)
                PlayerLable.Text = $"Turn now: PLayer X";
            else
                PlayerLable.Text = $"Turn now: PLayer O";
        }
        public void UpdateWinnerLabel()
        {
            var xCount = TicTacToe.GetInstance().PlayerXWinCount;
            XCount.Text = $"X : {xCount}";
            var oCount = TicTacToe.GetInstance().PlayerOWinCount;
            OCount.Text = $"O : {oCount}";
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
        }
        private void SaveClick(object sender, EventArgs e)
        {
            SaverLoader.SaveData();
        }
        private void LoadClick(object sender, EventArgs e)
        {
            SaverLoader.GetData();
        }
        private void SettingsClick(object sender, EventArgs e)
        {
            Properties.Settings settings = new Properties.Settings();
            settings.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tic_tac_toe.Properties;
using Tic_tac_toe.Savers;

namespace Tic_tac_toe
{
    public partial class MainWindow : Form, ITicTacToe
    {
        private static MainWindow instance;
        private MainWindow()
        {
            InitializeComponent();
        }
        public static MainWindow Instance => instance ??= new MainWindow();
        private void ButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            TicTacToe.Instance.MakeTurn(button.Name, button.Text, MainWindow.Instance);
        }
        public void DisableAllButtons()
        {
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
        }
        public string GetButton(string name)
        {
            return Controls.OfType<Button>().Where(x => x.Name.ToString() == name).FirstOrDefault().Name;
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
        public void UpdateMainWindowsLabels()
        {
            UpdateTurnLabel();
            UpdateWinnerLabel();
        }
        public void ChangeTurnLabel(MapValues value)
        {
            PlayerLable.Text = $"Turn now: PLayer {value}";
        }
        public void UpdateTurnLabel()
        {
            if (TicTacToe.Instance.Turn)
                PlayerLable.Text = $"Turn now: PLayer X";
            else
                PlayerLable.Text = $"Turn now: PLayer O";
        }
        public void UpdateWinnerLabel()
        {
            var xCount = TicTacToe.Instance.PlayerXWinCount;
            XCount.Text = $"X : {xCount}";
            var oCount = TicTacToe.Instance.PlayerOWinCount;
            OCount.Text = $"O : {oCount}";
        }

        public DialogResult GetEndGameMessage(MapValues winner)
        {
            DialogResult result = MessageBox.Show($"Player {winner} win!\rDo you want to continue round?",
            "The End",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.None,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            return result;
        }
        public void ShowDrow()
        {
            MessageBox.Show("Draw!");
        }
        public void DisableButton(string name)
        {
            Controls.OfType<Button>().Where(x => x.Name.ToString() == name).FirstOrDefault().Enabled = false;
        }
        public void ChangeButtonText(string name, string value)
        {
            Controls.OfType<Button>().Where(x => x.Name.ToString() == name).FirstOrDefault().Text = value;
        }
        private void NewGameClick(object sender, EventArgs e)
        {
            TicTacToe.Instance.ResetGame();
            ReleaseButtons();
        }
        public void ReleaseButtons()
        {
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
            SaverLoader.GetData(MainWindow.instance);
        }
        private void SettingsClick(object sender, EventArgs e)
        {
            Properties.Settings settings = new Properties.Settings();
            settings.Show();
        }
    }
}

using System;
using System.Windows.Forms;
using Tic_tac_toe.Savers;

namespace Tic_tac_toe.Properties
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            CheckRadioButtonCheck();
        }
        private void DataBaseCheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                SaverLoader.setting = Tic_tac_toe.Settings.DataBase;
            }
        }
        private void JSONCheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                SaverLoader.setting = Tic_tac_toe.Settings.JSON;
            }
        }
        private void CheckRadioButtonCheck()
        {
            var state = SaverLoader.setting;
            if (state == Tic_tac_toe.Settings.DataBase)
                DataBaseRadioButton.Checked = true;
            if (state == Tic_tac_toe.Settings.JSON)
                JSONRadioButton.Checked = true;
        }
    }
}

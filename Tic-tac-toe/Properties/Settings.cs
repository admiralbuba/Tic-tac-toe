using System;
using System.Windows.Forms;
using Core.Savers;

namespace Core.Properties
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
                SaverLoader.setting = Core.Settings.DataBase;
            }
        }
        private void JSONCheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                SaverLoader.setting = Core.Settings.JSON;
            }
        }
        private void CheckRadioButtonCheck()
        {
            var state = SaverLoader.setting;
            if (state == Core.Settings.DataBase)
                DataBaseRadioButton.Checked = true;
            if (state == Core.Settings.JSON)
                JSONRadioButton.Checked = true;
        }
    }
}

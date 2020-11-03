using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tic_tac_toe.Savers;

namespace Tic_tac_toe.Properties
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void DataBaseCheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                Saver.setting = Tic_tac_toe.Settings.DataBase;
            }
        }

        private void JSONCheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                Saver.setting = Tic_tac_toe.Settings.JSON;
            }
        }
    }
}

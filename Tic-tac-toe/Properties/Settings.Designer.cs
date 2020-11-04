namespace Tic_tac_toe.Properties
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.JSONRadioButton = new System.Windows.Forms.RadioButton();
            this.DataBaseRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save data in";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.JSONRadioButton);
            this.panel1.Controls.Add(this.DataBaseRadioButton);
            this.panel1.Location = new System.Drawing.Point(59, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 71);
            this.panel1.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.JSONRadioButton.AutoSize = true;
            this.JSONRadioButton.Location = new System.Drawing.Point(14, 38);
            this.JSONRadioButton.Name = "radioButton2";
            this.JSONRadioButton.Size = new System.Drawing.Size(53, 19);
            this.JSONRadioButton.TabIndex = 1;
            this.JSONRadioButton.Text = "JSON";
            this.JSONRadioButton.UseVisualStyleBackColor = true;
            this.JSONRadioButton.CheckedChanged += new System.EventHandler(this.JSONCheckedChanged);
            // 
            // radioButton1
            // 
            this.DataBaseRadioButton.AutoSize = true;
            this.DataBaseRadioButton.Checked = true;
            this.DataBaseRadioButton.Location = new System.Drawing.Point(14, 13);
            this.DataBaseRadioButton.Name = "radioButton1";
            this.DataBaseRadioButton.Size = new System.Drawing.Size(73, 19);
            this.DataBaseRadioButton.TabIndex = 0;
            this.DataBaseRadioButton.TabStop = true;
            this.DataBaseRadioButton.Text = "DataBase";
            this.DataBaseRadioButton.UseVisualStyleBackColor = true;
            this.DataBaseRadioButton.CheckedChanged += new System.EventHandler(this.DataBaseCheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 159);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton JSONRadioButton;
        private System.Windows.Forms.RadioButton DataBaseRadioButton;
    }
}
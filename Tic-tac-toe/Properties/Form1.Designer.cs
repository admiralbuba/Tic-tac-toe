﻿using System.Windows.Forms;

namespace Tic_tac_toe
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.A00 = new System.Windows.Forms.Button();
            this.A01 = new System.Windows.Forms.Button();
            this.A02 = new System.Windows.Forms.Button();
            this.B10 = new System.Windows.Forms.Button();
            this.B11 = new System.Windows.Forms.Button();
            this.B12 = new System.Windows.Forms.Button();
            this.C20 = new System.Windows.Forms.Button();
            this.C21 = new System.Windows.Forms.Button();
            this.C22 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // A00
            // 
            this.A00.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.A00.Location = new System.Drawing.Point(11, 41);
            this.A00.Name = "A00";
            this.A00.Size = new System.Drawing.Size(55, 55);
            this.A00.TabIndex = 0;
            this.A00.UseVisualStyleBackColor = true;
            this.A00.Click += new System.EventHandler(this.ButtonClick);
            // 
            // A01
            // 
            this.A01.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.A01.Location = new System.Drawing.Point(82, 41);
            this.A01.Name = "A01";
            this.A01.Size = new System.Drawing.Size(55, 55);
            this.A01.TabIndex = 0;
            this.A01.TabStop = false;
            this.A01.UseVisualStyleBackColor = true;
            this.A01.Click += new System.EventHandler(this.ButtonClick);
            // 
            // A02
            // 
            this.A02.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.A02.Location = new System.Drawing.Point(152, 41);
            this.A02.Name = "A02";
            this.A02.Size = new System.Drawing.Size(55, 55);
            this.A02.TabIndex = 0;
            this.A02.UseVisualStyleBackColor = true;
            this.A02.Click += new System.EventHandler(this.ButtonClick);
            // 
            // B10
            // 
            this.B10.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.B10.Location = new System.Drawing.Point(11, 111);
            this.B10.Name = "B10";
            this.B10.Size = new System.Drawing.Size(55, 55);
            this.B10.TabIndex = 0;
            this.B10.UseVisualStyleBackColor = true;
            this.B10.Click += new System.EventHandler(this.ButtonClick);
            // 
            // B11
            // 
            this.B11.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.B11.Location = new System.Drawing.Point(82, 111);
            this.B11.Name = "B11";
            this.B11.Size = new System.Drawing.Size(55, 55);
            this.B11.TabIndex = 0;
            this.B11.UseVisualStyleBackColor = true;
            this.B11.Click += new System.EventHandler(this.ButtonClick);
            // 
            // B12
            // 
            this.B12.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.B12.Location = new System.Drawing.Point(152, 111);
            this.B12.Name = "B12";
            this.B12.Size = new System.Drawing.Size(55, 55);
            this.B12.TabIndex = 0;
            this.B12.UseVisualStyleBackColor = true;
            this.B12.Click += new System.EventHandler(this.ButtonClick);
            // 
            // C20
            // 
            this.C20.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.C20.Location = new System.Drawing.Point(11, 184);
            this.C20.Name = "C20";
            this.C20.Size = new System.Drawing.Size(55, 55);
            this.C20.TabIndex = 0;
            this.C20.UseVisualStyleBackColor = true;
            this.C20.Click += new System.EventHandler(this.ButtonClick);
            // 
            // C21
            // 
            this.C21.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.C21.Location = new System.Drawing.Point(82, 184);
            this.C21.Name = "C21";
            this.C21.Size = new System.Drawing.Size(55, 55);
            this.C21.TabIndex = 0;
            this.C21.UseVisualStyleBackColor = true;
            this.C21.Click += new System.EventHandler(this.ButtonClick);
            // 
            // C22
            // 
            this.C22.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.C22.Location = new System.Drawing.Point(152, 184);
            this.C22.Name = "C22";
            this.C22.Size = new System.Drawing.Size(55, 55);
            this.C22.TabIndex = 0;
            this.C22.UseVisualStyleBackColor = true;
            this.C22.Click += new System.EventHandler(this.ButtonClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(220, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "Menu";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "&New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGame_Clicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(220, 251);
            this.Controls.Add(this.C22);
            this.Controls.Add(this.C21);
            this.Controls.Add(this.C20);
            this.Controls.Add(this.B12);
            this.Controls.Add(this.B11);
            this.Controls.Add(this.B10);
            this.Controls.Add(this.A02);
            this.Controls.Add(this.A01);
            this.Controls.Add(this.A00);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic-tac-toe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button A00;
        private System.Windows.Forms.Button A01;
        private System.Windows.Forms.Button A02;
        private System.Windows.Forms.Button B10;
        private System.Windows.Forms.Button B11;
        private System.Windows.Forms.Button B12;
        private System.Windows.Forms.Button C20;
        private System.Windows.Forms.Button C21;
        private System.Windows.Forms.Button C22;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
    }
}


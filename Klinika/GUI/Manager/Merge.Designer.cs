﻿namespace Klinika.GUI.Manager
{
    partial class Merge
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
            this.roomComboBox = new System.Windows.Forms.ComboBox();
            this.pickButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roomComboBox
            // 
            this.roomComboBox.FormattingEnabled = true;
            this.roomComboBox.Location = new System.Drawing.Point(344, 152);
            this.roomComboBox.Name = "roomComboBox";
            this.roomComboBox.Size = new System.Drawing.Size(151, 28);
            this.roomComboBox.TabIndex = 0;
            // 
            // pickButton
            // 
            this.pickButton.Location = new System.Drawing.Point(344, 279);
            this.pickButton.Name = "pickButton";
            this.pickButton.Size = new System.Drawing.Size(94, 29);
            this.pickButton.TabIndex = 1;
            this.pickButton.Text = "Pick";
            this.pickButton.UseVisualStyleBackColor = true;
            this.pickButton.Click += new System.EventHandler(this.pickButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Room";
            // 
            // Merge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pickButton);
            this.Controls.Add(this.roomComboBox);
            this.Name = "Merge";
            this.Text = "Merge";
            this.Load += new System.EventHandler(this.Merge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox roomComboBox;
        private Button pickButton;
        private Label label1;
    }
}
﻿namespace Klinika.GUI.Patient
{
    partial class Questionnaire
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GradeLabel = new System.Windows.Forms.Label();
            this.GradeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SetGradeButton = new System.Windows.Forms.Button();
            this.NotificationsTable = new System.Windows.Forms.DataGridView();
            this.SendButton = new System.Windows.Forms.Button();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.CommentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GradeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // GradeLabel
            // 
            this.GradeLabel.AutoSize = true;
            this.GradeLabel.Location = new System.Drawing.Point(3, 345);
            this.GradeLabel.Name = "GradeLabel";
            this.GradeLabel.Size = new System.Drawing.Size(62, 15);
            this.GradeLabel.TabIndex = 2;
            this.GradeLabel.Text = "Set grade: ";
            // 
            // GradeNumericUpDown
            // 
            this.GradeNumericUpDown.Location = new System.Drawing.Point(71, 341);
            this.GradeNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.GradeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GradeNumericUpDown.Name = "GradeNumericUpDown";
            this.GradeNumericUpDown.Size = new System.Drawing.Size(33, 23);
            this.GradeNumericUpDown.TabIndex = 3;
            this.GradeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SetGradeButton
            // 
            this.SetGradeButton.Location = new System.Drawing.Point(124, 341);
            this.SetGradeButton.Name = "SetGradeButton";
            this.SetGradeButton.Size = new System.Drawing.Size(75, 23);
            this.SetGradeButton.TabIndex = 4;
            this.SetGradeButton.Text = "Set";
            this.SetGradeButton.UseVisualStyleBackColor = true;
            // 
            // NotificationsTable
            // 
            this.NotificationsTable.AllowUserToAddRows = false;
            this.NotificationsTable.AllowUserToDeleteRows = false;
            this.NotificationsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NotificationsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.NotificationsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.NotificationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NotificationsTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.NotificationsTable.Location = new System.Drawing.Point(3, 5);
            this.NotificationsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NotificationsTable.Name = "NotificationsTable";
            this.NotificationsTable.ReadOnly = true;
            this.NotificationsTable.RowHeadersWidth = 51;
            this.NotificationsTable.RowTemplate.Height = 29;
            this.NotificationsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NotificationsTable.Size = new System.Drawing.Size(763, 319);
            this.NotificationsTable.TabIndex = 5;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(691, 341);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 6;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(420, 329);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(265, 43);
            this.CommentTextBox.TabIndex = 7;
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Location = new System.Drawing.Point(347, 343);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(67, 15);
            this.CommentLabel.TabIndex = 8;
            this.CommentLabel.Text = "Comment: ";
            // 
            // Questionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 379);
            this.Controls.Add(this.CommentLabel);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.NotificationsTable);
            this.Controls.Add(this.SetGradeButton);
            this.Controls.Add(this.GradeNumericUpDown);
            this.Controls.Add(this.GradeLabel);
            this.Name = "Questionnaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.GradeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label GradeLabel;
        private NumericUpDown GradeNumericUpDown;
        private Button SetGradeButton;
        private DataGridView NotificationsTable;
        private Button SendButton;
        internal TextBox CommentTextBox;
        private Label CommentLabel;
    }
}
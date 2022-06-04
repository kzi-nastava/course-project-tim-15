using Klinika.Forms;

namespace Klinika.GUI.Patient
{
    partial class Notifications
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NotificationsTable = new Klinika.Forms.NotificationsDataGridView();
            this.MarkAsReadButton = new System.Windows.Forms.Button();
            this.SetButton = new System.Windows.Forms.Button();
            this.OffsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SetOffsetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NotificationsTable
            // 
            this.NotificationsTable.AllowUserToAddRows = false;
            this.NotificationsTable.AllowUserToDeleteRows = false;
            this.NotificationsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NotificationsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.NotificationsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.NotificationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NotificationsTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.NotificationsTable.Location = new System.Drawing.Point(12, 12);
            this.NotificationsTable.Name = "NotificationsTable";
            this.NotificationsTable.ReadOnly = true;
            this.NotificationsTable.RowHeadersWidth = 51;
            this.NotificationsTable.RowTemplate.Height = 29;
            this.NotificationsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NotificationsTable.Size = new System.Drawing.Size(890, 529);
            this.NotificationsTable.TabIndex = 2;
            this.NotificationsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NotificationsTableCellClick);
            // 
            // MarkAsReadButton
            // 
            this.MarkAsReadButton.Location = new System.Drawing.Point(779, 560);
            this.MarkAsReadButton.Name = "MarkAsReadButton";
            this.MarkAsReadButton.Size = new System.Drawing.Size(123, 29);
            this.MarkAsReadButton.TabIndex = 9;
            this.MarkAsReadButton.Text = "Mark as read";
            this.MarkAsReadButton.UseVisualStyleBackColor = true;
            this.MarkAsReadButton.Click += new System.EventHandler(this.MarkAsReadButtonClick);
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(338, 560);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(94, 29);
            this.SetButton.TabIndex = 8;
            this.SetButton.Text = "Set";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButtonClick);
            // 
            // OffsetNumericUpDown
            // 
            this.OffsetNumericUpDown.Location = new System.Drawing.Point(171, 561);
            this.OffsetNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.OffsetNumericUpDown.Name = "OffsetNumericUpDown";
            this.OffsetNumericUpDown.Size = new System.Drawing.Size(150, 27);
            this.OffsetNumericUpDown.TabIndex = 7;
            this.OffsetNumericUpDown.ValueChanged += new System.EventHandler(this.OffsetNumericUpDownValueChanged);
            // 
            // SetOffsetLabel
            // 
            this.SetOffsetLabel.AutoSize = true;
            this.SetOffsetLabel.Location = new System.Drawing.Point(16, 564);
            this.SetOffsetLabel.Name = "SetOffsetLabel";
            this.SetOffsetLabel.Size = new System.Drawing.Size(149, 20);
            this.SetOffsetLabel.TabIndex = 6;
            this.SetOffsetLabel.Text = "Set new offset [min]: ";
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.MarkAsReadButton);
            this.Controls.Add(this.SetButton);
            this.Controls.Add(this.OffsetNumericUpDown);
            this.Controls.Add(this.SetOffsetLabel);
            this.Controls.Add(this.NotificationsTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notifications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.NotificationsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotificationsDataGridView NotificationsTable;
        private Button MarkAsReadButton;
        private Button SetButton;
        private NumericUpDown OffsetNumericUpDown;
        private Label SetOffsetLabel;
    }
}
namespace Klinika.GUI.Doctor
{
    partial class VacationRequests
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
            this.EmergencyCheckBox = new System.Windows.Forms.CheckBox();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SendRequestButton = new System.Windows.Forms.Button();
            this.ReasonTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VacationRequestTable = new Klinika.Forms.VacationRequestsDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.VacationRequestTable)).BeginInit();
            this.SuspendLayout();
            // 
            // EmergencyCheckBox
            // 
            this.EmergencyCheckBox.AutoSize = true;
            this.EmergencyCheckBox.Location = new System.Drawing.Point(12, 393);
            this.EmergencyCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EmergencyCheckBox.Name = "EmergencyCheckBox";
            this.EmergencyCheckBox.Size = new System.Drawing.Size(85, 19);
            this.EmergencyCheckBox.TabIndex = 20;
            this.EmergencyCheckBox.Text = "Emergency";
            this.EmergencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDatePicker.Location = new System.Drawing.Point(67, 38);
            this.ToDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(176, 23);
            this.ToDatePicker.TabIndex = 19;
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDatePicker.Location = new System.Drawing.Point(67, 11);
            this.FromDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(176, 23);
            this.FromDatePicker.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "From";
            // 
            // SendRequestButton
            // 
            this.SendRequestButton.Location = new System.Drawing.Point(12, 416);
            this.SendRequestButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendRequestButton.Name = "SendRequestButton";
            this.SendRequestButton.Size = new System.Drawing.Size(107, 22);
            this.SendRequestButton.TabIndex = 15;
            this.SendRequestButton.Text = "Send Request";
            this.SendRequestButton.UseVisualStyleBackColor = true;
            this.SendRequestButton.Click += new System.EventHandler(this.SendRequestButtonClick);
            // 
            // ReasonTextBox
            // 
            this.ReasonTextBox.Location = new System.Drawing.Point(12, 84);
            this.ReasonTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReasonTextBox.Multiline = true;
            this.ReasonTextBox.Name = "ReasonTextBox";
            this.ReasonTextBox.Size = new System.Drawing.Size(231, 84);
            this.ReasonTextBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Reason";
            // 
            // VacationRequestTable
            // 
            this.VacationRequestTable.AllowUserToAddRows = false;
            this.VacationRequestTable.AllowUserToDeleteRows = false;
            this.VacationRequestTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VacationRequestTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.VacationRequestTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.VacationRequestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VacationRequestTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.VacationRequestTable.GridColor = System.Drawing.SystemColors.Control;
            this.VacationRequestTable.Location = new System.Drawing.Point(249, 11);
            this.VacationRequestTable.Name = "VacationRequestTable";
            this.VacationRequestTable.ReadOnly = true;
            this.VacationRequestTable.RowHeadersWidth = 51;
            this.VacationRequestTable.RowTemplate.Height = 25;
            this.VacationRequestTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VacationRequestTable.Size = new System.Drawing.Size(539, 427);
            this.VacationRequestTable.TabIndex = 12;
            // 
            // VacationRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EmergencyCheckBox);
            this.Controls.Add(this.ToDatePicker);
            this.Controls.Add(this.FromDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SendRequestButton);
            this.Controls.Add(this.ReasonTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VacationRequestTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VacationRequests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vacation Requests";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.VacationRequestTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox EmergencyCheckBox;
        internal DateTimePicker ToDatePicker;
        internal DateTimePicker FromDatePicker;
        private Label label3;
        private Label label2;
        private Button SendRequestButton;
        private TextBox ReasonTextBox;
        private Label label4;
        internal Forms.VacationRequestsDataGridView VacationRequestTable;
    }
}
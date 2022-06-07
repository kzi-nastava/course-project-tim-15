namespace Klinika.GUI.Doctor
{
    partial class ViewSchedule
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
            this.PerformButton = new System.Windows.Forms.Button();
            this.ViewMedicalRecordButton = new System.Windows.Forms.Button();
            this.ScheduleDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ScheduleTable = new Klinika.Forms.AppointmentsTable();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleTable)).BeginInit();
            this.SuspendLayout();
            // 
            // PerformButton
            // 
            this.PerformButton.Location = new System.Drawing.Point(564, 417);
            this.PerformButton.Name = "PerformButton";
            this.PerformButton.Size = new System.Drawing.Size(75, 23);
            this.PerformButton.TabIndex = 7;
            this.PerformButton.Text = "Perform";
            this.PerformButton.UseVisualStyleBackColor = true;
            this.PerformButton.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // ViewMedicalRecordButton
            // 
            this.ViewMedicalRecordButton.Location = new System.Drawing.Point(645, 417);
            this.ViewMedicalRecordButton.Name = "ViewMedicalRecordButton";
            this.ViewMedicalRecordButton.Size = new System.Drawing.Size(143, 23);
            this.ViewMedicalRecordButton.TabIndex = 6;
            this.ViewMedicalRecordButton.Text = "View Patient Medical Record";
            this.ViewMedicalRecordButton.UseVisualStyleBackColor = true;
            this.ViewMedicalRecordButton.Click += new System.EventHandler(this.ViewMedicalRecordButtonClick);
            // 
            // ScheduleDatePicker
            // 
            this.ScheduleDatePicker.Location = new System.Drawing.Point(12, 417);
            this.ScheduleDatePicker.Name = "ScheduleDatePicker";
            this.ScheduleDatePicker.Size = new System.Drawing.Size(222, 23);
            this.ScheduleDatePicker.TabIndex = 5;
            this.ScheduleDatePicker.ValueChanged += new System.EventHandler(this.ScheduleDatePickerValueChanged);
            // 
            // ScheduleTable
            // 
            this.ScheduleTable.Location = new System.Drawing.Point(12, 11);
            this.ScheduleTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScheduleTable.Name = "ScheduleTable";
            this.ScheduleTable.Size = new System.Drawing.Size(776, 399);
            this.ScheduleTable.TabIndex = 4;
            this.ScheduleTable.SelectionChanged += new System.EventHandler(this.ScheduleTableSelectionChanged);
            // 
            // ViewSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PerformButton);
            this.Controls.Add(this.ViewMedicalRecordButton);
            this.Controls.Add(this.ScheduleDatePicker);
            this.Controls.Add(this.ScheduleTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Schedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button PerformButton;
        private Button ViewMedicalRecordButton;
        private DateTimePicker ScheduleDatePicker;
        public Forms.AppointmentsTable ScheduleTable;
    }
}
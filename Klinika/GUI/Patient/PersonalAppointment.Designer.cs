namespace Klinika.GUI.Patient
{
    partial class PersonalAppointment
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
            this.DateLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.ConfirmeButton = new System.Windows.Forms.Button();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(13, 30);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(48, 20);
            this.DateLabel.TabIndex = 0;
            this.DateLabel.Text = "Date: ";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(12, 77);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(49, 20);
            this.TimeLabel.TabIndex = 1;
            this.TimeLabel.Text = "Time: ";
            // 
            // DoctorLabel
            // 
            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Location = new System.Drawing.Point(12, 125);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(62, 20);
            this.DoctorLabel.TabIndex = 2;
            this.DoctorLabel.Text = "Doctor: ";
            // 
            // ConfirmeButton
            // 
            this.ConfirmeButton.Location = new System.Drawing.Point(82, 172);
            this.ConfirmeButton.Name = "ConfirmeButton";
            this.ConfirmeButton.Size = new System.Drawing.Size(94, 29);
            this.ConfirmeButton.TabIndex = 4;
            this.ConfirmeButton.Text = "Confirme";
            this.ConfirmeButton.UseVisualStyleBackColor = true;
            this.ConfirmeButton.Click += new System.EventHandler(this.ConfirmeButtonClick);
            // 
            // TimePicker
            // 
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePicker.Location = new System.Drawing.Point(82, 72);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.Size = new System.Drawing.Size(151, 27);
            this.TimePicker.TabIndex = 7;
            // 
            // DoctorComboBox
            // 
            this.DoctorComboBox.FormattingEnabled = true;
            this.DoctorComboBox.Location = new System.Drawing.Point(82, 122);
            this.DoctorComboBox.Name = "DoctorComboBox";
            this.DoctorComboBox.Size = new System.Drawing.Size(151, 28);
            this.DoctorComboBox.TabIndex = 8;
            // 
            // DatePicker
            // 
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePicker.Location = new System.Drawing.Point(82, 25);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(151, 27);
            this.DatePicker.TabIndex = 9;
            // 
            // PersonalAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 209);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.DoctorComboBox);
            this.Controls.Add(this.TimePicker);
            this.Controls.Add(this.ConfirmeButton);
            this.Controls.Add(this.DoctorLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.DateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonalAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label DateLabel;
        private Label TimeLabel;
        private Label DoctorLabel;
        private Button ConfirmeButton;
        private DateTimePicker TimePicker;
        private ComboBox DoctorComboBox;
        private DateTimePicker DatePicker;
    }
}
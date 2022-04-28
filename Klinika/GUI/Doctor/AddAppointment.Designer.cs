namespace Klinika.GUI.Doctor
{
    partial class AppointmentDetails
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
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PatientPicker = new System.Windows.Forms.ComboBox();
            this.ExaminationRadioButton = new System.Windows.Forms.RadioButton();
            this.OperationRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DurationTextBox = new System.Windows.Forms.TextBox();
            this.SaveAppointmentButton = new System.Windows.Forms.Button();
            this.IsUrgentCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimePicker
            // 
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePicker.Location = new System.Drawing.Point(75, 32);
            this.TimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.Size = new System.Drawing.Size(133, 23);
            this.TimePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time";
            // 
            // PatientPicker
            // 
            this.PatientPicker.DropDownHeight = 180;
            this.PatientPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PatientPicker.FormattingEnabled = true;
            this.PatientPicker.IntegralHeight = false;
            this.PatientPicker.Location = new System.Drawing.Point(74, 57);
            this.PatientPicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientPicker.Name = "PatientPicker";
            this.PatientPicker.Size = new System.Drawing.Size(133, 23);
            this.PatientPicker.TabIndex = 3;
            // 
            // ExaminationRadioButton
            // 
            this.ExaminationRadioButton.AutoSize = true;
            this.ExaminationRadioButton.Checked = true;
            this.ExaminationRadioButton.Location = new System.Drawing.Point(20, 23);
            this.ExaminationRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExaminationRadioButton.Name = "ExaminationRadioButton";
            this.ExaminationRadioButton.Size = new System.Drawing.Size(91, 19);
            this.ExaminationRadioButton.TabIndex = 4;
            this.ExaminationRadioButton.TabStop = true;
            this.ExaminationRadioButton.Text = "Examination";
            this.ExaminationRadioButton.UseVisualStyleBackColor = true;
            this.ExaminationRadioButton.CheckedChanged += new System.EventHandler(this.ExaminationRadioButtonCheckedChanged);
            // 
            // OperationRadioButton
            // 
            this.OperationRadioButton.AutoSize = true;
            this.OperationRadioButton.Location = new System.Drawing.Point(20, 46);
            this.OperationRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OperationRadioButton.Name = "OperationRadioButton";
            this.OperationRadioButton.Size = new System.Drawing.Size(78, 19);
            this.OperationRadioButton.TabIndex = 5;
            this.OperationRadioButton.Text = "Operation";
            this.OperationRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Patient";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duration";
            // 
            // DatePicker
            // 
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePicker.Location = new System.Drawing.Point(75, 8);
            this.DatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(133, 23);
            this.DatePicker.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExaminationRadioButton);
            this.groupBox1.Controls.Add(this.OperationRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(74, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(133, 78);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Location = new System.Drawing.Point(73, 191);
            this.DurationTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(134, 23);
            this.DurationTextBox.TabIndex = 10;
            // 
            // SaveAppointmentButton
            // 
            this.SaveAppointmentButton.Location = new System.Drawing.Point(126, 235);
            this.SaveAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveAppointmentButton.Name = "SaveAppointmentButton";
            this.SaveAppointmentButton.Size = new System.Drawing.Size(82, 22);
            this.SaveAppointmentButton.TabIndex = 11;
            this.SaveAppointmentButton.Text = "Create";
            this.SaveAppointmentButton.UseVisualStyleBackColor = true;
            this.SaveAppointmentButton.Click += new System.EventHandler(this.SaveAppointmentButtonClick);
            // 
            // IsUrgentCheckBox
            // 
            this.IsUrgentCheckBox.AutoSize = true;
            this.IsUrgentCheckBox.Location = new System.Drawing.Point(75, 167);
            this.IsUrgentCheckBox.Name = "IsUrgentCheckBox";
            this.IsUrgentCheckBox.Size = new System.Drawing.Size(62, 19);
            this.IsUrgentCheckBox.TabIndex = 12;
            this.IsUrgentCheckBox.Text = "Urgent";
            this.IsUrgentCheckBox.UseVisualStyleBackColor = true;
            // 
            // AppointmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 277);
            this.Controls.Add(this.IsUrgentCheckBox);
            this.Controls.Add(this.SaveAppointmentButton);
            this.Controls.Add(this.DurationTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PatientPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimePicker);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment Details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppointmentDetailsFormClosed);
            this.Load += new System.EventHandler(this.AddAppointmentLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker TimePicker;
        private Label label1;
        private Label label2;
        private ComboBox PatientPicker;
        private RadioButton ExaminationRadioButton;
        private RadioButton OperationRadioButton;
        private Label label3;
        private Label label4;
        private DateTimePicker DatePicker;
        private GroupBox groupBox1;
        private TextBox DurationTextBox;
        private Button SaveAppointmentButton;
        private CheckBox IsUrgentCheckBox;
    }
}
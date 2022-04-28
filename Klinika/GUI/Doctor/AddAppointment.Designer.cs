namespace Klinika.GUI.Doctor
{
    partial class AddAppointment
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PatientPicker = new System.Windows.Forms.ComboBox();
            this.ExaminationRadioButton = new System.Windows.Forms.RadioButton();
            this.OperationRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DurationTextBox = new System.Windows.Forms.TextBox();
            this.AddAppointmentButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(86, 43);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 27);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time";
            // 
            // PatientPicker
            // 
            this.PatientPicker.FormattingEnabled = true;
            this.PatientPicker.Location = new System.Drawing.Point(85, 76);
            this.PatientPicker.Name = "PatientPicker";
            this.PatientPicker.Size = new System.Drawing.Size(151, 28);
            this.PatientPicker.TabIndex = 3;
            // 
            // ExaminationRadioButton
            // 
            this.ExaminationRadioButton.AutoSize = true;
            this.ExaminationRadioButton.Checked = true;
            this.ExaminationRadioButton.Location = new System.Drawing.Point(23, 31);
            this.ExaminationRadioButton.Name = "ExaminationRadioButton";
            this.ExaminationRadioButton.Size = new System.Drawing.Size(112, 24);
            this.ExaminationRadioButton.TabIndex = 4;
            this.ExaminationRadioButton.TabStop = true;
            this.ExaminationRadioButton.Text = "Examination";
            this.ExaminationRadioButton.UseVisualStyleBackColor = true;
            this.ExaminationRadioButton.CheckedChanged += new System.EventHandler(this.ExaminationRadioButtonCheckedChanged);
            // 
            // OperationRadioButton
            // 
            this.OperationRadioButton.AutoSize = true;
            this.OperationRadioButton.Location = new System.Drawing.Point(23, 61);
            this.OperationRadioButton.Name = "OperationRadioButton";
            this.OperationRadioButton.Size = new System.Drawing.Size(97, 24);
            this.OperationRadioButton.TabIndex = 5;
            this.OperationRadioButton.Text = "Operation";
            this.OperationRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Patient";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duration";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(86, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(151, 27);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExaminationRadioButton);
            this.groupBox1.Controls.Add(this.OperationRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(85, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 104);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Location = new System.Drawing.Point(85, 220);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(152, 27);
            this.DurationTextBox.TabIndex = 10;
            // 
            // AddAppointmentButton
            // 
            this.AddAppointmentButton.Location = new System.Drawing.Point(143, 268);
            this.AddAppointmentButton.Name = "AddAppointmentButton";
            this.AddAppointmentButton.Size = new System.Drawing.Size(94, 29);
            this.AddAppointmentButton.TabIndex = 11;
            this.AddAppointmentButton.Text = "Create";
            this.AddAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 319);
            this.Controls.Add(this.AddAppointmentButton);
            this.Controls.Add(this.DurationTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PatientPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Appointment";
            this.Load += new System.EventHandler(this.AddAppointmentLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private ComboBox PatientPicker;
        private RadioButton ExaminationRadioButton;
        private RadioButton OperationRadioButton;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker2;
        private GroupBox groupBox1;
        private TextBox DurationTextBox;
        private Button AddAppointmentButton;
    }
}
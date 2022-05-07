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
            this.PatientComboBox = new System.Windows.Forms.ComboBox();
            this.ExaminationRadioButton = new System.Windows.Forms.RadioButton();
            this.OperationRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DurationTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.IsUrgentCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimePicker
            // 
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePicker.Location = new System.Drawing.Point(86, 43);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.Size = new System.Drawing.Size(151, 27);
            this.TimePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time";
            // 
            // PatientComboBox
            // 
            this.PatientComboBox.DropDownHeight = 180;
            this.PatientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PatientComboBox.FormattingEnabled = true;
            this.PatientComboBox.IntegralHeight = false;
            this.PatientComboBox.Location = new System.Drawing.Point(85, 76);
            this.PatientComboBox.Name = "PatientComboBox";
            this.PatientComboBox.Size = new System.Drawing.Size(151, 28);
            this.PatientComboBox.TabIndex = 3;
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
            this.label4.Location = new System.Drawing.Point(11, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duration";
            // 
            // DatePicker
            // 
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePicker.Location = new System.Drawing.Point(86, 11);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(151, 27);
            this.DatePicker.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExaminationRadioButton);
            this.groupBox1.Controls.Add(this.OperationRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(85, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 104);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Location = new System.Drawing.Point(83, 255);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(153, 27);
            this.DurationTextBox.TabIndex = 10;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(144, 313);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(94, 29);
            this.ConfirmButton.TabIndex = 11;
            this.ConfirmButton.Text = "Create";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // IsUrgentCheckBox
            // 
            this.IsUrgentCheckBox.AutoSize = true;
            this.IsUrgentCheckBox.Location = new System.Drawing.Point(86, 223);
            this.IsUrgentCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IsUrgentCheckBox.Name = "IsUrgentCheckBox";
            this.IsUrgentCheckBox.Size = new System.Drawing.Size(76, 24);
            this.IsUrgentCheckBox.TabIndex = 12;
            this.IsUrgentCheckBox.Text = "Urgent";
            this.IsUrgentCheckBox.UseVisualStyleBackColor = true;
            // 
            // AppointmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 369);
            this.Controls.Add(this.IsUrgentCheckBox);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.DurationTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PatientComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "t";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker TimePicker;
        private Label label1;
        private Label label2;
        private ComboBox PatientComboBox;
        private RadioButton ExaminationRadioButton;
        private RadioButton OperationRadioButton;
        private Label label3;
        private Label label4;
        private DateTimePicker DatePicker;
        private GroupBox groupBox1;
        private TextBox DurationTextBox;
        private Button ConfirmButton;
        private CheckBox IsUrgentCheckBox;
    }
}
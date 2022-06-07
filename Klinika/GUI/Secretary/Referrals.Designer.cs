namespace Klinika.GUI.Secretary
{
    partial class Referrals
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
            this.specializationField = new System.Windows.Forms.TextBox();
            this.doctorField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.findAvailableDoctorButton = new System.Windows.Forms.Button();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.appointmentPicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.patientSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // specializationField
            // 
            this.specializationField.Location = new System.Drawing.Point(542, 121);
            this.specializationField.Name = "specializationField";
            this.specializationField.ReadOnly = true;
            this.specializationField.Size = new System.Drawing.Size(246, 27);
            this.specializationField.TabIndex = 21;
            // 
            // doctorField
            // 
            this.doctorField.Location = new System.Drawing.Point(542, 39);
            this.doctorField.Name = "doctorField";
            this.doctorField.ReadOnly = true;
            this.doctorField.Size = new System.Drawing.Size(246, 27);
            this.doctorField.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Specialization:";
            // 
            // findAvailableDoctorButton
            // 
            this.findAvailableDoctorButton.Enabled = false;
            this.findAvailableDoctorButton.Location = new System.Drawing.Point(233, 205);
            this.findAvailableDoctorButton.Name = "findAvailableDoctorButton";
            this.findAvailableDoctorButton.Size = new System.Drawing.Size(208, 29);
            this.findAvailableDoctorButton.TabIndex = 19;
            this.findAvailableDoctorButton.Text = "Find available doctor";
            this.findAvailableDoctorButton.UseVisualStyleBackColor = true;
            this.findAvailableDoctorButton.Click += new System.EventHandler(this.FindAvailableDoctorButton_Click);
            // 
            // scheduleButton
            // 
            this.scheduleButton.Enabled = false;
            this.scheduleButton.Location = new System.Drawing.Point(479, 205);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(94, 29);
            this.scheduleButton.TabIndex = 18;
            this.scheduleButton.Text = "Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.ScheduleButton_Click);
            // 
            // appointmentPicker
            // 
            this.appointmentPicker.CustomFormat = "MM/dd/yyyy HH:mm";
            this.appointmentPicker.Enabled = false;
            this.appointmentPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.appointmentPicker.Location = new System.Drawing.Point(102, 123);
            this.appointmentPicker.Name = "appointmentPicker";
            this.appointmentPicker.Size = new System.Drawing.Size(250, 27);
            this.appointmentPicker.TabIndex = 17;
            this.appointmentPicker.Value = new System.DateTime(2022, 5, 12, 18, 34, 29, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Doctor:";
            // 
            // patientSelection
            // 
            this.patientSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.patientSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patientSelection.FormattingEnabled = true;
            this.patientSelection.Location = new System.Drawing.Point(105, 38);
            this.patientSelection.Name = "patientSelection";
            this.patientSelection.Size = new System.Drawing.Size(247, 28);
            this.patientSelection.TabIndex = 13;
            this.patientSelection.SelectedIndexChanged += new System.EventHandler(this.PatientSelection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Patient:";
            // 
            // Referrals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 269);
            this.Controls.Add(this.specializationField);
            this.Controls.Add(this.doctorField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.findAvailableDoctorButton);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.appointmentPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patientSelection);
            this.Controls.Add(this.label1);
            this.Name = "Referrals";
            this.Text = "Referrals";
            this.Load += new System.EventHandler(this.Referrals_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TextBox specializationField;
        public TextBox doctorField;
        private Label label4;
        public Button findAvailableDoctorButton;
        public Button scheduleButton;
        public DateTimePicker appointmentPicker;
        private Label label3;
        private Label label2;
        public ComboBox patientSelection;
        private Label label1;
    }
}
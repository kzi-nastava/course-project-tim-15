namespace Klinika.GUI.Patient
{
    partial class Main
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
            this.ViewScheduleButton = new System.Windows.Forms.Button();
            this.NewAppointmentButton = new System.Windows.Forms.Button();
            this.MedicalRecordButton = new System.Windows.Forms.Button();
            this.SearchDoctorsButton = new System.Windows.Forms.Button();
            this.NotificationsButton = new System.Windows.Forms.Button();
            this.QuestionnaireForClinicButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewScheduleButton
            // 
            this.ViewScheduleButton.Location = new System.Drawing.Point(14, 16);
            this.ViewScheduleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewScheduleButton.Name = "ViewScheduleButton";
            this.ViewScheduleButton.Size = new System.Drawing.Size(197, 31);
            this.ViewScheduleButton.TabIndex = 0;
            this.ViewScheduleButton.Text = "View Schedule";
            this.ViewScheduleButton.UseVisualStyleBackColor = true;
            this.ViewScheduleButton.Click += new System.EventHandler(this.ViewScheduleButtonClick);
            // 
            // NewAppointmentButton
            // 
            this.NewAppointmentButton.Location = new System.Drawing.Point(14, 55);
            this.NewAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewAppointmentButton.Name = "NewAppointmentButton";
            this.NewAppointmentButton.Size = new System.Drawing.Size(197, 31);
            this.NewAppointmentButton.TabIndex = 1;
            this.NewAppointmentButton.Text = "New Appointment";
            this.NewAppointmentButton.UseVisualStyleBackColor = true;
            this.NewAppointmentButton.Click += new System.EventHandler(this.NewAppointmentButtonClick);
            // 
            // MedicalRecordButton
            // 
            this.MedicalRecordButton.Location = new System.Drawing.Point(14, 93);
            this.MedicalRecordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MedicalRecordButton.Name = "MedicalRecordButton";
            this.MedicalRecordButton.Size = new System.Drawing.Size(197, 31);
            this.MedicalRecordButton.TabIndex = 2;
            this.MedicalRecordButton.Text = "Medical Record";
            this.MedicalRecordButton.UseVisualStyleBackColor = true;
            this.MedicalRecordButton.Click += new System.EventHandler(this.MedicalRecordButtonClick);
            // 
            // SearchDoctorsButton
            // 
            this.SearchDoctorsButton.Location = new System.Drawing.Point(14, 132);
            this.SearchDoctorsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchDoctorsButton.Name = "SearchDoctorsButton";
            this.SearchDoctorsButton.Size = new System.Drawing.Size(197, 31);
            this.SearchDoctorsButton.TabIndex = 3;
            this.SearchDoctorsButton.Text = "Search Doctors";
            this.SearchDoctorsButton.UseVisualStyleBackColor = true;
            this.SearchDoctorsButton.Click += new System.EventHandler(this.SearchDoctorsButtonClick);
            // 
            // NotificationsButton
            // 
            this.NotificationsButton.Location = new System.Drawing.Point(16, 171);
            this.NotificationsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NotificationsButton.Name = "NotificationsButton";
            this.NotificationsButton.Size = new System.Drawing.Size(195, 31);
            this.NotificationsButton.TabIndex = 4;
            this.NotificationsButton.Text = "Notifications";
            this.NotificationsButton.UseVisualStyleBackColor = true;
            this.NotificationsButton.Click += new System.EventHandler(this.NotificationsButtonClick);
            // 
            // QuestionnaireForClinicButton
            // 
            this.QuestionnaireForClinicButton.Location = new System.Drawing.Point(16, 209);
            this.QuestionnaireForClinicButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QuestionnaireForClinicButton.Name = "QuestionnaireForClinicButton";
            this.QuestionnaireForClinicButton.Size = new System.Drawing.Size(195, 31);
            this.QuestionnaireForClinicButton.TabIndex = 5;
            this.QuestionnaireForClinicButton.Text = "Questionnaire For Clinic";
            this.QuestionnaireForClinicButton.UseVisualStyleBackColor = true;
            this.QuestionnaireForClinicButton.Click += new System.EventHandler(this.QuestionnaireForClinicButtonClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 250);
            this.Controls.Add(this.QuestionnaireForClinicButton);
            this.Controls.Add(this.NotificationsButton);
            this.Controls.Add(this.SearchDoctorsButton);
            this.Controls.Add(this.MedicalRecordButton);
            this.Controls.Add(this.NewAppointmentButton);
            this.Controls.Add(this.ViewScheduleButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.ResumeLayout(false);

        }

        #endregion

        private Button ViewScheduleButton;
        private Button NewAppointmentButton;
        private Button MedicalRecordButton;
        private Button SearchDoctorsButton;
        private Button NotificationsButton;
        private Button QuestionnaireForClinicButton;
    }
}
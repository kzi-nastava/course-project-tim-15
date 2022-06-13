using Klinika.Users.Models;

namespace Klinika.GUI.Patient
{
    partial class NewAppointment
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.OccupiedAppointmentsTable = new Klinika.Forms.AppointmentsTable(User.RoleType.PATIENT);
            this.DateLabel = new System.Windows.Forms.Label();
            this.AppointmentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();
            this.FindAppointmentsButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.RecommendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OccupiedAppointmentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(335, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(137, 15);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Occupied Appointments";
            // 
            // OccupiedAppointmentsTable
            // 
            this.OccupiedAppointmentsTable.Location = new System.Drawing.Point(12, 26);
            this.OccupiedAppointmentsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OccupiedAppointmentsTable.Name = "OccupiedAppointmentsTable";
            this.OccupiedAppointmentsTable.Size = new System.Drawing.Size(776, 357);
            this.OccupiedAppointmentsTable.TabIndex = 4;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(12, 398);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(79, 15);
            this.DateLabel.TabIndex = 5;
            this.DateLabel.Text = "Select a date: ";
            // 
            // AppointmentDatePicker
            // 
            this.AppointmentDatePicker.Location = new System.Drawing.Point(109, 392);
            this.AppointmentDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AppointmentDatePicker.Name = "AppointmentDatePicker";
            this.AppointmentDatePicker.Size = new System.Drawing.Size(229, 23);
            this.AppointmentDatePicker.TabIndex = 6;
            // 
            // DoctorLabel
            // 
            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Location = new System.Drawing.Point(12, 428);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(91, 15);
            this.DoctorLabel.TabIndex = 7;
            this.DoctorLabel.Text = "Select a doctor: ";
            // 
            // DoctorComboBox
            // 
            this.DoctorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DoctorComboBox.FormattingEnabled = true;
            this.DoctorComboBox.Location = new System.Drawing.Point(109, 425);
            this.DoctorComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorComboBox.Name = "DoctorComboBox";
            this.DoctorComboBox.Size = new System.Drawing.Size(133, 23);
            this.DoctorComboBox.TabIndex = 8;
            // 
            // FindAppointmentsButton
            // 
            this.FindAppointmentsButton.Location = new System.Drawing.Point(256, 425);
            this.FindAppointmentsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FindAppointmentsButton.Name = "FindAppointmentsButton";
            this.FindAppointmentsButton.Size = new System.Drawing.Size(82, 22);
            this.FindAppointmentsButton.TabIndex = 9;
            this.FindAppointmentsButton.Text = "Find";
            this.FindAppointmentsButton.UseVisualStyleBackColor = true;
            this.FindAppointmentsButton.Click += new System.EventHandler(this.FindAppointmentsButtonClick);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(694, 393);
            this.ScheduleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(94, 22);
            this.ScheduleButton.TabIndex = 10;
            this.ScheduleButton.Text = "Schedule";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            this.ScheduleButton.Click += new System.EventHandler(this.ScheduleButtonClick);
            // 
            // RecommendButton
            // 
            this.RecommendButton.Location = new System.Drawing.Point(694, 421);
            this.RecommendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RecommendButton.Name = "RecommendButton";
            this.RecommendButton.Size = new System.Drawing.Size(94, 22);
            this.RecommendButton.TabIndex = 11;
            this.RecommendButton.Text = "Recommend";
            this.RecommendButton.UseVisualStyleBackColor = true;
            this.RecommendButton.Click += new System.EventHandler(this.RecommendButtonClick);
            // 
            // NewAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RecommendButton);
            this.Controls.Add(this.ScheduleButton);
            this.Controls.Add(this.FindAppointmentsButton);
            this.Controls.Add(this.DoctorComboBox);
            this.Controls.Add(this.DoctorLabel);
            this.Controls.Add(this.AppointmentDatePicker);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.OccupiedAppointmentsTable);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewAppointment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.OccupiedAppointmentsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TitleLabel;
        internal Forms.AppointmentsTable OccupiedAppointmentsTable;
        private Label DateLabel;
        internal DateTimePicker AppointmentDatePicker;
        private Label DoctorLabel;
        internal ComboBox DoctorComboBox;
        private Button FindAppointmentsButton;
        private Button ScheduleButton;
        private Button RecommendButton;
    }
}
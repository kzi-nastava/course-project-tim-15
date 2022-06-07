using Klinika.Forms;
namespace Klinika.GUI.Patient
{
    partial class AppointmentRecommendation
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
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();
            this.FromLabel = new System.Windows.Forms.Label();
            this.TimeGroupBox = new System.Windows.Forms.GroupBox();
            this.ToTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToLabel = new System.Windows.Forms.Label();
            this.LastDateLabel = new System.Windows.Forms.Label();
            this.DeadlineDatePicker = new System.Windows.Forms.DateTimePicker();
            this.PriorityGroupBox = new System.Windows.Forms.GroupBox();
            this.TimeRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorRadioButton = new System.Windows.Forms.RadioButton();
            this.RecommendedAppointmentTable = new Klinika.Forms.RecommendedAppointmentsTable();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.RecommendButton = new System.Windows.Forms.Button();
            this.TimeGroupBox.SuspendLayout();
            this.PriorityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecommendedAppointmentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DoctorLabel
            // 
            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Location = new System.Drawing.Point(24, 26);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(62, 20);
            this.DoctorLabel.TabIndex = 0;
            this.DoctorLabel.Text = "Doctor: ";
            // 
            // DoctorComboBox
            // 
            this.DoctorComboBox.FormattingEnabled = true;
            this.DoctorComboBox.Location = new System.Drawing.Point(92, 23);
            this.DoctorComboBox.Name = "DoctorComboBox";
            this.DoctorComboBox.Size = new System.Drawing.Size(151, 28);
            this.DoctorComboBox.TabIndex = 1;
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(12, 37);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(50, 20);
            this.FromLabel.TabIndex = 2;
            this.FromLabel.Text = "From: ";
            // 
            // TimeGroupBox
            // 
            this.TimeGroupBox.Controls.Add(this.ToTimePicker);
            this.TimeGroupBox.Controls.Add(this.FromTimePicker);
            this.TimeGroupBox.Controls.Add(this.ToLabel);
            this.TimeGroupBox.Controls.Add(this.FromLabel);
            this.TimeGroupBox.Location = new System.Drawing.Point(12, 69);
            this.TimeGroupBox.Name = "TimeGroupBox";
            this.TimeGroupBox.Size = new System.Drawing.Size(260, 125);
            this.TimeGroupBox.TabIndex = 3;
            this.TimeGroupBox.TabStop = false;
            this.TimeGroupBox.Text = "Time";
            // 
            // ToTimePicker
            // 
            this.ToTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ToTimePicker.Location = new System.Drawing.Point(99, 78);
            this.ToTimePicker.Name = "ToTimePicker";
            this.ToTimePicker.ShowUpDown = true;
            this.ToTimePicker.Size = new System.Drawing.Size(151, 27);
            this.ToTimePicker.TabIndex = 5;
            // 
            // FromTimePicker
            // 
            this.FromTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.FromTimePicker.Location = new System.Drawing.Point(99, 32);
            this.FromTimePicker.Name = "FromTimePicker";
            this.FromTimePicker.ShowUpDown = true;
            this.FromTimePicker.Size = new System.Drawing.Size(151, 27);
            this.FromTimePicker.TabIndex = 4;
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(15, 78);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(32, 20);
            this.ToLabel.TabIndex = 3;
            this.ToLabel.Text = "To: ";
            // 
            // LastDateLabel
            // 
            this.LastDateLabel.AutoSize = true;
            this.LastDateLabel.Location = new System.Drawing.Point(285, 26);
            this.LastDateLabel.Name = "LastDateLabel";
            this.LastDateLabel.Size = new System.Drawing.Size(76, 20);
            this.LastDateLabel.TabIndex = 4;
            this.LastDateLabel.Text = "Last date: ";
            // 
            // DeadlineDatePicker
            // 
            this.DeadlineDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DeadlineDatePicker.Location = new System.Drawing.Point(367, 23);
            this.DeadlineDatePicker.Name = "DeadlineDatePicker";
            this.DeadlineDatePicker.Size = new System.Drawing.Size(151, 27);
            this.DeadlineDatePicker.TabIndex = 5;
            // 
            // PriorityGroupBox
            // 
            this.PriorityGroupBox.Controls.Add(this.TimeRadioButton);
            this.PriorityGroupBox.Controls.Add(this.DoctorRadioButton);
            this.PriorityGroupBox.Location = new System.Drawing.Point(294, 69);
            this.PriorityGroupBox.Name = "PriorityGroupBox";
            this.PriorityGroupBox.Size = new System.Drawing.Size(233, 125);
            this.PriorityGroupBox.TabIndex = 6;
            this.PriorityGroupBox.TabStop = false;
            this.PriorityGroupBox.Text = "Priority";
            // 
            // TimeRadioButton
            // 
            this.TimeRadioButton.AutoSize = true;
            this.TimeRadioButton.Location = new System.Drawing.Point(35, 78);
            this.TimeRadioButton.Name = "TimeRadioButton";
            this.TimeRadioButton.Size = new System.Drawing.Size(63, 24);
            this.TimeRadioButton.TabIndex = 1;
            this.TimeRadioButton.TabStop = true;
            this.TimeRadioButton.Text = "Time";
            this.TimeRadioButton.UseVisualStyleBackColor = true;
            // 
            // DoctorRadioButton
            // 
            this.DoctorRadioButton.AutoSize = true;
            this.DoctorRadioButton.Location = new System.Drawing.Point(35, 35);
            this.DoctorRadioButton.Name = "DoctorRadioButton";
            this.DoctorRadioButton.Size = new System.Drawing.Size(76, 24);
            this.DoctorRadioButton.TabIndex = 0;
            this.DoctorRadioButton.TabStop = true;
            this.DoctorRadioButton.Text = "Doctor";
            this.DoctorRadioButton.UseVisualStyleBackColor = true;
            // 
            // RecommendedAppointmentTable
            // 
            this.RecommendedAppointmentTable.Location = new System.Drawing.Point(12, 215);
            this.RecommendedAppointmentTable.Name = "RecommendedAppointmentTable";
            this.RecommendedAppointmentTable.Size = new System.Drawing.Size(515, 188);
            this.RecommendedAppointmentTable.TabIndex = 7;
            this.RecommendedAppointmentTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.RecommendedAppointmentTableRowSelected);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(346, 412);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 29);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(231, 412);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(94, 29);
            this.ScheduleButton.TabIndex = 10;
            this.ScheduleButton.Text = "Schedule";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            this.ScheduleButton.Click += new System.EventHandler(this.ScheduleButtonClick);
            // 
            // RecommendButton
            // 
            this.RecommendButton.Location = new System.Drawing.Point(102, 412);
            this.RecommendButton.Name = "RecommendButton";
            this.RecommendButton.Size = new System.Drawing.Size(108, 29);
            this.RecommendButton.TabIndex = 11;
            this.RecommendButton.Text = "Recommend";
            this.RecommendButton.UseVisualStyleBackColor = true;
            this.RecommendButton.Click += new System.EventHandler(this.RecommendButtonClick);
            // 
            // AppointmentRecommendation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 453);
            this.Controls.Add(this.RecommendButton);
            this.Controls.Add(this.ScheduleButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RecommendedAppointmentTable);
            this.Controls.Add(this.PriorityGroupBox);
            this.Controls.Add(this.DeadlineDatePicker);
            this.Controls.Add(this.LastDateLabel);
            this.Controls.Add(this.TimeGroupBox);
            this.Controls.Add(this.DoctorComboBox);
            this.Controls.Add(this.DoctorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AppointmentRecommendation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment Recommendation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            this.TimeGroupBox.ResumeLayout(false);
            this.TimeGroupBox.PerformLayout();
            this.PriorityGroupBox.ResumeLayout(false);
            this.PriorityGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecommendedAppointmentTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label DoctorLabel;
        private ComboBox DoctorComboBox;
        private Label FromLabel;
        private GroupBox TimeGroupBox;
        private Label ToLabel;
        private Label LastDateLabel;
        private DateTimePicker ToTimePicker;
        private DateTimePicker FromTimePicker;
        private DateTimePicker DeadlineDatePicker;
        private GroupBox PriorityGroupBox;
        private RadioButton DoctorRadioButton;
        private RadioButton TimeRadioButton;
        private RecommendedAppointmentsTable RecommendedAppointmentTable;
        private Button CancelButton;
        private Button ScheduleButton;
        private Button RecommendButton;
    }
}
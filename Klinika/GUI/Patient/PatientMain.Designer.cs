namespace Klinika.GUI.Patient
{
    partial class PatientMain
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.PersonalAppointmentsTab = new System.Windows.Forms.TabPage();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.PersonalAppointmentsTable = new System.Windows.Forms.DataGridView();
            this.NewAppointmentTab = new System.Windows.Forms.TabPage();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.FindAppointmentsButton = new System.Windows.Forms.Button();
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AppointmentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.OccupiedAppointmentsTable = new System.Windows.Forms.DataGridView();
            this.MainTabControl.SuspendLayout();
            this.PersonalAppointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonalAppointmentsTable)).BeginInit();
            this.NewAppointmentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OccupiedAppointmentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.PersonalAppointmentsTab);
            this.MainTabControl.Controls.Add(this.NewAppointmentTab);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(973, 539);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControlSelectedIndexChanged);
            // 
            // PersonalAppointmentsTab
            // 
            this.PersonalAppointmentsTab.Controls.Add(this.DeleteButton);
            this.PersonalAppointmentsTab.Controls.Add(this.ModifyButton);
            this.PersonalAppointmentsTab.Controls.Add(this.PersonalAppointmentsTable);
            this.PersonalAppointmentsTab.Location = new System.Drawing.Point(4, 29);
            this.PersonalAppointmentsTab.Name = "PersonalAppointmentsTab";
            this.PersonalAppointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.PersonalAppointmentsTab.Size = new System.Drawing.Size(965, 506);
            this.PersonalAppointmentsTab.TabIndex = 0;
            this.PersonalAppointmentsTab.Text = "Personal Appointments";
            this.PersonalAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(513, 461);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(94, 29);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteAppointmentClick);
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(348, 461);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(94, 29);
            this.ModifyButton.TabIndex = 1;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyAppointmentClick);
            // 
            // PersonalAppointmentsTable
            // 
            this.PersonalAppointmentsTable.AllowUserToAddRows = false;
            this.PersonalAppointmentsTable.AllowUserToDeleteRows = false;
            this.PersonalAppointmentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PersonalAppointmentsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PersonalAppointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PersonalAppointmentsTable.Location = new System.Drawing.Point(6, 6);
            this.PersonalAppointmentsTable.Name = "PersonalAppointmentsTable";
            this.PersonalAppointmentsTable.ReadOnly = true;
            this.PersonalAppointmentsTable.RowHeadersWidth = 51;
            this.PersonalAppointmentsTable.RowTemplate.Height = 29;
            this.PersonalAppointmentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PersonalAppointmentsTable.Size = new System.Drawing.Size(950, 440);
            this.PersonalAppointmentsTable.TabIndex = 0;
            this.PersonalAppointmentsTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PersonalAppointmentsTableRowSelected);
            // 
            // NewAppointmentTab
            // 
            this.NewAppointmentTab.Controls.Add(this.ScheduleButton);
            this.NewAppointmentTab.Controls.Add(this.FindAppointmentsButton);
            this.NewAppointmentTab.Controls.Add(this.DoctorLabel);
            this.NewAppointmentTab.Controls.Add(this.DoctorComboBox);
            this.NewAppointmentTab.Controls.Add(this.DateLabel);
            this.NewAppointmentTab.Controls.Add(this.TitleLabel);
            this.NewAppointmentTab.Controls.Add(this.AppointmentDatePicker);
            this.NewAppointmentTab.Controls.Add(this.OccupiedAppointmentsTable);
            this.NewAppointmentTab.Location = new System.Drawing.Point(4, 29);
            this.NewAppointmentTab.Name = "NewAppointmentTab";
            this.NewAppointmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewAppointmentTab.Size = new System.Drawing.Size(965, 506);
            this.NewAppointmentTab.TabIndex = 1;
            this.NewAppointmentTab.Text = "New Appointment";
            this.NewAppointmentTab.UseVisualStyleBackColor = true;
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(862, 460);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(94, 29);
            this.ScheduleButton.TabIndex = 7;
            this.ScheduleButton.Text = "Schedule";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            this.ScheduleButton.Click += new System.EventHandler(this.ScheduleAppointmentClick);
            // 
            // FindAppointmentsButton
            // 
            this.FindAppointmentsButton.Location = new System.Drawing.Point(695, 460);
            this.FindAppointmentsButton.Name = "FindAppointmentsButton";
            this.FindAppointmentsButton.Size = new System.Drawing.Size(94, 29);
            this.FindAppointmentsButton.TabIndex = 6;
            this.FindAppointmentsButton.Text = "Find";
            this.FindAppointmentsButton.UseVisualStyleBackColor = true;
            this.FindAppointmentsButton.Click += new System.EventHandler(this.FindAppointmentsClick);
            // 
            // DoctorLabel
            // 
            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Location = new System.Drawing.Point(406, 464);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(116, 20);
            this.DoctorLabel.TabIndex = 5;
            this.DoctorLabel.Text = "Select a doctor: ";
            // 
            // DoctorComboBox
            // 
            this.DoctorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DoctorComboBox.FormattingEnabled = true;
            this.DoctorComboBox.Location = new System.Drawing.Point(528, 460);
            this.DoctorComboBox.Name = "DoctorComboBox";
            this.DoctorComboBox.Size = new System.Drawing.Size(151, 28);
            this.DoctorComboBox.TabIndex = 4;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(6, 463);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(102, 20);
            this.DateLabel.TabIndex = 3;
            this.DateLabel.Text = "Select a date: ";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(396, 13);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(170, 20);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Occupied Appointments";
            // 
            // AppointmentDatePicker
            // 
            this.AppointmentDatePicker.Location = new System.Drawing.Point(114, 461);
            this.AppointmentDatePicker.Name = "AppointmentDatePicker";
            this.AppointmentDatePicker.Size = new System.Drawing.Size(261, 27);
            this.AppointmentDatePicker.TabIndex = 1;
            // 
            // OccupiedAppointmentsTable
            // 
            this.OccupiedAppointmentsTable.AllowUserToAddRows = false;
            this.OccupiedAppointmentsTable.AllowUserToDeleteRows = false;
            this.OccupiedAppointmentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OccupiedAppointmentsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.OccupiedAppointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OccupiedAppointmentsTable.Location = new System.Drawing.Point(6, 48);
            this.OccupiedAppointmentsTable.Name = "OccupiedAppointmentsTable";
            this.OccupiedAppointmentsTable.ReadOnly = true;
            this.OccupiedAppointmentsTable.RowHeadersWidth = 51;
            this.OccupiedAppointmentsTable.RowTemplate.Height = 29;
            this.OccupiedAppointmentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OccupiedAppointmentsTable.Size = new System.Drawing.Size(950, 398);
            this.OccupiedAppointmentsTable.TabIndex = 0;
            // 
            // PatientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 563);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            this.MainTabControl.ResumeLayout(false);
            this.PersonalAppointmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PersonalAppointmentsTable)).EndInit();
            this.NewAppointmentTab.ResumeLayout(false);
            this.NewAppointmentTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OccupiedAppointmentsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MainTabControl;
        private TabPage PersonalAppointmentsTab;
        private TabPage NewAppointmentTab;
        private Button DeleteButton;
        private Button ModifyButton;
        private DataGridView PersonalAppointmentsTable;
        private Button ScheduleButton;
        private Button FindAppointmentsButton;
        private Label DoctorLabel;
        public ComboBox DoctorComboBox;
        private Label DateLabel;
        private Label TitleLabel;
        public DateTimePicker AppointmentDatePicker;
        private DataGridView OccupiedAppointmentsTable;
    }
}
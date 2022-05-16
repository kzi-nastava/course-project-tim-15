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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.PersonalAppointmentsTab = new System.Windows.Forms.TabPage();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.PersonalAppointmentsTable = new System.Windows.Forms.DataGridView();
            this.NewAppointmentTab = new System.Windows.Forms.TabPage();
            this.RecommendButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.FindAppointmentsButton = new System.Windows.Forms.Button();
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AppointmentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.OccupiedAppointmentsTable = new System.Windows.Forms.DataGridView();
            this.MedicalRecordTab = new System.Windows.Forms.TabPage();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MedicalRecordTable = new System.Windows.Forms.DataGridView();
            this.DoctorsTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.DoctorTable = new System.Windows.Forms.DataGridView();
            this.DoctorSearchButton = new System.Windows.Forms.Button();
            this.DoctorNameRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSurnameRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSpecializationRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSpecializationComboBox = new System.Windows.Forms.ComboBox();
            this.DoctorSurnameTextBox = new System.Windows.Forms.TextBox();
            this.DoctorNameTextBox = new System.Windows.Forms.TextBox();
            this.MainTabControl.SuspendLayout();
            this.PersonalAppointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonalAppointmentsTable)).BeginInit();
            this.NewAppointmentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OccupiedAppointmentsTable)).BeginInit();
            this.MedicalRecordTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MedicalRecordTable)).BeginInit();
            this.DoctorsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.PersonalAppointmentsTab);
            this.MainTabControl.Controls.Add(this.NewAppointmentTab);
            this.MainTabControl.Controls.Add(this.MedicalRecordTab);
            this.MainTabControl.Controls.Add(this.DoctorsTab);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1093, 540);
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
            this.PersonalAppointmentsTab.Size = new System.Drawing.Size(1085, 507);
            this.PersonalAppointmentsTab.TabIndex = 0;
            this.PersonalAppointmentsTab.Text = "Personal Appointments";
            this.PersonalAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(589, 461);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(94, 29);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteAppointmentClick);
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(450, 461);
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
            this.PersonalAppointmentsTable.Size = new System.Drawing.Size(1073, 437);
            this.PersonalAppointmentsTable.TabIndex = 0;
            this.PersonalAppointmentsTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PersonalAppointmentsTableRowSelected);
            // 
            // NewAppointmentTab
            // 
            this.NewAppointmentTab.Controls.Add(this.RecommendButton);
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
            this.NewAppointmentTab.Size = new System.Drawing.Size(1085, 507);
            this.NewAppointmentTab.TabIndex = 1;
            this.NewAppointmentTab.Text = "New Appointment";
            this.NewAppointmentTab.UseVisualStyleBackColor = true;
            // 
            // RecommendButton
            // 
            this.RecommendButton.Location = new System.Drawing.Point(957, 459);
            this.RecommendButton.Name = "RecommendButton";
            this.RecommendButton.Size = new System.Drawing.Size(108, 29);
            this.RecommendButton.TabIndex = 8;
            this.RecommendButton.Text = "Recommend";
            this.RecommendButton.UseVisualStyleBackColor = true;
            this.RecommendButton.Click += new System.EventHandler(this.RecommendClick);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(857, 459);
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
            this.TitleLabel.Location = new System.Drawing.Point(470, 13);
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
            this.OccupiedAppointmentsTable.Size = new System.Drawing.Size(1073, 392);
            this.OccupiedAppointmentsTable.TabIndex = 0;
            // 
            // MedicalRecordTab
            // 
            this.MedicalRecordTab.Controls.Add(this.ResetButton);
            this.MedicalRecordTab.Controls.Add(this.SearchButton);
            this.MedicalRecordTab.Controls.Add(this.SearchTextBox);
            this.MedicalRecordTab.Controls.Add(this.label1);
            this.MedicalRecordTab.Controls.Add(this.MedicalRecordTable);
            this.MedicalRecordTab.Location = new System.Drawing.Point(4, 29);
            this.MedicalRecordTab.Name = "MedicalRecordTab";
            this.MedicalRecordTab.Padding = new System.Windows.Forms.Padding(3);
            this.MedicalRecordTab.Size = new System.Drawing.Size(1085, 507);
            this.MedicalRecordTab.TabIndex = 2;
            this.MedicalRecordTab.Text = "Medical Record";
            this.MedicalRecordTab.UseVisualStyleBackColor = true;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(985, 471);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(94, 29);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetClick);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(430, 471);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(94, 29);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchClick);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(188, 472);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(218, 27);
            this.SearchTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Keyword for Anamnesis: ";
            // 
            // MedicalRecordTable
            // 
            this.MedicalRecordTable.AllowUserToAddRows = false;
            this.MedicalRecordTable.AllowUserToDeleteRows = false;
            this.MedicalRecordTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MedicalRecordTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MedicalRecordTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.MedicalRecordTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MedicalRecordTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.MedicalRecordTable.Location = new System.Drawing.Point(6, 6);
            this.MedicalRecordTable.Name = "MedicalRecordTable";
            this.MedicalRecordTable.ReadOnly = true;
            this.MedicalRecordTable.RowHeadersWidth = 51;
            this.MedicalRecordTable.RowTemplate.Height = 29;
            this.MedicalRecordTable.Size = new System.Drawing.Size(1073, 459);
            this.MedicalRecordTable.TabIndex = 0;
            // 
            // DoctorsTab
            // 
            this.DoctorsTab.Controls.Add(this.button1);
            this.DoctorsTab.Controls.Add(this.DoctorTable);
            this.DoctorsTab.Controls.Add(this.DoctorSearchButton);
            this.DoctorsTab.Controls.Add(this.DoctorNameRadioButton);
            this.DoctorsTab.Controls.Add(this.DoctorSurnameRadioButton);
            this.DoctorsTab.Controls.Add(this.DoctorSpecializationRadioButton);
            this.DoctorsTab.Controls.Add(this.DoctorSpecializationComboBox);
            this.DoctorsTab.Controls.Add(this.DoctorSurnameTextBox);
            this.DoctorsTab.Controls.Add(this.DoctorNameTextBox);
            this.DoctorsTab.Location = new System.Drawing.Point(4, 29);
            this.DoctorsTab.Name = "DoctorsTab";
            this.DoctorsTab.Padding = new System.Windows.Forms.Padding(3);
            this.DoctorsTab.Size = new System.Drawing.Size(1085, 507);
            this.DoctorsTab.TabIndex = 3;
            this.DoctorsTab.Text = "Doctors";
            this.DoctorsTab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DoctorTable
            // 
            this.DoctorTable.AllowUserToAddRows = false;
            this.DoctorTable.AllowUserToDeleteRows = false;
            this.DoctorTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DoctorTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DoctorTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DoctorTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DoctorTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.DoctorTable.Location = new System.Drawing.Point(335, 6);
            this.DoctorTable.Name = "DoctorTable";
            this.DoctorTable.ReadOnly = true;
            this.DoctorTable.RowHeadersWidth = 51;
            this.DoctorTable.RowTemplate.Height = 29;
            this.DoctorTable.Size = new System.Drawing.Size(744, 495);
            this.DoctorTable.TabIndex = 12;
            // 
            // DoctorSearchButton
            // 
            this.DoctorSearchButton.Location = new System.Drawing.Point(212, 192);
            this.DoctorSearchButton.Name = "DoctorSearchButton";
            this.DoctorSearchButton.Size = new System.Drawing.Size(94, 29);
            this.DoctorSearchButton.TabIndex = 11;
            this.DoctorSearchButton.Text = "Search";
            this.DoctorSearchButton.UseVisualStyleBackColor = true;
            // 
            // DoctorNameRadioButton
            // 
            this.DoctorNameRadioButton.AutoSize = true;
            this.DoctorNameRadioButton.Location = new System.Drawing.Point(26, 54);
            this.DoctorNameRadioButton.Name = "DoctorNameRadioButton";
            this.DoctorNameRadioButton.Size = new System.Drawing.Size(70, 24);
            this.DoctorNameRadioButton.TabIndex = 10;
            this.DoctorNameRadioButton.TabStop = true;
            this.DoctorNameRadioButton.Text = "Name";
            this.DoctorNameRadioButton.UseVisualStyleBackColor = true;
            this.DoctorNameRadioButton.CheckedChanged += new System.EventHandler(this.DoctorNameRadioButtonCheckedChanged);
            // 
            // DoctorSurnameRadioButton
            // 
            this.DoctorSurnameRadioButton.AutoSize = true;
            this.DoctorSurnameRadioButton.Location = new System.Drawing.Point(26, 100);
            this.DoctorSurnameRadioButton.Name = "DoctorSurnameRadioButton";
            this.DoctorSurnameRadioButton.Size = new System.Drawing.Size(88, 24);
            this.DoctorSurnameRadioButton.TabIndex = 9;
            this.DoctorSurnameRadioButton.TabStop = true;
            this.DoctorSurnameRadioButton.Text = "Surname";
            this.DoctorSurnameRadioButton.UseVisualStyleBackColor = true;
            this.DoctorSurnameRadioButton.CheckedChanged += new System.EventHandler(this.DoctorSurnameRadioButtonCheckedChanged);
            // 
            // DoctorSpecializationRadioButton
            // 
            this.DoctorSpecializationRadioButton.AutoSize = true;
            this.DoctorSpecializationRadioButton.Location = new System.Drawing.Point(26, 144);
            this.DoctorSpecializationRadioButton.Name = "DoctorSpecializationRadioButton";
            this.DoctorSpecializationRadioButton.Size = new System.Drawing.Size(123, 24);
            this.DoctorSpecializationRadioButton.TabIndex = 8;
            this.DoctorSpecializationRadioButton.TabStop = true;
            this.DoctorSpecializationRadioButton.Text = "Specialization";
            this.DoctorSpecializationRadioButton.UseVisualStyleBackColor = true;
            this.DoctorSpecializationRadioButton.CheckedChanged += new System.EventHandler(this.DoctorSpecializationRadioButtonCheckedChanged);
            // 
            // DoctorSpecializationComboBox
            // 
            this.DoctorSpecializationComboBox.FormattingEnabled = true;
            this.DoctorSpecializationComboBox.Location = new System.Drawing.Point(155, 143);
            this.DoctorSpecializationComboBox.Name = "DoctorSpecializationComboBox";
            this.DoctorSpecializationComboBox.Size = new System.Drawing.Size(151, 28);
            this.DoctorSpecializationComboBox.TabIndex = 5;
            // 
            // DoctorSurnameTextBox
            // 
            this.DoctorSurnameTextBox.Location = new System.Drawing.Point(155, 99);
            this.DoctorSurnameTextBox.Name = "DoctorSurnameTextBox";
            this.DoctorSurnameTextBox.Size = new System.Drawing.Size(151, 27);
            this.DoctorSurnameTextBox.TabIndex = 4;
            // 
            // DoctorNameTextBox
            // 
            this.DoctorNameTextBox.Location = new System.Drawing.Point(155, 54);
            this.DoctorNameTextBox.Name = "DoctorNameTextBox";
            this.DoctorNameTextBox.Size = new System.Drawing.Size(151, 27);
            this.DoctorNameTextBox.TabIndex = 3;
            // 
            // PatientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 564);
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
            this.MedicalRecordTab.ResumeLayout(false);
            this.MedicalRecordTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MedicalRecordTable)).EndInit();
            this.DoctorsTab.ResumeLayout(false);
            this.DoctorsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorTable)).EndInit();
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
        private TabPage MedicalRecordTab;
        private DataGridView MedicalRecordTable;
        private Button SearchButton;
        private TextBox SearchTextBox;
        private Label label1;
        private Button ResetButton;
        private Button RecommendButton;
        private TabPage DoctorsTab;
        private RadioButton DoctorNameRadioButton;
        private RadioButton DoctorSurnameRadioButton;
        private RadioButton DoctorSpecializationRadioButton;
        private ComboBox DoctorSpecializationComboBox;
        private TextBox DoctorSurnameTextBox;
        private TextBox DoctorNameTextBox;
        private Button DoctorSearchButton;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridView DoctorsTable;
        private DataGridView DoctorTable;
    }
}
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.PersonalAppointmentsTab = new System.Windows.Forms.TabPage();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.NewAppointmentTab = new System.Windows.Forms.TabPage();
            this.RecommendButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.FindAppointmentsButton = new System.Windows.Forms.Button();
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AppointmentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.MedicalRecordTab = new System.Windows.Forms.TabPage();
            this.SendGradeButton = new System.Windows.Forms.Button();
            this.OccupiedAppointmentsTable = new Klinika.Forms.AppointmentsDataGridView(Klinika.Roles.User.RoleType.PATIENT);
            this.PersonalAppointmentsTable = new Klinika.Forms.AppointmentsDataGridView(Klinika.Roles.User.RoleType.PATIENT);
            this.ResetButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MedicalRecordTable = new System.Windows.Forms.DataGridView();
            this.DoctorsTab = new System.Windows.Forms.TabPage();
            this.DoctorSpecializationComboBox = new System.Windows.Forms.ComboBox();
            this.NewAppointmentButton = new System.Windows.Forms.Button();
            this.DoctorsTable = new System.Windows.Forms.DataGridView();
            this.DoctorSearchButton = new System.Windows.Forms.Button();
            this.DoctorNameRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSurnameRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSpecializationRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSurnameTextBox = new System.Windows.Forms.TextBox();
            this.DoctorNameTextBox = new System.Windows.Forms.TextBox();
            this.NotificationsTab = new System.Windows.Forms.TabPage();
            this.MarkAsReadButton = new System.Windows.Forms.Button();
            this.SetButton = new System.Windows.Forms.Button();
            this.OffsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SetOffsetLabel = new System.Windows.Forms.Label();
            this.NotificationsTable = new System.Windows.Forms.DataGridView();
            this.MainTabControl.SuspendLayout();
            this.PersonalAppointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonalAppointmentsTable)).BeginInit();
            this.NewAppointmentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OccupiedAppointmentsTable)).BeginInit();
            this.MedicalRecordTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MedicalRecordTable)).BeginInit();
            this.DoctorsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorsTable)).BeginInit();
            this.NotificationsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.PersonalAppointmentsTab);
            this.MainTabControl.Controls.Add(this.NewAppointmentTab);
            this.MainTabControl.Controls.Add(this.MedicalRecordTab);
            this.MainTabControl.Controls.Add(this.DoctorsTab);
            this.MainTabControl.Controls.Add(this.NotificationsTab);
            this.MainTabControl.Location = new System.Drawing.Point(10, 9);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(956, 405);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControlSelectedIndexChanged);
            // 
            // PersonalAppointmentsTab
            // 
            this.PersonalAppointmentsTab.Controls.Add(this.DeleteButton);
            this.PersonalAppointmentsTab.Controls.Add(this.ModifyButton);
            this.PersonalAppointmentsTab.Controls.Add(this.PersonalAppointmentsTable);
            this.PersonalAppointmentsTab.Location = new System.Drawing.Point(4, 24);
            this.PersonalAppointmentsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PersonalAppointmentsTab.Name = "PersonalAppointmentsTab";
            this.PersonalAppointmentsTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PersonalAppointmentsTab.Size = new System.Drawing.Size(948, 377);
            this.PersonalAppointmentsTab.TabIndex = 0;
            this.PersonalAppointmentsTab.Text = "Personal Appointments";
            this.PersonalAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(515, 346);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(82, 22);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteAppointmentButtonClick);
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(394, 346);
            this.ModifyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(82, 22);
            this.ModifyButton.TabIndex = 1;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyAppointmentButtonClick);
            // 
            // PersonalAppointmentsTable
            // 
            this.PersonalAppointmentsTable.AllowUserToAddRows = false;
            this.PersonalAppointmentsTable.AllowUserToDeleteRows = false;
            this.PersonalAppointmentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PersonalAppointmentsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PersonalAppointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PersonalAppointmentsTable.Location = new System.Drawing.Point(5, 4);
            this.PersonalAppointmentsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PersonalAppointmentsTable.Name = "PersonalAppointmentsTable";
            this.PersonalAppointmentsTable.ReadOnly = true;
            this.PersonalAppointmentsTable.RowHeadersWidth = 51;
            this.PersonalAppointmentsTable.RowTemplate.Height = 29;
            this.PersonalAppointmentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PersonalAppointmentsTable.Size = new System.Drawing.Size(939, 328);
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
            this.NewAppointmentTab.Location = new System.Drawing.Point(4, 24);
            this.NewAppointmentTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewAppointmentTab.Name = "NewAppointmentTab";
            this.NewAppointmentTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewAppointmentTab.Size = new System.Drawing.Size(948, 377);
            this.NewAppointmentTab.TabIndex = 1;
            this.NewAppointmentTab.Text = "New Appointment";
            this.NewAppointmentTab.UseVisualStyleBackColor = true;
            // 
            // RecommendButton
            // 
            this.RecommendButton.Location = new System.Drawing.Point(837, 344);
            this.RecommendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RecommendButton.Name = "RecommendButton";
            this.RecommendButton.Size = new System.Drawing.Size(94, 22);
            this.RecommendButton.TabIndex = 8;
            this.RecommendButton.Text = "Recommend";
            this.RecommendButton.UseVisualStyleBackColor = true;
            this.RecommendButton.Click += new System.EventHandler(this.RecommendButtonClick);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(750, 344);
            this.ScheduleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(82, 22);
            this.ScheduleButton.TabIndex = 7;
            this.ScheduleButton.Text = "Schedule";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            this.ScheduleButton.Click += new System.EventHandler(this.ScheduleAppointmentButtonClick);
            // 
            // FindAppointmentsButton
            // 
            this.FindAppointmentsButton.Location = new System.Drawing.Point(608, 345);
            this.FindAppointmentsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FindAppointmentsButton.Name = "FindAppointmentsButton";
            this.FindAppointmentsButton.Size = new System.Drawing.Size(82, 22);
            this.FindAppointmentsButton.TabIndex = 6;
            this.FindAppointmentsButton.Text = "Find";
            this.FindAppointmentsButton.UseVisualStyleBackColor = true;
            this.FindAppointmentsButton.Click += new System.EventHandler(this.FindAppointmentsButtonClick);
            // 
            // DoctorLabel
            // 
            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Location = new System.Drawing.Point(355, 348);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(91, 15);
            this.DoctorLabel.TabIndex = 5;
            this.DoctorLabel.Text = "Select a doctor: ";
            // 
            // DoctorComboBox
            // 
            this.DoctorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DoctorComboBox.FormattingEnabled = true;
            this.DoctorComboBox.Location = new System.Drawing.Point(462, 345);
            this.DoctorComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorComboBox.Name = "DoctorComboBox";
            this.DoctorComboBox.Size = new System.Drawing.Size(133, 23);
            this.DoctorComboBox.TabIndex = 4;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(5, 347);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(79, 15);
            this.DateLabel.TabIndex = 3;
            this.DateLabel.Text = "Select a date: ";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(411, 10);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(137, 15);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Occupied Appointments";
            // 
            // AppointmentDatePicker
            // 
            this.AppointmentDatePicker.Location = new System.Drawing.Point(100, 346);
            this.AppointmentDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AppointmentDatePicker.Name = "AppointmentDatePicker";
            this.AppointmentDatePicker.Size = new System.Drawing.Size(229, 23);
            this.AppointmentDatePicker.TabIndex = 1;
            // 
            // OccupiedAppointmentsTable
            // 
            this.OccupiedAppointmentsTable.AllowUserToAddRows = false;
            this.OccupiedAppointmentsTable.AllowUserToDeleteRows = false;
            this.OccupiedAppointmentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OccupiedAppointmentsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.OccupiedAppointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OccupiedAppointmentsTable.Location = new System.Drawing.Point(5, 36);
            this.OccupiedAppointmentsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OccupiedAppointmentsTable.Name = "OccupiedAppointmentsTable";
            this.OccupiedAppointmentsTable.ReadOnly = true;
            this.OccupiedAppointmentsTable.RowHeadersWidth = 51;
            this.OccupiedAppointmentsTable.RowTemplate.Height = 29;
            this.OccupiedAppointmentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OccupiedAppointmentsTable.Size = new System.Drawing.Size(939, 294);
            this.OccupiedAppointmentsTable.TabIndex = 0;
            // 
            // MedicalRecordTab
            // 
            this.MedicalRecordTab.Controls.Add(this.SendGradeButton);
            this.MedicalRecordTab.Controls.Add(this.ResetButton);
            this.MedicalRecordTab.Controls.Add(this.SearchButton);
            this.MedicalRecordTab.Controls.Add(this.SearchTextBox);
            this.MedicalRecordTab.Controls.Add(this.label1);
            this.MedicalRecordTab.Controls.Add(this.MedicalRecordTable);
            this.MedicalRecordTab.Location = new System.Drawing.Point(4, 24);
            this.MedicalRecordTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MedicalRecordTab.Name = "MedicalRecordTab";
            this.MedicalRecordTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MedicalRecordTab.Size = new System.Drawing.Size(948, 377);
            this.MedicalRecordTab.TabIndex = 2;
            this.MedicalRecordTab.Text = "Medical Record";
            this.MedicalRecordTab.UseVisualStyleBackColor = true;
            // 
            // SendGradeButton
            // 
            this.SendGradeButton.Location = new System.Drawing.Point(781, 353);
            this.SendGradeButton.Name = "SendGradeButton";
            this.SendGradeButton.Size = new System.Drawing.Size(75, 23);
            this.SendGradeButton.TabIndex = 5;
            this.SendGradeButton.Text = "Send grade";
            this.SendGradeButton.UseVisualStyleBackColor = true;
            this.SendGradeButton.Click += new System.EventHandler(this.SendGradeButtonClick);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(862, 353);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(82, 22);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButtonClick);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(376, 353);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(82, 22);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(164, 354);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(191, 23);
            this.SearchTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 15);
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
            this.MedicalRecordTable.Location = new System.Drawing.Point(5, 4);
            this.MedicalRecordTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MedicalRecordTable.Name = "MedicalRecordTable";
            this.MedicalRecordTable.ReadOnly = true;
            this.MedicalRecordTable.RowHeadersWidth = 51;
            this.MedicalRecordTable.RowTemplate.Height = 29;
            this.MedicalRecordTable.Size = new System.Drawing.Size(939, 344);
            this.MedicalRecordTable.TabIndex = 0;
            // 
            // DoctorsTab
            // 
            this.DoctorsTab.Controls.Add(this.DoctorSpecializationComboBox);
            this.DoctorsTab.Controls.Add(this.NewAppointmentButton);
            this.DoctorsTab.Controls.Add(this.DoctorsTable);
            this.DoctorsTab.Controls.Add(this.DoctorSearchButton);
            this.DoctorsTab.Controls.Add(this.DoctorNameRadioButton);
            this.DoctorsTab.Controls.Add(this.DoctorSurnameRadioButton);
            this.DoctorsTab.Controls.Add(this.DoctorSpecializationRadioButton);
            this.DoctorsTab.Controls.Add(this.DoctorSurnameTextBox);
            this.DoctorsTab.Controls.Add(this.DoctorNameTextBox);
            this.DoctorsTab.Location = new System.Drawing.Point(4, 24);
            this.DoctorsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorsTab.Name = "DoctorsTab";
            this.DoctorsTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorsTab.Size = new System.Drawing.Size(948, 377);
            this.DoctorsTab.TabIndex = 3;
            this.DoctorsTab.Text = "Doctors";
            this.DoctorsTab.UseVisualStyleBackColor = true;
            // 
            // DoctorSpecializationComboBox
            // 
            this.DoctorSpecializationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DoctorSpecializationComboBox.FormattingEnabled = true;
            this.DoctorSpecializationComboBox.Location = new System.Drawing.Point(136, 107);
            this.DoctorSpecializationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorSpecializationComboBox.Name = "DoctorSpecializationComboBox";
            this.DoctorSpecializationComboBox.Size = new System.Drawing.Size(133, 23);
            this.DoctorSpecializationComboBox.TabIndex = 14;
            // 
            // NewAppointmentButton
            // 
            this.NewAppointmentButton.Location = new System.Drawing.Point(186, 344);
            this.NewAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewAppointmentButton.Name = "NewAppointmentButton";
            this.NewAppointmentButton.Size = new System.Drawing.Size(82, 22);
            this.NewAppointmentButton.TabIndex = 13;
            this.NewAppointmentButton.Text = "Schedule";
            this.NewAppointmentButton.UseVisualStyleBackColor = true;
            this.NewAppointmentButton.Click += new System.EventHandler(this.NewAppointmentButtonClick);
            // 
            // DoctorsTable
            // 
            this.DoctorsTable.AllowUserToAddRows = false;
            this.DoctorsTable.AllowUserToDeleteRows = false;
            this.DoctorsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DoctorsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DoctorsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DoctorsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DoctorsTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.DoctorsTable.Location = new System.Drawing.Point(293, 4);
            this.DoctorsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorsTable.MultiSelect = false;
            this.DoctorsTable.Name = "DoctorsTable";
            this.DoctorsTable.ReadOnly = true;
            this.DoctorsTable.RowHeadersWidth = 51;
            this.DoctorsTable.RowTemplate.Height = 29;
            this.DoctorsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DoctorsTable.Size = new System.Drawing.Size(651, 371);
            this.DoctorsTable.TabIndex = 12;
            this.DoctorsTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoctorsTableRowSelected);
            // 
            // DoctorSearchButton
            // 
            this.DoctorSearchButton.Location = new System.Drawing.Point(186, 144);
            this.DoctorSearchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorSearchButton.Name = "DoctorSearchButton";
            this.DoctorSearchButton.Size = new System.Drawing.Size(82, 22);
            this.DoctorSearchButton.TabIndex = 11;
            this.DoctorSearchButton.Text = "Search";
            this.DoctorSearchButton.UseVisualStyleBackColor = true;
            this.DoctorSearchButton.Click += new System.EventHandler(this.DoctorSearchButtonClick);
            // 
            // DoctorNameRadioButton
            // 
            this.DoctorNameRadioButton.AutoSize = true;
            this.DoctorNameRadioButton.Location = new System.Drawing.Point(23, 40);
            this.DoctorNameRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorNameRadioButton.Name = "DoctorNameRadioButton";
            this.DoctorNameRadioButton.Size = new System.Drawing.Size(57, 19);
            this.DoctorNameRadioButton.TabIndex = 10;
            this.DoctorNameRadioButton.TabStop = true;
            this.DoctorNameRadioButton.Text = "Name";
            this.DoctorNameRadioButton.UseVisualStyleBackColor = true;
            this.DoctorNameRadioButton.CheckedChanged += new System.EventHandler(this.DoctorNameRadioButtonCheckedChanged);
            // 
            // DoctorSurnameRadioButton
            // 
            this.DoctorSurnameRadioButton.AutoSize = true;
            this.DoctorSurnameRadioButton.Location = new System.Drawing.Point(23, 75);
            this.DoctorSurnameRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorSurnameRadioButton.Name = "DoctorSurnameRadioButton";
            this.DoctorSurnameRadioButton.Size = new System.Drawing.Size(72, 19);
            this.DoctorSurnameRadioButton.TabIndex = 9;
            this.DoctorSurnameRadioButton.TabStop = true;
            this.DoctorSurnameRadioButton.Text = "Surname";
            this.DoctorSurnameRadioButton.UseVisualStyleBackColor = true;
            this.DoctorSurnameRadioButton.CheckedChanged += new System.EventHandler(this.DoctorSurnameRadioButtonCheckedChanged);
            // 
            // DoctorSpecializationRadioButton
            // 
            this.DoctorSpecializationRadioButton.AutoSize = true;
            this.DoctorSpecializationRadioButton.Location = new System.Drawing.Point(23, 108);
            this.DoctorSpecializationRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorSpecializationRadioButton.Name = "DoctorSpecializationRadioButton";
            this.DoctorSpecializationRadioButton.Size = new System.Drawing.Size(97, 19);
            this.DoctorSpecializationRadioButton.TabIndex = 8;
            this.DoctorSpecializationRadioButton.TabStop = true;
            this.DoctorSpecializationRadioButton.Text = "Specialization";
            this.DoctorSpecializationRadioButton.UseVisualStyleBackColor = true;
            this.DoctorSpecializationRadioButton.CheckedChanged += new System.EventHandler(this.DoctorSpecializationRadioButtonCheckedChanged);
            // 
            // DoctorSurnameTextBox
            // 
            this.DoctorSurnameTextBox.Location = new System.Drawing.Point(136, 74);
            this.DoctorSurnameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorSurnameTextBox.Name = "DoctorSurnameTextBox";
            this.DoctorSurnameTextBox.Size = new System.Drawing.Size(133, 23);
            this.DoctorSurnameTextBox.TabIndex = 4;
            // 
            // DoctorNameTextBox
            // 
            this.DoctorNameTextBox.Location = new System.Drawing.Point(136, 40);
            this.DoctorNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorNameTextBox.Name = "DoctorNameTextBox";
            this.DoctorNameTextBox.Size = new System.Drawing.Size(133, 23);
            this.DoctorNameTextBox.TabIndex = 3;
            // 
            // NotificationsTab
            // 
            this.NotificationsTab.Controls.Add(this.MarkAsReadButton);
            this.NotificationsTab.Controls.Add(this.SetButton);
            this.NotificationsTab.Controls.Add(this.OffsetNumericUpDown);
            this.NotificationsTab.Controls.Add(this.SetOffsetLabel);
            this.NotificationsTab.Controls.Add(this.NotificationsTable);
            this.NotificationsTab.Location = new System.Drawing.Point(4, 24);
            this.NotificationsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NotificationsTab.Name = "NotificationsTab";
            this.NotificationsTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NotificationsTab.Size = new System.Drawing.Size(948, 377);
            this.NotificationsTab.TabIndex = 4;
            this.NotificationsTab.Text = "Notifications";
            this.NotificationsTab.UseVisualStyleBackColor = true;
            // 
            // MarkAsReadButton
            // 
            this.MarkAsReadButton.Location = new System.Drawing.Point(836, 351);
            this.MarkAsReadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MarkAsReadButton.Name = "MarkAsReadButton";
            this.MarkAsReadButton.Size = new System.Drawing.Size(108, 22);
            this.MarkAsReadButton.TabIndex = 5;
            this.MarkAsReadButton.Text = "Mark as read";
            this.MarkAsReadButton.UseVisualStyleBackColor = true;
            this.MarkAsReadButton.Click += new System.EventHandler(this.MarkAsReadButtonClick);
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(287, 351);
            this.SetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(82, 22);
            this.SetButton.TabIndex = 4;
            this.SetButton.Text = "Set";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButtonClick);
            // 
            // OffsetNumericUpDown
            // 
            this.OffsetNumericUpDown.Location = new System.Drawing.Point(141, 352);
            this.OffsetNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OffsetNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.OffsetNumericUpDown.Name = "OffsetNumericUpDown";
            this.OffsetNumericUpDown.Size = new System.Drawing.Size(131, 23);
            this.OffsetNumericUpDown.TabIndex = 3;
            this.OffsetNumericUpDown.Enter += new System.EventHandler(this.OffsetNumericUpDownEnter);
            // 
            // SetOffsetLabel
            // 
            this.SetOffsetLabel.AutoSize = true;
            this.SetOffsetLabel.Location = new System.Drawing.Point(5, 354);
            this.SetOffsetLabel.Name = "SetOffsetLabel";
            this.SetOffsetLabel.Size = new System.Drawing.Size(119, 15);
            this.SetOffsetLabel.TabIndex = 2;
            this.SetOffsetLabel.Text = "Set new offset [min]: ";
            // 
            // NotificationsTable
            // 
            this.NotificationsTable.AllowUserToAddRows = false;
            this.NotificationsTable.AllowUserToDeleteRows = false;
            this.NotificationsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NotificationsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.NotificationsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.NotificationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NotificationsTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.NotificationsTable.Location = new System.Drawing.Point(5, 4);
            this.NotificationsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NotificationsTable.Name = "NotificationsTable";
            this.NotificationsTable.ReadOnly = true;
            this.NotificationsTable.RowHeadersWidth = 51;
            this.NotificationsTable.RowTemplate.Height = 29;
            this.NotificationsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NotificationsTable.Size = new System.Drawing.Size(939, 338);
            this.NotificationsTable.TabIndex = 1;
            this.NotificationsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NotificationsTable_CellClick);
            // 
            // PatientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 423);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            ((System.ComponentModel.ISupportInitialize)(this.DoctorsTable)).EndInit();
            this.NotificationsTab.ResumeLayout(false);
            this.NotificationsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MainTabControl;
        private TabPage PersonalAppointmentsTab;
        private TabPage NewAppointmentTab;
        private Button DeleteButton;
        private Button ModifyButton;
        internal Klinika.Forms.AppointmentsDataGridView PersonalAppointmentsTable;
        private Button ScheduleButton;
        private Button FindAppointmentsButton;
        private Label DoctorLabel;
        public ComboBox DoctorComboBox;
        private Label DateLabel;
        private Label TitleLabel;
        public DateTimePicker AppointmentDatePicker;
        internal Klinika.Forms.AppointmentsDataGridView OccupiedAppointmentsTable;
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
        private TextBox DoctorSurnameTextBox;
        private TextBox DoctorNameTextBox;
        private Button DoctorSearchButton;
        private Button NewAppointmentButton;
        private DataGridView DoctorsTable;
        public ComboBox DoctorSpecializationComboBox;
        private TabPage NotificationsTab;
        private DataGridView NotificationsTable;
        private NumericUpDown OffsetNumericUpDown;
        private Label SetOffsetLabel;
        private Button MarkAsReadButton;
        private Button SetButton;
        private Button SendGradeButton;
    }
}
﻿namespace Klinika.GUI.Doctor
{
    partial class DoctorMain
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
            this.AllAppointmentsTab = new System.Windows.Forms.TabPage();
            this.AddAppointmentButton = new System.Windows.Forms.Button();
            this.DeleteAppointmentButton = new System.Windows.Forms.Button();
            this.EditAppointmentButton = new System.Windows.Forms.Button();
            this.ScheduleTab = new System.Windows.Forms.TabPage();
            this.PerformButton = new System.Windows.Forms.Button();
            this.ViewMedicalRecordButton = new System.Windows.Forms.Button();
            this.ScheduleDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ScheduleTable = new Klinika.Forms.AppointmentsDataGridView(Klinika.Roles.User.RoleType.DOCTOR);
            this.AllAppointmentsTable = new Klinika.Forms.AppointmentsDataGridView(Klinika.Roles.User.RoleType.DOCTOR);
            this.UnapprovedDrugsTab = new System.Windows.Forms.TabPage();
            this.DenyDrugButton = new System.Windows.Forms.Button();
            this.ApproveDrugButton = new System.Windows.Forms.Button();
            this.DenyDrugDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UnapprovedDrugsTable = new Klinika.Forms.DrugsDataGridView();
            this.VacationRequestTab = new System.Windows.Forms.TabPage();
            this.EmergencyCheckBox = new System.Windows.Forms.CheckBox();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SendRequestButton = new System.Windows.Forms.Button();
            this.ReasonTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VacationRequestTable = new Klinika.Forms.VacationRequestsDataGridView();
            this.MainTabControl.SuspendLayout();
            this.AllAppointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllAppointmentsTable)).BeginInit();
            this.ScheduleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleTable)).BeginInit();
            this.UnapprovedDrugsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnapprovedDrugsTable)).BeginInit();
            this.VacationRequestTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VacationRequestTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.AllAppointmentsTab);
            this.MainTabControl.Controls.Add(this.ScheduleTab);
            this.MainTabControl.Controls.Add(this.UnapprovedDrugsTab);
            this.MainTabControl.Controls.Add(this.VacationRequestTab);
            this.MainTabControl.Location = new System.Drawing.Point(11, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(939, 512);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControlSelectedIndexChanged);
            // 
            // AllAppointmentsTab
            // 
            this.AllAppointmentsTab.Controls.Add(this.AddAppointmentButton);
            this.AllAppointmentsTab.Controls.Add(this.DeleteAppointmentButton);
            this.AllAppointmentsTab.Controls.Add(this.EditAppointmentButton);
            this.AllAppointmentsTab.Controls.Add(this.AllAppointmentsTable);
            this.AllAppointmentsTab.Location = new System.Drawing.Point(4, 29);
            this.AllAppointmentsTab.Name = "AllAppointmentsTab";
            this.AllAppointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AllAppointmentsTab.Size = new System.Drawing.Size(931, 479);
            this.AllAppointmentsTab.TabIndex = 0;
            this.AllAppointmentsTab.Text = "All Appointments";
            this.AllAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // AddAppointmentButton
            // 
            this.AddAppointmentButton.Location = new System.Drawing.Point(833, 440);
            this.AddAppointmentButton.Name = "AddAppointmentButton";
            this.AddAppointmentButton.Size = new System.Drawing.Size(94, 29);
            this.AddAppointmentButton.TabIndex = 3;
            this.AddAppointmentButton.Text = "Add";
            this.AddAppointmentButton.UseVisualStyleBackColor = true;
            this.AddAppointmentButton.Click += new System.EventHandler(this.AddAppointmentButtonClick);
            // 
            // DeleteAppointmentButton
            // 
            this.DeleteAppointmentButton.Enabled = false;
            this.DeleteAppointmentButton.Location = new System.Drawing.Point(106, 440);
            this.DeleteAppointmentButton.Name = "DeleteAppointmentButton";
            this.DeleteAppointmentButton.Size = new System.Drawing.Size(94, 29);
            this.DeleteAppointmentButton.TabIndex = 2;
            this.DeleteAppointmentButton.Text = "Delete";
            this.DeleteAppointmentButton.UseVisualStyleBackColor = true;
            this.DeleteAppointmentButton.Click += new System.EventHandler(this.DeleteAppointmentButtonClick);
            // 
            // EditAppointmentButton
            // 
            this.EditAppointmentButton.Enabled = false;
            this.EditAppointmentButton.Location = new System.Drawing.Point(6, 440);
            this.EditAppointmentButton.Name = "EditAppointmentButton";
            this.EditAppointmentButton.Size = new System.Drawing.Size(94, 29);
            this.EditAppointmentButton.TabIndex = 1;
            this.EditAppointmentButton.Text = "Edit";
            this.EditAppointmentButton.UseVisualStyleBackColor = true;
            this.EditAppointmentButton.Click += new System.EventHandler(this.EditAppointmentButtonClick);
            // 
            // AllAppointmentsTable
            // 
            this.AllAppointmentsTable.AllowUserToAddRows = false;
            this.AllAppointmentsTable.AllowUserToDeleteRows = false;
            this.AllAppointmentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AllAppointmentsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.AllAppointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllAppointmentsTable.Location = new System.Drawing.Point(6, 5);
            this.AllAppointmentsTable.Name = "AllAppointmentsTable";
            this.AllAppointmentsTable.ReadOnly = true;
            this.AllAppointmentsTable.RowHeadersWidth = 51;
            this.AllAppointmentsTable.RowTemplate.Height = 29;
            this.AllAppointmentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AllAppointmentsTable.Size = new System.Drawing.Size(920, 429);
            this.AllAppointmentsTable.TabIndex = 0;
            this.AllAppointmentsTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllAppointmentsTableRowSelected);
            // 
            // ScheduleTab
            // 
            this.ScheduleTab.Controls.Add(this.PerformButton);
            this.ScheduleTab.Controls.Add(this.ViewMedicalRecordButton);
            this.ScheduleTab.Controls.Add(this.ScheduleDatePicker);
            this.ScheduleTab.Controls.Add(this.ScheduleTable);
            this.ScheduleTab.Location = new System.Drawing.Point(4, 29);
            this.ScheduleTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScheduleTab.Name = "ScheduleTab";
            this.ScheduleTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScheduleTab.Size = new System.Drawing.Size(931, 479);
            this.ScheduleTab.TabIndex = 1;
            this.ScheduleTab.Text = "Schedule";
            this.ScheduleTab.UseVisualStyleBackColor = true;
            // 
            // PerformButton
            // 
            this.PerformButton.Location = new System.Drawing.Point(667, 440);
            this.PerformButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PerformButton.Name = "PerformButton";
            this.PerformButton.Size = new System.Drawing.Size(86, 31);
            this.PerformButton.TabIndex = 3;
            this.PerformButton.Text = "Perform";
            this.PerformButton.UseVisualStyleBackColor = true;
            this.PerformButton.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // ViewMedicalRecordButton
            // 
            this.ViewMedicalRecordButton.Location = new System.Drawing.Point(760, 440);
            this.ViewMedicalRecordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewMedicalRecordButton.Name = "ViewMedicalRecordButton";
            this.ViewMedicalRecordButton.Size = new System.Drawing.Size(163, 31);
            this.ViewMedicalRecordButton.TabIndex = 2;
            this.ViewMedicalRecordButton.Text = "View Patient Medical Record";
            this.ViewMedicalRecordButton.UseVisualStyleBackColor = true;
            this.ViewMedicalRecordButton.Click += new System.EventHandler(this.ViewMedicalRecordButtonClick);
            // 
            // ScheduleDatePicker
            // 
            this.ScheduleDatePicker.Location = new System.Drawing.Point(3, 440);
            this.ScheduleDatePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScheduleDatePicker.Name = "ScheduleDatePicker";
            this.ScheduleDatePicker.Size = new System.Drawing.Size(253, 27);
            this.ScheduleDatePicker.TabIndex = 1;
            this.ScheduleDatePicker.ValueChanged += new System.EventHandler(this.ScheduleDatePickerValueChanged);
            // 
            // ScheduleTable
            // 
            this.ScheduleTable.AllowUserToAddRows = false;
            this.ScheduleTable.AllowUserToDeleteRows = false;
            this.ScheduleTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ScheduleTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ScheduleTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleTable.Location = new System.Drawing.Point(3, 7);
            this.ScheduleTable.Name = "ScheduleTable";
            this.ScheduleTable.ReadOnly = true;
            this.ScheduleTable.RowHeadersWidth = 51;
            this.ScheduleTable.RowTemplate.Height = 25;
            this.ScheduleTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ScheduleTable.Size = new System.Drawing.Size(920, 429);
            this.ScheduleTable.TabIndex = 0;
            this.ScheduleTable.SelectionChanged += new System.EventHandler(this.ScheduleTableSelectionChanged);
            // 
            // UnapprovedDrugsTab
            // 
            this.UnapprovedDrugsTab.Controls.Add(this.DenyDrugButton);
            this.UnapprovedDrugsTab.Controls.Add(this.ApproveDrugButton);
            this.UnapprovedDrugsTab.Controls.Add(this.DenyDrugDescription);
            this.UnapprovedDrugsTab.Controls.Add(this.label1);
            this.UnapprovedDrugsTab.Controls.Add(this.UnapprovedDrugsTable);
            this.UnapprovedDrugsTab.Location = new System.Drawing.Point(4, 29);
            this.UnapprovedDrugsTab.Name = "UnapprovedDrugsTab";
            this.UnapprovedDrugsTab.Padding = new System.Windows.Forms.Padding(3);
            this.UnapprovedDrugsTab.Size = new System.Drawing.Size(931, 479);
            this.UnapprovedDrugsTab.TabIndex = 2;
            this.UnapprovedDrugsTab.Text = "Unapproved Drugs";
            this.UnapprovedDrugsTab.UseVisualStyleBackColor = true;
            // 
            // DenyDrugButton
            // 
            this.DenyDrugButton.Location = new System.Drawing.Point(96, 443);
            this.DenyDrugButton.Name = "DenyDrugButton";
            this.DenyDrugButton.Size = new System.Drawing.Size(94, 29);
            this.DenyDrugButton.TabIndex = 6;
            this.DenyDrugButton.Text = "Deny";
            this.DenyDrugButton.UseVisualStyleBackColor = true;
            this.DenyDrugButton.Click += new System.EventHandler(this.DenyDrugButtonClick);
            // 
            // ApproveDrugButton
            // 
            this.ApproveDrugButton.Location = new System.Drawing.Point(196, 443);
            this.ApproveDrugButton.Name = "ApproveDrugButton";
            this.ApproveDrugButton.Size = new System.Drawing.Size(94, 29);
            this.ApproveDrugButton.TabIndex = 5;
            this.ApproveDrugButton.Text = "Approve";
            this.ApproveDrugButton.UseVisualStyleBackColor = true;
            this.ApproveDrugButton.Click += new System.EventHandler(this.ApproveDrugButtonClick);
            // 
            // DenyDrugDescription
            // 
            this.DenyDrugDescription.Location = new System.Drawing.Point(10, 327);
            this.DenyDrugDescription.Multiline = true;
            this.DenyDrugDescription.Name = "DenyDrugDescription";
            this.DenyDrugDescription.Size = new System.Drawing.Size(280, 110);
            this.DenyDrugDescription.TabIndex = 4;
            this.DenyDrugDescription.TextChanged += new System.EventHandler(this.DenyDrugDescriptionTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Description";
            // 
            // UnapprovedDrugsTable
            // 
            this.UnapprovedDrugsTable.AllowUserToAddRows = false;
            this.UnapprovedDrugsTable.AllowUserToDeleteRows = false;
            this.UnapprovedDrugsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UnapprovedDrugsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.UnapprovedDrugsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.UnapprovedDrugsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnapprovedDrugsTable.GridColor = System.Drawing.SystemColors.Control;
            this.UnapprovedDrugsTable.Location = new System.Drawing.Point(296, 7);
            this.UnapprovedDrugsTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UnapprovedDrugsTable.Name = "UnapprovedDrugsTable";
            this.UnapprovedDrugsTable.ReadOnly = true;
            this.UnapprovedDrugsTable.RowHeadersWidth = 51;
            this.UnapprovedDrugsTable.RowTemplate.Height = 25;
            this.UnapprovedDrugsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UnapprovedDrugsTable.Size = new System.Drawing.Size(629, 465);
            this.UnapprovedDrugsTable.TabIndex = 2;
            this.UnapprovedDrugsTable.SelectionChanged += new System.EventHandler(this.UnapprovedDrugsTableSelectionChanged);
            // 
            // VacationRequestTab
            // 
            this.VacationRequestTab.Controls.Add(this.EmergencyCheckBox);
            this.VacationRequestTab.Controls.Add(this.ToDatePicker);
            this.VacationRequestTab.Controls.Add(this.FromDatePicker);
            this.VacationRequestTab.Controls.Add(this.label3);
            this.VacationRequestTab.Controls.Add(this.label2);
            this.VacationRequestTab.Controls.Add(this.SendRequestButton);
            this.VacationRequestTab.Controls.Add(this.ReasonTextBox);
            this.VacationRequestTab.Controls.Add(this.label4);
            this.VacationRequestTab.Controls.Add(this.VacationRequestTable);
            this.VacationRequestTab.Location = new System.Drawing.Point(4, 29);
            this.VacationRequestTab.Name = "VacationRequestTab";
            this.VacationRequestTab.Padding = new System.Windows.Forms.Padding(3);
            this.VacationRequestTab.Size = new System.Drawing.Size(931, 479);
            this.VacationRequestTab.TabIndex = 3;
            this.VacationRequestTab.Text = "Vacation Request";
            this.VacationRequestTab.UseVisualStyleBackColor = true;
            // 
            // EmergencyCheckBox
            // 
            this.EmergencyCheckBox.AutoSize = true;
            this.EmergencyCheckBox.Location = new System.Drawing.Point(21, 251);
            this.EmergencyCheckBox.Name = "EmergencyCheckBox";
            this.EmergencyCheckBox.Size = new System.Drawing.Size(104, 24);
            this.EmergencyCheckBox.TabIndex = 11;
            this.EmergencyCheckBox.Text = "Emergency";
            this.EmergencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDatePicker.Location = new System.Drawing.Point(70, 57);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(200, 27);
            this.ToDatePicker.TabIndex = 10;
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDatePicker.Location = new System.Drawing.Point(70, 24);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(200, 27);
            this.FromDatePicker.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "From";
            // 
            // SendRequestButton
            // 
            this.SendRequestButton.Location = new System.Drawing.Point(168, 443);
            this.SendRequestButton.Name = "SendRequestButton";
            this.SendRequestButton.Size = new System.Drawing.Size(122, 29);
            this.SendRequestButton.TabIndex = 5;
            this.SendRequestButton.Text = "Send Request";
            this.SendRequestButton.UseVisualStyleBackColor = true;
            this.SendRequestButton.Click += new System.EventHandler(this.SendRequestButton_Click);
            // 
            // ReasonTextBox
            // 
            this.ReasonTextBox.Location = new System.Drawing.Point(21, 121);
            this.ReasonTextBox.Multiline = true;
            this.ReasonTextBox.Name = "ReasonTextBox";
            this.ReasonTextBox.Size = new System.Drawing.Size(249, 110);
            this.ReasonTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reason";
            // 
            // VacationRequestTable
            // 
            this.VacationRequestTable.AllowUserToAddRows = false;
            this.VacationRequestTable.AllowUserToDeleteRows = false;
            this.VacationRequestTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VacationRequestTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.VacationRequestTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.VacationRequestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VacationRequestTable.GridColor = System.Drawing.SystemColors.Control;
            this.VacationRequestTable.Location = new System.Drawing.Point(296, 7);
            this.VacationRequestTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VacationRequestTable.Name = "VacationRequestTable";
            this.VacationRequestTable.ReadOnly = true;
            this.VacationRequestTable.RowHeadersWidth = 51;
            this.VacationRequestTable.RowTemplate.Height = 25;
            this.VacationRequestTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VacationRequestTable.Size = new System.Drawing.Size(629, 465);
            this.VacationRequestTable.TabIndex = 2;
            // 
            // DoctorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 536);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoctorMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            this.MainTabControl.ResumeLayout(false);
            this.AllAppointmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllAppointmentsTable)).EndInit();
            this.ScheduleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleTable)).EndInit();
            this.UnapprovedDrugsTab.ResumeLayout(false);
            this.UnapprovedDrugsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnapprovedDrugsTable)).EndInit();
            this.VacationRequestTab.ResumeLayout(false);
            this.VacationRequestTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VacationRequestTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MainTabControl;
        private TabPage AllAppointmentsTab;
        public Klinika.Forms.AppointmentsDataGridView AllAppointmentsTable;
        private Button DeleteAppointmentButton;
        private Button EditAppointmentButton;
        private Button AddAppointmentButton;
        private TabPage ScheduleTab;
        public Klinika.Forms.AppointmentsDataGridView ScheduleTable;
        private DateTimePicker ScheduleDatePicker;
        private Button ViewMedicalRecordButton;
        private Button PerformButton;
        private TabPage UnapprovedDrugsTab;
        internal Klinika.Forms.DrugsDataGridView UnapprovedDrugsTable;
        private Button DenyDrugButton;
        private Button ApproveDrugButton;
        private TextBox DenyDrugDescription;
        private Label label1;
        private TabPage VacationRequestTab;
        private CheckBox EmergencyCheckBox;
        internal DateTimePicker ToDatePicker;
        internal DateTimePicker FromDatePicker;
        private Label label3;
        private Label label2;
        private Button SendRequestButton;
        private TextBox ReasonTextBox;
        private Label label4;
        internal Klinika.Forms.VacationRequestsDataGridView VacationRequestTable;
    }
}
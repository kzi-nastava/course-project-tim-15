namespace Klinika.GUI.Doctor
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
            this.AllAppointmentsTable = new System.Windows.Forms.DataGridView();
            this.ScheduleTab = new System.Windows.Forms.TabPage();
            this.PerformeButton = new System.Windows.Forms.Button();
            this.ViewMedicalRecordButton = new System.Windows.Forms.Button();
            this.ScheduleDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ScheduleTable = new System.Windows.Forms.DataGridView();
            this.MainTabControl.SuspendLayout();
            this.AllAppointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllAppointmentsTable)).BeginInit();
            this.ScheduleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.AllAppointmentsTab);
            this.MainTabControl.Controls.Add(this.ScheduleTab);
            this.MainTabControl.Location = new System.Drawing.Point(10, 9);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(822, 384);
            this.MainTabControl.TabIndex = 0;
            // 
            // AllAppointmentsTab
            // 
            this.AllAppointmentsTab.Controls.Add(this.AddAppointmentButton);
            this.AllAppointmentsTab.Controls.Add(this.DeleteAppointmentButton);
            this.AllAppointmentsTab.Controls.Add(this.EditAppointmentButton);
            this.AllAppointmentsTab.Controls.Add(this.AllAppointmentsTable);
            this.AllAppointmentsTab.Location = new System.Drawing.Point(4, 24);
            this.AllAppointmentsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AllAppointmentsTab.Name = "AllAppointmentsTab";
            this.AllAppointmentsTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AllAppointmentsTab.Size = new System.Drawing.Size(814, 356);
            this.AllAppointmentsTab.TabIndex = 0;
            this.AllAppointmentsTab.Text = "All Appointments";
            this.AllAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // AddAppointmentButton
            // 
            this.AddAppointmentButton.Location = new System.Drawing.Point(729, 330);
            this.AddAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddAppointmentButton.Name = "AddAppointmentButton";
            this.AddAppointmentButton.Size = new System.Drawing.Size(82, 22);
            this.AddAppointmentButton.TabIndex = 3;
            this.AddAppointmentButton.Text = "Add";
            this.AddAppointmentButton.UseVisualStyleBackColor = true;
            this.AddAppointmentButton.Click += new System.EventHandler(this.AddAppointmentButtonClick);
            // 
            // DeleteAppointmentButton
            // 
            this.DeleteAppointmentButton.Enabled = false;
            this.DeleteAppointmentButton.Location = new System.Drawing.Point(93, 330);
            this.DeleteAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteAppointmentButton.Name = "DeleteAppointmentButton";
            this.DeleteAppointmentButton.Size = new System.Drawing.Size(82, 22);
            this.DeleteAppointmentButton.TabIndex = 2;
            this.DeleteAppointmentButton.Text = "Delete";
            this.DeleteAppointmentButton.UseVisualStyleBackColor = true;
            this.DeleteAppointmentButton.Click += new System.EventHandler(this.DeleteAppointmentButtonClick);
            // 
            // EditAppointmentButton
            // 
            this.EditAppointmentButton.Enabled = false;
            this.EditAppointmentButton.Location = new System.Drawing.Point(5, 330);
            this.EditAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditAppointmentButton.Name = "EditAppointmentButton";
            this.EditAppointmentButton.Size = new System.Drawing.Size(82, 22);
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
            this.AllAppointmentsTable.Location = new System.Drawing.Point(5, 4);
            this.AllAppointmentsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AllAppointmentsTable.Name = "AllAppointmentsTable";
            this.AllAppointmentsTable.ReadOnly = true;
            this.AllAppointmentsTable.RowHeadersWidth = 51;
            this.AllAppointmentsTable.RowTemplate.Height = 29;
            this.AllAppointmentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AllAppointmentsTable.Size = new System.Drawing.Size(805, 322);
            this.AllAppointmentsTable.TabIndex = 0;
            this.AllAppointmentsTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllAppointmentsTableRowSelected);
            // 
            // ScheduleTab
            // 
            this.ScheduleTab.Controls.Add(this.PerformeButton);
            this.ScheduleTab.Controls.Add(this.ViewMedicalRecordButton);
            this.ScheduleTab.Controls.Add(this.ScheduleDatePicker);
            this.ScheduleTab.Controls.Add(this.ScheduleTable);
            this.ScheduleTab.Location = new System.Drawing.Point(4, 24);
            this.ScheduleTab.Name = "ScheduleTab";
            this.ScheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScheduleTab.Size = new System.Drawing.Size(814, 356);
            this.ScheduleTab.TabIndex = 1;
            this.ScheduleTab.Text = "Schedule";
            this.ScheduleTab.UseVisualStyleBackColor = true;
            // 
            // PerformeButton
            // 
            this.PerformeButton.Location = new System.Drawing.Point(584, 330);
            this.PerformeButton.Name = "PerformeButton";
            this.PerformeButton.Size = new System.Drawing.Size(75, 23);
            this.PerformeButton.TabIndex = 3;
            this.PerformeButton.Text = "Perform";
            this.PerformeButton.UseVisualStyleBackColor = true;
            this.PerformeButton.Click += new System.EventHandler(this.PreformeButtonClick);
            // 
            // ViewMedicalRecordButton
            // 
            this.ViewMedicalRecordButton.Location = new System.Drawing.Point(665, 330);
            this.ViewMedicalRecordButton.Name = "ViewMedicalRecordButton";
            this.ViewMedicalRecordButton.Size = new System.Drawing.Size(143, 23);
            this.ViewMedicalRecordButton.TabIndex = 2;
            this.ViewMedicalRecordButton.Text = "View Patient Medical Record";
            this.ViewMedicalRecordButton.UseVisualStyleBackColor = true;
            this.ViewMedicalRecordButton.Click += new System.EventHandler(this.ViewMedicalRecordButtonClick);
            // 
            // ScheduleDatePicker
            // 
            this.ScheduleDatePicker.Location = new System.Drawing.Point(3, 330);
            this.ScheduleDatePicker.Name = "ScheduleDatePicker";
            this.ScheduleDatePicker.Size = new System.Drawing.Size(222, 23);
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
            this.ScheduleTable.Location = new System.Drawing.Point(3, 5);
            this.ScheduleTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScheduleTable.Name = "ScheduleTable";
            this.ScheduleTable.ReadOnly = true;
            this.ScheduleTable.RowTemplate.Height = 25;
            this.ScheduleTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ScheduleTable.Size = new System.Drawing.Size(805, 322);
            this.ScheduleTable.TabIndex = 0;
            this.ScheduleTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScheduleTableRowSelected);
            this.ScheduleTable.SelectionChanged += new System.EventHandler(this.ScheduleTableSelectionChanged);
            // 
            // DoctorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 402);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoctorMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoctorMainFormClosing);
            this.Load += new System.EventHandler(this.DoctorMainLoad);
            this.MainTabControl.ResumeLayout(false);
            this.AllAppointmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllAppointmentsTable)).EndInit();
            this.ScheduleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MainTabControl;
        private TabPage AllAppointmentsTab;
        public DataGridView AllAppointmentsTable;
        private Button DeleteAppointmentButton;
        private Button EditAppointmentButton;
        private Button AddAppointmentButton;
        private TabPage ScheduleTab;
        public DataGridView ScheduleTable;
        private DateTimePicker ScheduleDatePicker;
        private Button ViewMedicalRecordButton;
        private Button PerformeButton;
    }
}
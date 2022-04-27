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
            this.YourAppointmentsTab = new System.Windows.Forms.TabPage();
            this.NewAppointmentTab = new System.Windows.Forms.TabPage();
            this.YourAppointmentsTable = new System.Windows.Forms.DataGridView();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.FindButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.YourAppointmentsTab.SuspendLayout();
            this.NewAppointmentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YourAppointmentsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.YourAppointmentsTab);
            this.MainTabControl.Controls.Add(this.NewAppointmentTab);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(973, 539);
            this.MainTabControl.TabIndex = 0;
            // 
            // YourAppointmentsTab
            // 
            this.YourAppointmentsTab.Controls.Add(this.DeleteButton);
            this.YourAppointmentsTab.Controls.Add(this.ModifyButton);
            this.YourAppointmentsTab.Controls.Add(this.YourAppointmentsTable);
            this.YourAppointmentsTab.Location = new System.Drawing.Point(4, 29);
            this.YourAppointmentsTab.Name = "YourAppointmentsTab";
            this.YourAppointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.YourAppointmentsTab.Size = new System.Drawing.Size(965, 506);
            this.YourAppointmentsTab.TabIndex = 0;
            this.YourAppointmentsTab.Text = "Your Appointments";
            this.YourAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // NewAppointmentTab
            // 
            this.NewAppointmentTab.Controls.Add(this.ScheduleButton);
            this.NewAppointmentTab.Controls.Add(this.FindButton);
            this.NewAppointmentTab.Controls.Add(this.DoctorLabel);
            this.NewAppointmentTab.Controls.Add(this.DoctorComboBox);
            this.NewAppointmentTab.Controls.Add(this.DateLabel);
            this.NewAppointmentTab.Controls.Add(this.TitleLabel);
            this.NewAppointmentTab.Controls.Add(this.dateTimePicker1);
            this.NewAppointmentTab.Controls.Add(this.dataGridView1);
            this.NewAppointmentTab.Location = new System.Drawing.Point(4, 29);
            this.NewAppointmentTab.Name = "NewAppointmentTab";
            this.NewAppointmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewAppointmentTab.Size = new System.Drawing.Size(965, 506);
            this.NewAppointmentTab.TabIndex = 1;
            this.NewAppointmentTab.Text = "New Appointment";
            this.NewAppointmentTab.UseVisualStyleBackColor = true;
            // 
            // YourAppointmentsTable
            // 
            this.YourAppointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.YourAppointmentsTable.Location = new System.Drawing.Point(6, 6);
            this.YourAppointmentsTable.Name = "YourAppointmentsTable";
            this.YourAppointmentsTable.RowHeadersWidth = 51;
            this.YourAppointmentsTable.RowTemplate.Height = 29;
            this.YourAppointmentsTable.Size = new System.Drawing.Size(950, 440);
            this.YourAppointmentsTable.TabIndex = 0;
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(348, 461);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(94, 29);
            this.ModifyButton.TabIndex = 1;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(513, 461);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(94, 29);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(950, 398);
            this.dataGridView1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(114, 461);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(261, 27);
            this.dateTimePicker1.TabIndex = 1;
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
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(6, 466);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(102, 20);
            this.DateLabel.TabIndex = 3;
            this.DateLabel.Text = "Select a date: ";
            // 
            // DoctorComboBox
            // 
            this.DoctorComboBox.FormattingEnabled = true;
            this.DoctorComboBox.Location = new System.Drawing.Point(528, 460);
            this.DoctorComboBox.Name = "DoctorComboBox";
            this.DoctorComboBox.Size = new System.Drawing.Size(151, 28);
            this.DoctorComboBox.TabIndex = 4;
            // 
            // DoctorLabel
            // 
            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Location = new System.Drawing.Point(406, 466);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(116, 20);
            this.DoctorLabel.TabIndex = 5;
            this.DoctorLabel.Text = "Select a doctor: ";
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(718, 459);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(94, 29);
            this.FindButton.TabIndex = 6;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(862, 459);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(94, 29);
            this.ScheduleButton.TabIndex = 7;
            this.ScheduleButton.Text = "Schedule";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            // 
            // PatientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 563);
            this.Controls.Add(this.MainTabControl);
            this.Name = "PatientMain";
            this.Text = "PatientMain";
            this.MainTabControl.ResumeLayout(false);
            this.YourAppointmentsTab.ResumeLayout(false);
            this.NewAppointmentTab.ResumeLayout(false);
            this.NewAppointmentTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YourAppointmentsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MainTabControl;
        private TabPage YourAppointmentsTab;
        private TabPage NewAppointmentTab;
        private Button DeleteButton;
        private Button ModifyButton;
        private DataGridView YourAppointmentsTable;
        private Button ScheduleButton;
        private Button FindButton;
        private Label DoctorLabel;
        private ComboBox DoctorComboBox;
        private Label DateLabel;
        private Label TitleLabel;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
    }
}
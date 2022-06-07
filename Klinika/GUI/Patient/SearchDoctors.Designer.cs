using Klinika.Forms;

namespace Klinika.GUI.Patient
{
    partial class SearchDoctors
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
            this.DoctorNameRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSurnameRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSpecializationRadioButton = new System.Windows.Forms.RadioButton();
            this.DoctorSpecializationComboBox = new System.Windows.Forms.ComboBox();
            this.NewAppointmentButton = new System.Windows.Forms.Button();
            this.DoctorSearchButton = new System.Windows.Forms.Button();
            this.DoctorSurnameTextBox = new System.Windows.Forms.TextBox();
            this.DoctorNameTextBox = new System.Windows.Forms.TextBox();
            this.DoctorsTable = new Klinika.Forms.DoctorsTable();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DoctorNameRadioButton
            // 
            this.DoctorNameRadioButton.AutoSize = true;
            this.DoctorNameRadioButton.Location = new System.Drawing.Point(12, 57);
            this.DoctorNameRadioButton.Name = "DoctorNameRadioButton";
            this.DoctorNameRadioButton.Size = new System.Drawing.Size(70, 24);
            this.DoctorNameRadioButton.TabIndex = 13;
            this.DoctorNameRadioButton.TabStop = true;
            this.DoctorNameRadioButton.Text = "Name";
            this.DoctorNameRadioButton.UseVisualStyleBackColor = true;
            this.DoctorNameRadioButton.CheckedChanged += new System.EventHandler(this.DoctorNameRadioButtonCheckedChanged);
            // 
            // DoctorSurnameRadioButton
            // 
            this.DoctorSurnameRadioButton.AutoSize = true;
            this.DoctorSurnameRadioButton.Location = new System.Drawing.Point(12, 104);
            this.DoctorSurnameRadioButton.Name = "DoctorSurnameRadioButton";
            this.DoctorSurnameRadioButton.Size = new System.Drawing.Size(88, 24);
            this.DoctorSurnameRadioButton.TabIndex = 12;
            this.DoctorSurnameRadioButton.TabStop = true;
            this.DoctorSurnameRadioButton.Text = "Surname";
            this.DoctorSurnameRadioButton.UseVisualStyleBackColor = true;
            this.DoctorSurnameRadioButton.CheckedChanged += new System.EventHandler(this.DoctorSurnameRadioButtonCheckedChanged);
            // 
            // DoctorSpecializationRadioButton
            // 
            this.DoctorSpecializationRadioButton.AutoSize = true;
            this.DoctorSpecializationRadioButton.Location = new System.Drawing.Point(12, 148);
            this.DoctorSpecializationRadioButton.Name = "DoctorSpecializationRadioButton";
            this.DoctorSpecializationRadioButton.Size = new System.Drawing.Size(123, 24);
            this.DoctorSpecializationRadioButton.TabIndex = 11;
            this.DoctorSpecializationRadioButton.TabStop = true;
            this.DoctorSpecializationRadioButton.Text = "Specialization";
            this.DoctorSpecializationRadioButton.UseVisualStyleBackColor = true;
            this.DoctorSpecializationRadioButton.CheckedChanged += new System.EventHandler(this.DoctorSpecializationRadioButtonCheckedChanged);
            // 
            // DoctorSpecializationComboBox
            // 
            this.DoctorSpecializationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DoctorSpecializationComboBox.FormattingEnabled = true;
            this.DoctorSpecializationComboBox.Location = new System.Drawing.Point(141, 148);
            this.DoctorSpecializationComboBox.Name = "DoctorSpecializationComboBox";
            this.DoctorSpecializationComboBox.Size = new System.Drawing.Size(151, 28);
            this.DoctorSpecializationComboBox.TabIndex = 19;
            // 
            // NewAppointmentButton
            // 
            this.NewAppointmentButton.Location = new System.Drawing.Point(198, 559);
            this.NewAppointmentButton.Name = "NewAppointmentButton";
            this.NewAppointmentButton.Size = new System.Drawing.Size(94, 29);
            this.NewAppointmentButton.TabIndex = 18;
            this.NewAppointmentButton.Text = "Schedule";
            this.NewAppointmentButton.UseVisualStyleBackColor = true;
            this.NewAppointmentButton.Click += new System.EventHandler(this.NewAppointmentButtonClick);
            // 
            // DoctorSearchButton
            // 
            this.DoctorSearchButton.Location = new System.Drawing.Point(199, 197);
            this.DoctorSearchButton.Name = "DoctorSearchButton";
            this.DoctorSearchButton.Size = new System.Drawing.Size(94, 29);
            this.DoctorSearchButton.TabIndex = 17;
            this.DoctorSearchButton.Text = "Search";
            this.DoctorSearchButton.UseVisualStyleBackColor = true;
            this.DoctorSearchButton.Click += new System.EventHandler(this.DoctorSearchButtonClick);
            // 
            // DoctorSurnameTextBox
            // 
            this.DoctorSurnameTextBox.Location = new System.Drawing.Point(141, 104);
            this.DoctorSurnameTextBox.Name = "DoctorSurnameTextBox";
            this.DoctorSurnameTextBox.Size = new System.Drawing.Size(151, 27);
            this.DoctorSurnameTextBox.TabIndex = 16;
            // 
            // DoctorNameTextBox
            // 
            this.DoctorNameTextBox.Location = new System.Drawing.Point(141, 58);
            this.DoctorNameTextBox.Name = "DoctorNameTextBox";
            this.DoctorNameTextBox.Size = new System.Drawing.Size(151, 27);
            this.DoctorNameTextBox.TabIndex = 15;
            // 
            // DoctorsTable
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DoctorsTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.DoctorsTable.Location = new System.Drawing.Point(310, 25);
            this.DoctorsTable.Name = "DoctorsTable";
            this.DoctorsTable.Size = new System.Drawing.Size(592, 563);
            this.DoctorsTable.TabIndex = 20;
            this.DoctorsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoctorsTableCellClick);
            // 
            // SearchDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.DoctorsTable);
            this.Controls.Add(this.DoctorSpecializationComboBox);
            this.Controls.Add(this.NewAppointmentButton);
            this.Controls.Add(this.DoctorSearchButton);
            this.Controls.Add(this.DoctorSurnameTextBox);
            this.Controls.Add(this.DoctorNameTextBox);
            this.Controls.Add(this.DoctorNameRadioButton);
            this.Controls.Add(this.DoctorSurnameRadioButton);
            this.Controls.Add(this.DoctorSpecializationRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchDoctors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchDoctors";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.DoctorsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton DoctorNameRadioButton;
        private RadioButton DoctorSurnameRadioButton;
        private RadioButton DoctorSpecializationRadioButton;
        public ComboBox DoctorSpecializationComboBox;
        private Button NewAppointmentButton;
        private Button DoctorSearchButton;
        private TextBox DoctorSurnameTextBox;
        private TextBox DoctorNameTextBox;
        private DoctorsTable DoctorsTable;
    }
}
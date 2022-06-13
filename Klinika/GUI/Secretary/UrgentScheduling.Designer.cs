namespace Klinika.GUI.Secretary
{
    partial class UrgentScheduling
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
            this.label1 = new System.Windows.Forms.Label();
            this.patientSelection = new System.Windows.Forms.ComboBox();
            this.specializationSelection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.doctorField = new System.Windows.Forms.TextBox();
            this.appointmentSelection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient:";
            // 
            // patientSelection
            // 
            this.patientSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.patientSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patientSelection.FormattingEnabled = true;
            this.patientSelection.Location = new System.Drawing.Point(193, 54);
            this.patientSelection.Name = "patientSelection";
            this.patientSelection.Size = new System.Drawing.Size(230, 28);
            this.patientSelection.TabIndex = 1;
            // 
            // specializationSelection
            // 
            this.specializationSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.specializationSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.specializationSelection.FormattingEnabled = true;
            this.specializationSelection.Location = new System.Drawing.Point(193, 123);
            this.specializationSelection.Name = "specializationSelection";
            this.specializationSelection.Size = new System.Drawing.Size(230, 28);
            this.specializationSelection.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Doctor specialization:";
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(193, 339);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(94, 29);
            this.scheduleButton.TabIndex = 4;
            this.scheduleButton.Text = "Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.ScheduleButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Doctor:";
            // 
            // doctorField
            // 
            this.doctorField.Location = new System.Drawing.Point(193, 192);
            this.doctorField.Name = "doctorField";
            this.doctorField.ReadOnly = true;
            this.doctorField.Size = new System.Drawing.Size(230, 27);
            this.doctorField.TabIndex = 6;
            // 
            // appointmentSelection
            // 
            this.appointmentSelection.Enabled = false;
            this.appointmentSelection.FormattingEnabled = true;
            this.appointmentSelection.Location = new System.Drawing.Point(193, 262);
            this.appointmentSelection.Name = "appointmentSelection";
            this.appointmentSelection.Size = new System.Drawing.Size(230, 28);
            this.appointmentSelection.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Appointment:";
            // 
            // UrgentScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 393);
            this.Controls.Add(this.appointmentSelection);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.doctorField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.specializationSelection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patientSelection);
            this.Controls.Add(this.label1);
            this.Name = "UrgentScheduling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Urgent Scheduling";
            this.Load += new System.EventHandler(this.UrgentScheduling_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox patientSelection;
        private ComboBox specializationSelection;
        private Label label2;
        private Button scheduleButton;
        private Label label3;
        private TextBox doctorField;
        private ComboBox appointmentSelection;
        private Label label5;
    }
}
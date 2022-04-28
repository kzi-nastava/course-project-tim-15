namespace Klinika.GUI.Secretary
{
    partial class ModificationRequestDetails
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
            this.oldAppointment = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.newAppointment = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.oldDoctorField = new System.Windows.Forms.TextBox();
            this.newDoctorField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // oldAppointment
            // 
            this.oldAppointment.CustomFormat = "MM/dd/yyyy HH:mm";
            this.oldAppointment.Enabled = false;
            this.oldAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.oldAppointment.Location = new System.Drawing.Point(208, 30);
            this.oldAppointment.Name = "oldAppointment";
            this.oldAppointment.Size = new System.Drawing.Size(268, 27);
            this.oldAppointment.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Old appointment time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "New appointment time:";
            // 
            // newAppointment
            // 
            this.newAppointment.CustomFormat = "MM/dd/yyyy HH:mm";
            this.newAppointment.Enabled = false;
            this.newAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.newAppointment.Location = new System.Drawing.Point(208, 121);
            this.newAppointment.Name = "newAppointment";
            this.newAppointment.Size = new System.Drawing.Size(268, 27);
            this.newAppointment.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "New doctor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Old doctor:";
            // 
            // oldDoctorField
            // 
            this.oldDoctorField.Location = new System.Drawing.Point(208, 218);
            this.oldDoctorField.Name = "oldDoctorField";
            this.oldDoctorField.ReadOnly = true;
            this.oldDoctorField.Size = new System.Drawing.Size(268, 27);
            this.oldDoctorField.TabIndex = 10;
            // 
            // newDoctorField
            // 
            this.newDoctorField.Location = new System.Drawing.Point(208, 309);
            this.newDoctorField.Name = "newDoctorField";
            this.newDoctorField.ReadOnly = true;
            this.newDoctorField.Size = new System.Drawing.Size(268, 27);
            this.newDoctorField.TabIndex = 11;
            // 
            // ModificationRequestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 375);
            this.Controls.Add(this.newDoctorField);
            this.Controls.Add(this.oldDoctorField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oldAppointment);
            this.Name = "ModificationRequestDetails";
            this.Text = "Details";
            this.Load += new System.EventHandler(this.ModificationRequestDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker oldAppointment;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker newAppointment;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox oldDoctorField;
        private TextBox newDoctorField;
    }
}
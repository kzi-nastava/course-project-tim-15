using Klinika.Users.Models;

namespace Klinika.GUI.Patient
{
    partial class ViewSchedule
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
            this.ModifyButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PersonalAppointmentsTable = new Klinika.Forms.AppointmentsTable(User.RoleType.PATIENT);
            ((System.ComponentModel.ISupportInitialize)(this.PersonalAppointmentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(284, 417);
            this.ModifyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(82, 22);
            this.ModifyButton.TabIndex = 2;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButtonClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(414, 417);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(82, 22);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // PersonalAppointmentsTable
            // 
            this.PersonalAppointmentsTable.Location = new System.Drawing.Point(12, 11);
            this.PersonalAppointmentsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PersonalAppointmentsTable.Name = "PersonalAppointmentsTable";
            this.PersonalAppointmentsTable.Size = new System.Drawing.Size(776, 393);
            this.PersonalAppointmentsTable.TabIndex = 4;
            this.PersonalAppointmentsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PersonalAppointmentsTableCellClick);
            // 
            // ViewSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PersonalAppointmentsTable);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ModifyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewSchedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.PersonalAppointmentsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ModifyButton;
        private Button DeleteButton;
        internal Forms.AppointmentsTable PersonalAppointmentsTable;
    }
}
namespace Klinika.GUI.Doctor
{
    partial class Main
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
            this.AllAppointmetnsButton = new System.Windows.Forms.Button();
            this.ViewScheduleButton = new System.Windows.Forms.Button();
            this.UnapprovedDrugsButton = new System.Windows.Forms.Button();
            this.VacationRequestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AllAppointmetnsButton
            // 
            this.AllAppointmetnsButton.Location = new System.Drawing.Point(12, 12);
            this.AllAppointmetnsButton.Name = "AllAppointmetnsButton";
            this.AllAppointmetnsButton.Size = new System.Drawing.Size(158, 23);
            this.AllAppointmetnsButton.TabIndex = 0;
            this.AllAppointmetnsButton.Text = "View All Appointmetns";
            this.AllAppointmetnsButton.UseVisualStyleBackColor = true;
            this.AllAppointmetnsButton.Click += new System.EventHandler(this.AllAppointmetnsButton_Click);
            // 
            // ViewScheduleButton
            // 
            this.ViewScheduleButton.Location = new System.Drawing.Point(12, 41);
            this.ViewScheduleButton.Name = "ViewScheduleButton";
            this.ViewScheduleButton.Size = new System.Drawing.Size(158, 23);
            this.ViewScheduleButton.TabIndex = 1;
            this.ViewScheduleButton.Text = "View Schedule";
            this.ViewScheduleButton.UseVisualStyleBackColor = true;
            this.ViewScheduleButton.Click += new System.EventHandler(this.ViewScheduleButton_Click);
            // 
            // UnapprovedDrugsButton
            // 
            this.UnapprovedDrugsButton.Location = new System.Drawing.Point(12, 70);
            this.UnapprovedDrugsButton.Name = "UnapprovedDrugsButton";
            this.UnapprovedDrugsButton.Size = new System.Drawing.Size(158, 23);
            this.UnapprovedDrugsButton.TabIndex = 2;
            this.UnapprovedDrugsButton.Text = "Unapproved Drugs";
            this.UnapprovedDrugsButton.UseVisualStyleBackColor = true;
            this.UnapprovedDrugsButton.Click += new System.EventHandler(this.UnapprovedDrugsButton_Click);
            // 
            // VacationRequestButton
            // 
            this.VacationRequestButton.Location = new System.Drawing.Point(12, 99);
            this.VacationRequestButton.Name = "VacationRequestButton";
            this.VacationRequestButton.Size = new System.Drawing.Size(158, 23);
            this.VacationRequestButton.TabIndex = 3;
            this.VacationRequestButton.Text = "Vacation Request";
            this.VacationRequestButton.UseVisualStyleBackColor = true;
            this.VacationRequestButton.Click += new System.EventHandler(this.VacationRequestButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 138);
            this.Controls.Add(this.VacationRequestButton);
            this.Controls.Add(this.UnapprovedDrugsButton);
            this.Controls.Add(this.ViewScheduleButton);
            this.Controls.Add(this.AllAppointmetnsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Button AllAppointmetnsButton;
        private Button ViewScheduleButton;
        private Button UnapprovedDrugsButton;
        private Button VacationRequestButton;
    }
}
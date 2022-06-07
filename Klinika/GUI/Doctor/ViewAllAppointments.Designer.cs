namespace Klinika.GUI.Doctor
{
    partial class ViewAllAppointments
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
            this.EditAppointmentButton = new System.Windows.Forms.Button();
            this.DeleteAppointmentButton = new System.Windows.Forms.Button();
            this.AddAppointmentButton = new System.Windows.Forms.Button();
            this.AllAppointmentsTable = new Klinika.Forms.AppointmentsTable();
            ((System.ComponentModel.ISupportInitialize)(this.AllAppointmentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // EditAppointmentButton
            // 
            this.EditAppointmentButton.Enabled = false;
            this.EditAppointmentButton.Location = new System.Drawing.Point(12, 417);
            this.EditAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditAppointmentButton.Name = "EditAppointmentButton";
            this.EditAppointmentButton.Size = new System.Drawing.Size(82, 22);
            this.EditAppointmentButton.TabIndex = 2;
            this.EditAppointmentButton.Text = "Edit";
            this.EditAppointmentButton.UseVisualStyleBackColor = true;
            this.EditAppointmentButton.Click += new System.EventHandler(this.EditAppointmentButtonClick);
            // 
            // DeleteAppointmentButton
            // 
            this.DeleteAppointmentButton.Enabled = false;
            this.DeleteAppointmentButton.Location = new System.Drawing.Point(100, 417);
            this.DeleteAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteAppointmentButton.Name = "DeleteAppointmentButton";
            this.DeleteAppointmentButton.Size = new System.Drawing.Size(82, 22);
            this.DeleteAppointmentButton.TabIndex = 3;
            this.DeleteAppointmentButton.Text = "Delete";
            this.DeleteAppointmentButton.UseVisualStyleBackColor = true;
            this.DeleteAppointmentButton.Click += new System.EventHandler(this.DeleteAppointmentButtonClick);
            // 
            // AddAppointmentButton
            // 
            this.AddAppointmentButton.Location = new System.Drawing.Point(706, 417);
            this.AddAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddAppointmentButton.Name = "AddAppointmentButton";
            this.AddAppointmentButton.Size = new System.Drawing.Size(82, 22);
            this.AddAppointmentButton.TabIndex = 4;
            this.AddAppointmentButton.Text = "Add";
            this.AddAppointmentButton.UseVisualStyleBackColor = true;
            this.AddAppointmentButton.Click += new System.EventHandler(this.AddAppointmentButtonClick);
            // 
            // AllAppointmentsTable
            // 
            this.AllAppointmentsTable.Location = new System.Drawing.Point(12, 12);
            this.AllAppointmentsTable.Name = "AllAppointmentsTable";
            this.AllAppointmentsTable.Size = new System.Drawing.Size(776, 400);
            this.AllAppointmentsTable.TabIndex = 0;
            this.AllAppointmentsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllAppointmentsTableCellClick);
            // 
            // ViewAllAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AllAppointmentsTable);
            this.Controls.Add(this.AddAppointmentButton);
            this.Controls.Add(this.DeleteAppointmentButton);
            this.Controls.Add(this.EditAppointmentButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAllAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewAllAppointments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.AllAppointmentsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button EditAppointmentButton;
        private Button DeleteAppointmentButton;
        private Button AddAppointmentButton;
        public Klinika.Forms.AppointmentsTable AllAppointmentsTable;
    }
}
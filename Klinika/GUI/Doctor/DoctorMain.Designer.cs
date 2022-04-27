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
            this.AllAppointmentsTable = new System.Windows.Forms.DataGridView();
            this.MainTabControl.SuspendLayout();
            this.AllAppointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllAppointmentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.AllAppointmentsTab);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(940, 512);
            this.MainTabControl.TabIndex = 0;
            // 
            // AllAppointmentsTab
            // 
            this.AllAppointmentsTab.Controls.Add(this.AllAppointmentsTable);
            this.AllAppointmentsTab.Location = new System.Drawing.Point(4, 29);
            this.AllAppointmentsTab.Name = "AllAppointmentsTab";
            this.AllAppointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AllAppointmentsTab.Size = new System.Drawing.Size(932, 479);
            this.AllAppointmentsTab.TabIndex = 0;
            this.AllAppointmentsTab.Text = "All Appointments";
            this.AllAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // AllAppointmentsTable
            // 
            this.AllAppointmentsTable.AllowUserToAddRows = false;
            this.AllAppointmentsTable.AllowUserToDeleteRows = false;
            this.AllAppointmentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AllAppointmentsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.AllAppointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllAppointmentsTable.Location = new System.Drawing.Point(6, 6);
            this.AllAppointmentsTable.Name = "AllAppointmentsTable";
            this.AllAppointmentsTable.RowHeadersWidth = 51;
            this.AllAppointmentsTable.RowTemplate.Height = 29;
            this.AllAppointmentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AllAppointmentsTable.Size = new System.Drawing.Size(920, 415);
            this.AllAppointmentsTable.TabIndex = 0;
            // 
            // DoctorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 536);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoctorMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoctorMainFormClosing);
            this.Load += new System.EventHandler(this.DoctorMainLoad);
            this.MainTabControl.ResumeLayout(false);
            this.AllAppointmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllAppointmentsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MainTabControl;
        private TabPage AllAppointmentsTab;
        private DataGridView AllAppointmentsTable;
    }
}
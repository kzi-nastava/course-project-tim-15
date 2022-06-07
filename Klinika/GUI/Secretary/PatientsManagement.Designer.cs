using Klinika.Forms;
namespace Klinika.GUI.Secretary
{
    partial class PatientsManagement
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
            this.urgentSchedulingButton = new System.Windows.Forms.Button();
            this.unblockButton = new System.Windows.Forms.Button();
            this.blockButton = new System.Windows.Forms.Button();
            this.deletePatientButton = new System.Windows.Forms.Button();
            this.modifyPatientButton = new System.Windows.Forms.Button();
            this.addPatientButton = new System.Windows.Forms.Button();
            this.patientsTable = new Klinika.Forms.PatientsTable();
            ((System.ComponentModel.ISupportInitialize)(this.patientsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // urgentSchedulingButton
            // 
            this.urgentSchedulingButton.Location = new System.Drawing.Point(738, 444);
            this.urgentSchedulingButton.Name = "urgentSchedulingButton";
            this.urgentSchedulingButton.Size = new System.Drawing.Size(152, 29);
            this.urgentSchedulingButton.TabIndex = 13;
            this.urgentSchedulingButton.Text = "Urgent scheduling";
            this.urgentSchedulingButton.UseVisualStyleBackColor = true;
            this.urgentSchedulingButton.Click += new System.EventHandler(this.UrgentSchedulingButton_Click);
            // 
            // unblockButton
            // 
            this.unblockButton.Enabled = false;
            this.unblockButton.Location = new System.Drawing.Point(609, 444);
            this.unblockButton.Name = "unblockButton";
            this.unblockButton.Size = new System.Drawing.Size(94, 29);
            this.unblockButton.TabIndex = 12;
            this.unblockButton.Text = "Unblock";
            this.unblockButton.UseVisualStyleBackColor = true;
            this.unblockButton.Click += new System.EventHandler(this.UnblockButton_Click);
            // 
            // blockButton
            // 
            this.blockButton.Enabled = false;
            this.blockButton.Location = new System.Drawing.Point(477, 444);
            this.blockButton.Name = "blockButton";
            this.blockButton.Size = new System.Drawing.Size(94, 29);
            this.blockButton.TabIndex = 11;
            this.blockButton.Text = "Block";
            this.blockButton.UseVisualStyleBackColor = true;
            this.blockButton.Click += new System.EventHandler(this.BlockButton_Click);
            // 
            // deletePatientButton
            // 
            this.deletePatientButton.Enabled = false;
            this.deletePatientButton.Location = new System.Drawing.Point(345, 444);
            this.deletePatientButton.Name = "deletePatientButton";
            this.deletePatientButton.Size = new System.Drawing.Size(94, 29);
            this.deletePatientButton.TabIndex = 10;
            this.deletePatientButton.Text = "Delete";
            this.deletePatientButton.UseVisualStyleBackColor = true;
            this.deletePatientButton.Click += new System.EventHandler(this.DeletePatientButton_Click);
            // 
            // modifyPatientButton
            // 
            this.modifyPatientButton.Enabled = false;
            this.modifyPatientButton.Location = new System.Drawing.Point(213, 444);
            this.modifyPatientButton.Name = "modifyPatientButton";
            this.modifyPatientButton.Size = new System.Drawing.Size(94, 29);
            this.modifyPatientButton.TabIndex = 9;
            this.modifyPatientButton.Text = "Modify";
            this.modifyPatientButton.UseVisualStyleBackColor = true;
            this.modifyPatientButton.Click += new System.EventHandler(this.ModifyPatientButton_Click);
            // 
            // addPatientButton
            // 
            this.addPatientButton.Location = new System.Drawing.Point(81, 444);
            this.addPatientButton.Name = "addPatientButton";
            this.addPatientButton.Size = new System.Drawing.Size(94, 29);
            this.addPatientButton.TabIndex = 8;
            this.addPatientButton.Text = "Add new";
            this.addPatientButton.UseVisualStyleBackColor = true;
            this.addPatientButton.Click += new System.EventHandler(this.AddPatientButton_Click);
            // 
            // patientsTable
            // 
            this.patientsTable.AllowUserToAddRows = false;
            this.patientsTable.AllowUserToDeleteRows = false;
            this.patientsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.patientsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.patientsTable.BackgroundColor = System.Drawing.Color.White;
            this.patientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientsTable.Location = new System.Drawing.Point(23, 20);
            this.patientsTable.MultiSelect = false;
            this.patientsTable.Name = "patientsTable";
            this.patientsTable.ReadOnly = true;
            this.patientsTable.RowHeadersWidth = 51;
            this.patientsTable.RowTemplate.Height = 30;
            this.patientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patientsTable.Size = new System.Drawing.Size(927, 387);
            this.patientsTable.TabIndex = 14;
            this.patientsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PatientsTable_CellClick);
            // 
            // PatientsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 494);
            this.Controls.Add(this.patientsTable);
            this.Controls.Add(this.urgentSchedulingButton);
            this.Controls.Add(this.unblockButton);
            this.Controls.Add(this.blockButton);
            this.Controls.Add(this.deletePatientButton);
            this.Controls.Add(this.modifyPatientButton);
            this.Controls.Add(this.addPatientButton);
            this.Name = "PatientsManagement";
            this.Text = "Patients Management";
            this.Load += new System.EventHandler(this.PatientsManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.patientsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button urgentSchedulingButton;
        private Button unblockButton;
        private Button blockButton;
        private Button deletePatientButton;
        private Button modifyPatientButton;
        private Button addPatientButton;
        private PatientsTable patientsTable;
    }
}
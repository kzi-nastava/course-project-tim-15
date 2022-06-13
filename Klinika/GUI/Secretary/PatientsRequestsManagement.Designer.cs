using Klinika.Forms;
namespace Klinika.GUI.Secretary
{
    partial class PatientsRequestsManagement
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
            this.denyButton = new System.Windows.Forms.Button();
            this.approveButton = new System.Windows.Forms.Button();
            this.detailsButton = new System.Windows.Forms.Button();
            this.requestsTable = new Klinika.Forms.PatientsRequestsTable();
            ((System.ComponentModel.ISupportInitialize)(this.requestsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // denyButton
            // 
            this.denyButton.Enabled = false;
            this.denyButton.Location = new System.Drawing.Point(542, 434);
            this.denyButton.Name = "denyButton";
            this.denyButton.Size = new System.Drawing.Size(94, 29);
            this.denyButton.TabIndex = 13;
            this.denyButton.Text = "Deny";
            this.denyButton.UseVisualStyleBackColor = true;
            this.denyButton.Click += new System.EventHandler(this.DenyButton_Click);
            // 
            // approveButton
            // 
            this.approveButton.Enabled = false;
            this.approveButton.Location = new System.Drawing.Point(410, 434);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(94, 29);
            this.approveButton.TabIndex = 12;
            this.approveButton.Text = "Approve";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            // 
            // detailsButton
            // 
            this.detailsButton.Enabled = false;
            this.detailsButton.Location = new System.Drawing.Point(278, 434);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(94, 29);
            this.detailsButton.TabIndex = 11;
            this.detailsButton.Text = "Details";
            this.detailsButton.UseVisualStyleBackColor = true;
            this.detailsButton.Click += new System.EventHandler(this.DetailsButton_Click);
            // 
            // patientsRequestsTable
            // 
            this.requestsTable.AllowUserToAddRows = false;
            this.requestsTable.AllowUserToDeleteRows = false;
            this.requestsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.requestsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.requestsTable.BackgroundColor = System.Drawing.Color.White;
            this.requestsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsTable.Location = new System.Drawing.Point(17, 16);
            this.requestsTable.MultiSelect = false;
            this.requestsTable.Name = "patientsRequestsTable";
            this.requestsTable.ReadOnly = true;
            this.requestsTable.RowHeadersWidth = 51;
            this.requestsTable.RowTemplate.Height = 30;
            this.requestsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.requestsTable.Size = new System.Drawing.Size(936, 391);
            this.requestsTable.TabIndex = 14;
            // 
            // PatientsRequestsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 480);
            this.Controls.Add(this.requestsTable);
            this.Controls.Add(this.denyButton);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.detailsButton);
            this.Name = "PatientsRequestsManagement";
            this.Text = "Patients Requests Management";
            this.Load += new System.EventHandler(this.PatientsRequestsManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.requestsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button denyButton;
        private Button approveButton;
        private Button detailsButton;
        private PatientsRequestsTable requestsTable;
    }
}
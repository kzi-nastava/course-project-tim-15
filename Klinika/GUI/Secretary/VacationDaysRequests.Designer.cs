namespace Klinika.GUI.Secretary
{
    partial class VacationDaysRequests
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
            this.approveButton = new System.Windows.Forms.Button();
            this.denyButton = new System.Windows.Forms.Button();
            this.vacationRequestsTable = new Klinika.Forms.VacationRequestsTable(showDoctor: true);
            ((System.ComponentModel.ISupportInitialize)(this.vacationRequestsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // approveButton
            // 
            this.approveButton.Enabled = false;
            this.approveButton.Location = new System.Drawing.Point(345, 414);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(94, 29);
            this.approveButton.TabIndex = 1;
            this.approveButton.Text = "Approve";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            // 
            // denyButton
            // 
            this.denyButton.Enabled = false;
            this.denyButton.Location = new System.Drawing.Point(481, 414);
            this.denyButton.Name = "denyButton";
            this.denyButton.Size = new System.Drawing.Size(94, 29);
            this.denyButton.TabIndex = 2;
            this.denyButton.Text = "Deny";
            this.denyButton.UseVisualStyleBackColor = true;
            this.denyButton.Click += new System.EventHandler(this.DenyButton_Click);
            // 
            // vacationRequestsTable
            // 
            this.vacationRequestsTable.AllowUserToAddRows = false;
            this.vacationRequestsTable.AllowUserToDeleteRows = false;
            this.vacationRequestsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vacationRequestsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.vacationRequestsTable.BackgroundColor = System.Drawing.Color.White;
            this.vacationRequestsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vacationRequestsTable.Location = new System.Drawing.Point(21, 12);
            this.vacationRequestsTable.MultiSelect = false;
            this.vacationRequestsTable.Name = "vacationRequestsTable";
            this.vacationRequestsTable.ReadOnly = true;
            this.vacationRequestsTable.RowHeadersWidth = 51;
            this.vacationRequestsTable.RowTemplate.Height = 30;
            this.vacationRequestsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vacationRequestsTable.Size = new System.Drawing.Size(881, 375);
            this.vacationRequestsTable.TabIndex = 3;
            this.vacationRequestsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VacationRequestsTable_CellClick);
            // 
            // VacationDaysRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 476);
            this.Controls.Add(this.vacationRequestsTable);
            this.Controls.Add(this.denyButton);
            this.Controls.Add(this.approveButton);
            this.Name = "VacationDaysRequests";
            this.Text = "Vacation Days Requests";
            this.Load += new System.EventHandler(this.VacationDaysRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vacationRequestsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button approveButton;
        private Button denyButton;
        private Forms.VacationRequestsTable vacationRequestsTable;
    }
}
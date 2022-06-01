namespace Klinika.GUI.Doctor
{
    partial class ManageUnapprovedDrugs
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
            this.DenyDrugButton = new System.Windows.Forms.Button();
            this.ApproveDrugButton = new System.Windows.Forms.Button();
            this.DenyDrugDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UnapprovedDrugsTable = new Klinika.Forms.DrugsDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.UnapprovedDrugsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DenyDrugButton
            // 
            this.DenyDrugButton.Location = new System.Drawing.Point(12, 130);
            this.DenyDrugButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DenyDrugButton.Name = "DenyDrugButton";
            this.DenyDrugButton.Size = new System.Drawing.Size(82, 22);
            this.DenyDrugButton.TabIndex = 11;
            this.DenyDrugButton.Text = "Deny";
            this.DenyDrugButton.UseVisualStyleBackColor = true;
            this.DenyDrugButton.Click += new System.EventHandler(this.DenyDrugButtonClick);
            // 
            // ApproveDrugButton
            // 
            this.ApproveDrugButton.Location = new System.Drawing.Point(100, 130);
            this.ApproveDrugButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ApproveDrugButton.Name = "ApproveDrugButton";
            this.ApproveDrugButton.Size = new System.Drawing.Size(82, 22);
            this.ApproveDrugButton.TabIndex = 10;
            this.ApproveDrugButton.Text = "Approve";
            this.ApproveDrugButton.UseVisualStyleBackColor = true;
            this.ApproveDrugButton.Click += new System.EventHandler(this.ApproveDrugButtonClick);
            // 
            // DenyDrugDescription
            // 
            this.DenyDrugDescription.Location = new System.Drawing.Point(12, 26);
            this.DenyDrugDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DenyDrugDescription.Multiline = true;
            this.DenyDrugDescription.Name = "DenyDrugDescription";
            this.DenyDrugDescription.Size = new System.Drawing.Size(234, 100);
            this.DenyDrugDescription.TabIndex = 9;
            this.DenyDrugDescription.TextChanged += new System.EventHandler(this.DenyDrugDescriptionTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Description";
            // 
            // UnapprovedDrugsTable
            // 
            this.UnapprovedDrugsTable.AllowUserToAddRows = false;
            this.UnapprovedDrugsTable.AllowUserToDeleteRows = false;
            this.UnapprovedDrugsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UnapprovedDrugsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.UnapprovedDrugsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.UnapprovedDrugsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnapprovedDrugsTable.GridColor = System.Drawing.SystemColors.Control;
            this.UnapprovedDrugsTable.Location = new System.Drawing.Point(252, 26);
            this.UnapprovedDrugsTable.Name = "UnapprovedDrugsTable";
            this.UnapprovedDrugsTable.ReadOnly = true;
            this.UnapprovedDrugsTable.RowHeadersWidth = 51;
            this.UnapprovedDrugsTable.RowTemplate.Height = 25;
            this.UnapprovedDrugsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UnapprovedDrugsTable.Size = new System.Drawing.Size(536, 412);
            this.UnapprovedDrugsTable.TabIndex = 7;
            this.UnapprovedDrugsTable.SelectionChanged += new System.EventHandler(this.UnapprovedDrugsTableSelectionChanged);
            // 
            // ManageUnapprovedDrugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DenyDrugButton);
            this.Controls.Add(this.ApproveDrugButton);
            this.Controls.Add(this.DenyDrugDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UnapprovedDrugsTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageUnapprovedDrugs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageUnapprovedDrugs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageUnapprovedDrugs_FormClosing);
            this.Load += new System.EventHandler(this.ManageUnapprovedDrugs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UnapprovedDrugsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button DenyDrugButton;
        private Button ApproveDrugButton;
        private TextBox DenyDrugDescription;
        private Label label1;
        internal Forms.DrugsDataGridView UnapprovedDrugsTable;
    }
}
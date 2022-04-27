namespace Klinika.GUI.Secretary
{
    partial class mainWindow
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
            this.patients = new System.Windows.Forms.TabPage();
            this.unblockButton = new System.Windows.Forms.Button();
            this.blockButton = new System.Windows.Forms.Button();
            this.deletePatientButton = new System.Windows.Forms.Button();
            this.updatePatientButton = new System.Windows.Forms.Button();
            this.addPatientButton = new System.Windows.Forms.Button();
            this.patientsTable = new System.Windows.Forms.DataGridView();
            this.tabs = new System.Windows.Forms.TabControl();
            this.modificationRequests = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.detailsButton = new System.Windows.Forms.Button();
            this.requestsTable = new System.Windows.Forms.DataGridView();
            this.denyButton = new System.Windows.Forms.Button();
            this.patients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientsTable)).BeginInit();
            this.tabs.SuspendLayout();
            this.modificationRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // patients
            // 
            this.patients.Controls.Add(this.unblockButton);
            this.patients.Controls.Add(this.blockButton);
            this.patients.Controls.Add(this.deletePatientButton);
            this.patients.Controls.Add(this.updatePatientButton);
            this.patients.Controls.Add(this.addPatientButton);
            this.patients.Controls.Add(this.patientsTable);
            this.patients.Location = new System.Drawing.Point(4, 29);
            this.patients.Name = "patients";
            this.patients.Padding = new System.Windows.Forms.Padding(3);
            this.patients.Size = new System.Drawing.Size(946, 487);
            this.patients.TabIndex = 0;
            this.patients.Text = "Patients";
            this.patients.UseVisualStyleBackColor = true;
            // 
            // unblockButton
            // 
            this.unblockButton.Enabled = false;
            this.unblockButton.Location = new System.Drawing.Point(683, 429);
            this.unblockButton.Name = "unblockButton";
            this.unblockButton.Size = new System.Drawing.Size(94, 29);
            this.unblockButton.TabIndex = 5;
            this.unblockButton.Text = "Unblock";
            this.unblockButton.UseVisualStyleBackColor = true;
            this.unblockButton.Click += new System.EventHandler(this.unblockButton_Click);
            // 
            // blockButton
            // 
            this.blockButton.Enabled = false;
            this.blockButton.Location = new System.Drawing.Point(551, 429);
            this.blockButton.Name = "blockButton";
            this.blockButton.Size = new System.Drawing.Size(94, 29);
            this.blockButton.TabIndex = 4;
            this.blockButton.Text = "Block";
            this.blockButton.UseVisualStyleBackColor = true;
            this.blockButton.Click += new System.EventHandler(this.blockButton_Click);
            // 
            // deletePatientButton
            // 
            this.deletePatientButton.Enabled = false;
            this.deletePatientButton.Location = new System.Drawing.Point(419, 429);
            this.deletePatientButton.Name = "deletePatientButton";
            this.deletePatientButton.Size = new System.Drawing.Size(94, 29);
            this.deletePatientButton.TabIndex = 3;
            this.deletePatientButton.Text = "Delete";
            this.deletePatientButton.UseVisualStyleBackColor = true;
            this.deletePatientButton.Click += new System.EventHandler(this.deletePatientButton_Click);
            // 
            // updatePatientButton
            // 
            this.updatePatientButton.Enabled = false;
            this.updatePatientButton.Location = new System.Drawing.Point(287, 429);
            this.updatePatientButton.Name = "updatePatientButton";
            this.updatePatientButton.Size = new System.Drawing.Size(94, 29);
            this.updatePatientButton.TabIndex = 2;
            this.updatePatientButton.Text = "Modify";
            this.updatePatientButton.UseVisualStyleBackColor = true;
            this.updatePatientButton.Click += new System.EventHandler(this.updatePatientButton_Click);
            // 
            // addPatientButton
            // 
            this.addPatientButton.Location = new System.Drawing.Point(155, 429);
            this.addPatientButton.Name = "addPatientButton";
            this.addPatientButton.Size = new System.Drawing.Size(94, 29);
            this.addPatientButton.TabIndex = 1;
            this.addPatientButton.Text = "Add new";
            this.addPatientButton.UseVisualStyleBackColor = true;
            this.addPatientButton.Click += new System.EventHandler(this.addPatientButton_Click);
            // 
            // patientsTable
            // 
            this.patientsTable.AllowUserToAddRows = false;
            this.patientsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.patientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientsTable.Location = new System.Drawing.Point(0, 0);
            this.patientsTable.MultiSelect = false;
            this.patientsTable.Name = "patientsTable";
            this.patientsTable.RowHeadersWidth = 51;
            this.patientsTable.RowTemplate.Height = 29;
            this.patientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patientsTable.Size = new System.Drawing.Size(946, 401);
            this.patientsTable.TabIndex = 0;
            this.patientsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.patientsTable_CellClick);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.patients);
            this.tabs.Controls.Add(this.modificationRequests);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Location = new System.Drawing.Point(12, 21);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(954, 520);
            this.tabs.TabIndex = 3;
            // 
            // modificationRequests
            // 
            this.modificationRequests.Controls.Add(this.denyButton);
            this.modificationRequests.Controls.Add(this.button4);
            this.modificationRequests.Controls.Add(this.detailsButton);
            this.modificationRequests.Controls.Add(this.requestsTable);
            this.modificationRequests.Location = new System.Drawing.Point(4, 29);
            this.modificationRequests.Name = "modificationRequests";
            this.modificationRequests.Padding = new System.Windows.Forms.Padding(3);
            this.modificationRequests.Size = new System.Drawing.Size(946, 487);
            this.modificationRequests.TabIndex = 1;
            this.modificationRequests.Text = "Requests";
            this.modificationRequests.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(946, 487);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(417, 437);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 8;
            this.button4.Text = "Allow";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // detailsButton
            // 
            this.detailsButton.Enabled = false;
            this.detailsButton.Location = new System.Drawing.Point(285, 437);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(94, 29);
            this.detailsButton.TabIndex = 7;
            this.detailsButton.Text = "Details";
            this.detailsButton.UseVisualStyleBackColor = true;
            // 
            // requestsTable
            // 
            this.requestsTable.AllowUserToAddRows = false;
            this.requestsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.requestsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsTable.Location = new System.Drawing.Point(0, 14);
            this.requestsTable.MultiSelect = false;
            this.requestsTable.Name = "requestsTable";
            this.requestsTable.RowHeadersWidth = 51;
            this.requestsTable.RowTemplate.Height = 29;
            this.requestsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.requestsTable.Size = new System.Drawing.Size(946, 401);
            this.requestsTable.TabIndex = 6;
            // 
            // denyButton
            // 
            this.denyButton.Enabled = false;
            this.denyButton.Location = new System.Drawing.Point(549, 437);
            this.denyButton.Name = "denyButton";
            this.denyButton.Size = new System.Drawing.Size(94, 29);
            this.denyButton.TabIndex = 9;
            this.denyButton.Text = "Deny";
            this.denyButton.UseVisualStyleBackColor = true;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 560);
            this.Controls.Add(this.tabs);
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secretary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.patients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientsTable)).EndInit();
            this.tabs.ResumeLayout(false);
            this.modificationRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requestsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage patients;
        private Button deletePatientButton;
        private Button updatePatientButton;
        private Button addPatientButton;
        private TabControl tabs;
        private TabPage modificationRequests;
        private TabPage tabPage3;
        public DataGridView patientsTable;
        private Button unblockButton;
        private Button blockButton;
        private Button denyButton;
        private Button button4;
        private Button detailsButton;
        public DataGridView requestsTable;
    }
}
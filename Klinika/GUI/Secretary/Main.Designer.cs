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
            this.dynamicEquipmentTransfers = new System.Windows.Forms.TabPage();
            this.lowStockDynamicEquipmentTable = new System.Windows.Forms.DataGridView();
            this.getFromButton = new System.Windows.Forms.Button();
            this.dynamicEquipmentRequests = new System.Windows.Forms.TabPage();
            this.dynamicEquipmentTable = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.quantityPicker = new System.Windows.Forms.NumericUpDown();
            this.orderButton = new System.Windows.Forms.Button();
            this.referrals = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.patientSelection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.refferalTabDoctorField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.appointmentPicker = new System.Windows.Forms.DateTimePicker();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.findAvailableDoctorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.specializationField = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.dynamicEquipmentTransfers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowStockDynamicEquipmentTable)).BeginInit();
            this.dynamicEquipmentRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicEquipmentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityPicker)).BeginInit();
            this.referrals.SuspendLayout();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // dynamicEquipmentTransfers
            // 
            this.dynamicEquipmentTransfers.Controls.Add(this.getFromButton);
            this.dynamicEquipmentTransfers.Controls.Add(this.lowStockDynamicEquipmentTable);
            this.dynamicEquipmentTransfers.Location = new System.Drawing.Point(4, 29);
            this.dynamicEquipmentTransfers.Name = "dynamicEquipmentTransfers";
            this.dynamicEquipmentTransfers.Padding = new System.Windows.Forms.Padding(3);
            this.dynamicEquipmentTransfers.Size = new System.Drawing.Size(946, 487);
            this.dynamicEquipmentTransfers.TabIndex = 4;
            this.dynamicEquipmentTransfers.Text = "Dynamic equipment transfers";
            this.dynamicEquipmentTransfers.UseVisualStyleBackColor = true;
            // 
            // lowStockDynamicEquipmentTable
            // 
            this.lowStockDynamicEquipmentTable.AllowUserToAddRows = false;
            this.lowStockDynamicEquipmentTable.AllowUserToDeleteRows = false;
            this.lowStockDynamicEquipmentTable.AllowUserToOrderColumns = true;
            this.lowStockDynamicEquipmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lowStockDynamicEquipmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lowStockDynamicEquipmentTable.Location = new System.Drawing.Point(3, 3);
            this.lowStockDynamicEquipmentTable.MultiSelect = false;
            this.lowStockDynamicEquipmentTable.Name = "lowStockDynamicEquipmentTable";
            this.lowStockDynamicEquipmentTable.ReadOnly = true;
            this.lowStockDynamicEquipmentTable.RowHeadersWidth = 51;
            this.lowStockDynamicEquipmentTable.RowTemplate.Height = 29;
            this.lowStockDynamicEquipmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lowStockDynamicEquipmentTable.Size = new System.Drawing.Size(940, 397);
            this.lowStockDynamicEquipmentTable.TabIndex = 8;
            this.lowStockDynamicEquipmentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lowStockDynamicEquipmentTable_CellClick);
            // 
            // getFromButton
            // 
            this.getFromButton.Enabled = false;
            this.getFromButton.Location = new System.Drawing.Point(349, 430);
            this.getFromButton.Name = "getFromButton";
            this.getFromButton.Size = new System.Drawing.Size(209, 29);
            this.getFromButton.TabIndex = 9;
            this.getFromButton.Text = "Get from room/storage";
            this.getFromButton.UseVisualStyleBackColor = true;
            this.getFromButton.Click += new System.EventHandler(this.getFromButton_Click);
            // 
            // dynamicEquipmentRequests
            // 
            this.dynamicEquipmentRequests.Controls.Add(this.orderButton);
            this.dynamicEquipmentRequests.Controls.Add(this.quantityPicker);
            this.dynamicEquipmentRequests.Controls.Add(this.label5);
            this.dynamicEquipmentRequests.Controls.Add(this.dynamicEquipmentTable);
            this.dynamicEquipmentRequests.Location = new System.Drawing.Point(4, 29);
            this.dynamicEquipmentRequests.Name = "dynamicEquipmentRequests";
            this.dynamicEquipmentRequests.Padding = new System.Windows.Forms.Padding(3);
            this.dynamicEquipmentRequests.Size = new System.Drawing.Size(946, 487);
            this.dynamicEquipmentRequests.TabIndex = 3;
            this.dynamicEquipmentRequests.Text = "Dynamic equipment ordering";
            this.dynamicEquipmentRequests.UseVisualStyleBackColor = true;
            // 
            // dynamicEquipmentTable
            // 
            this.dynamicEquipmentTable.AllowUserToAddRows = false;
            this.dynamicEquipmentTable.AllowUserToDeleteRows = false;
            this.dynamicEquipmentTable.AllowUserToOrderColumns = true;
            this.dynamicEquipmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dynamicEquipmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dynamicEquipmentTable.Location = new System.Drawing.Point(3, 5);
            this.dynamicEquipmentTable.MultiSelect = false;
            this.dynamicEquipmentTable.Name = "dynamicEquipmentTable";
            this.dynamicEquipmentTable.ReadOnly = true;
            this.dynamicEquipmentTable.RowHeadersWidth = 51;
            this.dynamicEquipmentTable.RowTemplate.Height = 29;
            this.dynamicEquipmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dynamicEquipmentTable.Size = new System.Drawing.Size(940, 367);
            this.dynamicEquipmentTable.TabIndex = 7;
            this.dynamicEquipmentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dynamicEquipmentTable_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Quantity: ";
            // 
            // quantityPicker
            // 
            this.quantityPicker.Enabled = false;
            this.quantityPicker.Location = new System.Drawing.Point(249, 414);
            this.quantityPicker.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.quantityPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityPicker.Name = "quantityPicker";
            this.quantityPicker.Size = new System.Drawing.Size(226, 27);
            this.quantityPicker.TabIndex = 9;
            this.quantityPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // orderButton
            // 
            this.orderButton.Enabled = false;
            this.orderButton.Location = new System.Drawing.Point(578, 413);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(94, 29);
            this.orderButton.TabIndex = 10;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // referrals
            // 
            this.referrals.Controls.Add(this.specializationField);
            this.referrals.Controls.Add(this.refferalTabDoctorField);
            this.referrals.Controls.Add(this.label4);
            this.referrals.Controls.Add(this.findAvailableDoctorButton);
            this.referrals.Controls.Add(this.scheduleButton);
            this.referrals.Controls.Add(this.appointmentPicker);
            this.referrals.Controls.Add(this.label3);
            this.referrals.Controls.Add(this.label2);
            this.referrals.Controls.Add(this.patientSelection);
            this.referrals.Controls.Add(this.label1);
            this.referrals.Location = new System.Drawing.Point(4, 29);
            this.referrals.Name = "referrals";
            this.referrals.Padding = new System.Windows.Forms.Padding(3);
            this.referrals.Size = new System.Drawing.Size(946, 487);
            this.referrals.TabIndex = 2;
            this.referrals.Text = "Referrals";
            this.referrals.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient:";
            // 
            // patientSelection
            // 
            this.patientSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.patientSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patientSelection.FormattingEnabled = true;
            this.patientSelection.Location = new System.Drawing.Point(160, 139);
            this.patientSelection.Name = "patientSelection";
            this.patientSelection.Size = new System.Drawing.Size(247, 28);
            this.patientSelection.TabIndex = 1;
            this.patientSelection.SelectedIndexChanged += new System.EventHandler(this.patientSelection_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Doctor:";
            // 
            // refferalTabDoctorField
            // 
            this.refferalTabDoctorField.Location = new System.Drawing.Point(597, 140);
            this.refferalTabDoctorField.Name = "refferalTabDoctorField";
            this.refferalTabDoctorField.ReadOnly = true;
            this.refferalTabDoctorField.Size = new System.Drawing.Size(246, 27);
            this.refferalTabDoctorField.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time:";
            // 
            // appointmentPicker
            // 
            this.appointmentPicker.CustomFormat = "MM/dd/yyyy HH:mm";
            this.appointmentPicker.Enabled = false;
            this.appointmentPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.appointmentPicker.Location = new System.Drawing.Point(157, 224);
            this.appointmentPicker.Name = "appointmentPicker";
            this.appointmentPicker.Size = new System.Drawing.Size(250, 27);
            this.appointmentPicker.TabIndex = 5;
            this.appointmentPicker.Value = new System.DateTime(2022, 5, 12, 18, 34, 29, 0);
            // 
            // scheduleButton
            // 
            this.scheduleButton.Enabled = false;
            this.scheduleButton.Location = new System.Drawing.Point(534, 413);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(94, 29);
            this.scheduleButton.TabIndex = 8;
            this.scheduleButton.Text = "Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // findAvailableDoctorButton
            // 
            this.findAvailableDoctorButton.Enabled = false;
            this.findAvailableDoctorButton.Location = new System.Drawing.Point(288, 413);
            this.findAvailableDoctorButton.Name = "findAvailableDoctorButton";
            this.findAvailableDoctorButton.Size = new System.Drawing.Size(208, 29);
            this.findAvailableDoctorButton.TabIndex = 9;
            this.findAvailableDoctorButton.Text = "Find available doctor";
            this.findAvailableDoctorButton.UseVisualStyleBackColor = true;
            this.findAvailableDoctorButton.Click += new System.EventHandler(this.findAvailableDoctorButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(486, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Specialization:";
            // 
            // specializationField
            // 
            this.specializationField.Location = new System.Drawing.Point(597, 222);
            this.specializationField.Name = "specializationField";
            this.specializationField.ReadOnly = true;
            this.specializationField.Size = new System.Drawing.Size(246, 27);
            this.specializationField.TabIndex = 11;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.referrals);
            this.tabs.Controls.Add(this.dynamicEquipmentRequests);
            this.tabs.Controls.Add(this.dynamicEquipmentTransfers);
            this.tabs.Location = new System.Drawing.Point(12, 21);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(954, 520);
            this.tabs.TabIndex = 3;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
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
            this.dynamicEquipmentTransfers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lowStockDynamicEquipmentTable)).EndInit();
            this.dynamicEquipmentRequests.ResumeLayout(false);
            this.dynamicEquipmentRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicEquipmentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityPicker)).EndInit();
            this.referrals.ResumeLayout(false);
            this.referrals.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage dynamicEquipmentTransfers;
        private Button getFromButton;
        public DataGridView lowStockDynamicEquipmentTable;
        private TabPage dynamicEquipmentRequests;
        private Button orderButton;
        private NumericUpDown quantityPicker;
        private Label label5;
        public DataGridView dynamicEquipmentTable;
        private TabPage referrals;
        public TextBox specializationField;
        public TextBox refferalTabDoctorField;
        private Label label4;
        public Button findAvailableDoctorButton;
        public Button scheduleButton;
        public DateTimePicker appointmentPicker;
        private Label label3;
        private Label label2;
        public ComboBox patientSelection;
        private Label label1;
        private TabControl tabs;
    }
}
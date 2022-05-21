namespace Klinika.GUI.Doctor
{
    partial class PrescriptionIssuing
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IntervalSpinner = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PrescriptionEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.PrescriptionStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.DrugsTable = new Klinika.Forms.DrugsDataGridView();
            this.PrescriptButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrugsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CommentTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.IntervalSpinner);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PrescriptionEndDatePicker);
            this.groupBox1.Controls.Add(this.PrescriptionStartDatePicker);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instuctions";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hours";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(89, 112);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(229, 55);
            this.CommentTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // IntervalSpinner
            // 
            this.IntervalSpinner.Location = new System.Drawing.Point(89, 80);
            this.IntervalSpinner.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.IntervalSpinner.Name = "IntervalSpinner";
            this.IntervalSpinner.Size = new System.Drawing.Size(120, 23);
            this.IntervalSpinner.TabIndex = 5;
            this.IntervalSpinner.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // PrescriptionEndDatePicker
            // 
            this.PrescriptionEndDatePicker.Location = new System.Drawing.Point(89, 51);
            this.PrescriptionEndDatePicker.Name = "PrescriptionEndDatePicker";
            this.PrescriptionEndDatePicker.Size = new System.Drawing.Size(229, 23);
            this.PrescriptionEndDatePicker.TabIndex = 1;
            // 
            // PrescriptionStartDatePicker
            // 
            this.PrescriptionStartDatePicker.Location = new System.Drawing.Point(89, 22);
            this.PrescriptionStartDatePicker.Name = "PrescriptionStartDatePicker";
            this.PrescriptionStartDatePicker.Size = new System.Drawing.Size(229, 23);
            this.PrescriptionStartDatePicker.TabIndex = 0;
            // 
            // DrugsTable
            // 
            this.DrugsTable.AllowUserToAddRows = false;
            this.DrugsTable.AllowUserToDeleteRows = false;
            this.DrugsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DrugsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DrugsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DrugsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DrugsTable.GridColor = System.Drawing.SystemColors.Control;
            this.DrugsTable.Location = new System.Drawing.Point(12, 204);
            this.DrugsTable.Name = "DrugsTable";
            this.DrugsTable.ReadOnly = true;
            this.DrugsTable.RowTemplate.Height = 25;
            this.DrugsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DrugsTable.Size = new System.Drawing.Size(336, 359);
            this.DrugsTable.TabIndex = 1;
            // 
            // PrescriptButton
            // 
            this.PrescriptButton.Location = new System.Drawing.Point(273, 569);
            this.PrescriptButton.Name = "PrescriptButton";
            this.PrescriptButton.Size = new System.Drawing.Size(75, 23);
            this.PrescriptButton.TabIndex = 2;
            this.PrescriptButton.Text = "Prescript";
            this.PrescriptButton.UseVisualStyleBackColor = true;
            this.PrescriptButton.Click += new System.EventHandler(this.PrescriptButtonClick);
            // 
            // PrescriptionIssuing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 602);
            this.Controls.Add(this.PrescriptButton);
            this.Controls.Add(this.DrugsTable);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrescriptionIssuing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prescription Issuing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrugsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        internal DateTimePicker PrescriptionEndDatePicker;
        internal DateTimePicker PrescriptionStartDatePicker;
        internal NumericUpDown IntervalSpinner;
        private Label label3;
        internal TextBox CommentTextBox;
        private Label label4;
        internal Klinika.Forms.DrugsDataGridView DrugsTable;
        private Button PrescriptButton;
        private Label label5;
    }
}
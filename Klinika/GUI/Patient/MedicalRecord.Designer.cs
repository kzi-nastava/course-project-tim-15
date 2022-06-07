using Klinika.Forms;

namespace Klinika.GUI.Patient
{
    partial class MedicalRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MedicalRecordTable = new Klinika.Forms.MedicalRecordTable();
            this.GradeDoctorButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MedicalRecordTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MedicalRecordTable
            // 
            this.MedicalRecordTable.AllowUserToAddRows = false;
            this.MedicalRecordTable.AllowUserToDeleteRows = false;
            this.MedicalRecordTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MedicalRecordTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MedicalRecordTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.MedicalRecordTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MedicalRecordTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.MedicalRecordTable.Location = new System.Drawing.Point(12, 12);
            this.MedicalRecordTable.Name = "MedicalRecordTable";
            this.MedicalRecordTable.ReadOnly = true;
            this.MedicalRecordTable.RowHeadersWidth = 51;
            this.MedicalRecordTable.RowTemplate.Height = 29;
            this.MedicalRecordTable.Size = new System.Drawing.Size(890, 527);
            this.MedicalRecordTable.TabIndex = 1;
            // 
            // GradeDoctorButton
            // 
            this.GradeDoctorButton.Location = new System.Drawing.Point(687, 555);
            this.GradeDoctorButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GradeDoctorButton.Name = "GradeDoctorButton";
            this.GradeDoctorButton.Size = new System.Drawing.Size(115, 31);
            this.GradeDoctorButton.TabIndex = 10;
            this.GradeDoctorButton.Text = "Grade doctor";
            this.GradeDoctorButton.UseVisualStyleBackColor = true;
            this.GradeDoctorButton.Click += new System.EventHandler(this.GradeDoctorButtonClick);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(808, 555);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(94, 31);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButtonClick);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(414, 557);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(94, 29);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(190, 559);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(218, 27);
            this.SearchTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 559);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Keyword for Anamnesis: ";
            // 
            // MedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.GradeDoctorButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MedicalRecordTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MedicalRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicalRecord";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.MedicalRecordTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MedicalRecordTable MedicalRecordTable;
        private Button GradeDoctorButton;
        private Button ResetButton;
        private Button SearchButton;
        private TextBox SearchTextBox;
        private Label label1;
    }
}
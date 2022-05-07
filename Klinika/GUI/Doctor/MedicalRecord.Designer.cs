namespace Klinika.GUI.Doctor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PatientNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BloodTypeLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AnamnesesTable = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DiseasesTable = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AllergensTable = new System.Windows.Forms.DataGridView();
            this.AnamnesisGroup = new System.Windows.Forms.GroupBox();
            this.PerscriptionHint = new System.Windows.Forms.Label();
            this.PerscriptionButton = new System.Windows.Forms.Button();
            this.DoctorsComboBox = new System.Windows.Forms.ComboBox();
            this.SpecializationsComboBox = new System.Windows.Forms.ComboBox();
            this.ReferCheckBox = new System.Windows.Forms.CheckBox();
            this.FinishButton = new System.Windows.Forms.Button();
            this.ConclusionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SymptomsTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnamnesesTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiseasesTable)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllergensTable)).BeginInit();
            this.AnamnesisGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // PatientNameLabel
            // 
            this.PatientNameLabel.AutoSize = true;
            this.PatientNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PatientNameLabel.Location = new System.Drawing.Point(20, 9);
            this.PatientNameLabel.Name = "PatientNameLabel";
            this.PatientNameLabel.Size = new System.Drawing.Size(50, 20);
            this.PatientNameLabel.TabIndex = 0;
            this.PatientNameLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Height:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Weight:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Blood Type:";
            // 
            // BloodTypeLabel
            // 
            this.BloodTypeLabel.AutoSize = true;
            this.BloodTypeLabel.Location = new System.Drawing.Point(84, 20);
            this.BloodTypeLabel.Name = "BloodTypeLabel";
            this.BloodTypeLabel.Size = new System.Drawing.Size(38, 15);
            this.BloodTypeLabel.TabIndex = 4;
            this.BloodTypeLabel.Text = "label4";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(84, 40);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(38, 15);
            this.HeightLabel.TabIndex = 5;
            this.HeightLabel.Text = "label4";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(84, 60);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(38, 15);
            this.WeightLabel.TabIndex = 6;
            this.WeightLabel.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.WeightLabel);
            this.groupBox1.Controls.Add(this.BloodTypeLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.HeightLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 89);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Information";
            // 
            // AnamnesesTable
            // 
            this.AnamnesesTable.AllowUserToAddRows = false;
            this.AnamnesesTable.AllowUserToDeleteRows = false;
            this.AnamnesesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AnamnesesTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AnamnesesTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.AnamnesesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AnamnesesTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.AnamnesesTable.Location = new System.Drawing.Point(8, 22);
            this.AnamnesesTable.Name = "AnamnesesTable";
            this.AnamnesesTable.ReadOnly = true;
            this.AnamnesesTable.RowHeadersWidth = 51;
            this.AnamnesesTable.RowTemplate.Height = 25;
            this.AnamnesesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AnamnesesTable.Size = new System.Drawing.Size(448, 371);
            this.AnamnesesTable.TabIndex = 8;
            this.AnamnesesTable.SelectionChanged += new System.EventHandler(this.TableSelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AnamnesesTable);
            this.groupBox2.Location = new System.Drawing.Point(20, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 403);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anamneses";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DiseasesTable);
            this.groupBox3.Location = new System.Drawing.Point(491, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 403);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Diseases";
            // 
            // DiseasesTable
            // 
            this.DiseasesTable.AllowUserToAddRows = false;
            this.DiseasesTable.AllowUserToDeleteRows = false;
            this.DiseasesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DiseasesTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DiseasesTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DiseasesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DiseasesTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.DiseasesTable.Location = new System.Drawing.Point(8, 22);
            this.DiseasesTable.Name = "DiseasesTable";
            this.DiseasesTable.ReadOnly = true;
            this.DiseasesTable.RowHeadersWidth = 51;
            this.DiseasesTable.RowTemplate.Height = 25;
            this.DiseasesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DiseasesTable.Size = new System.Drawing.Size(327, 371);
            this.DiseasesTable.TabIndex = 9;
            this.DiseasesTable.SelectionChanged += new System.EventHandler(this.TableSelectionChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AllergensTable);
            this.groupBox4.Location = new System.Drawing.Point(840, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 403);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Allergens";
            // 
            // AllergensTable
            // 
            this.AllergensTable.AllowUserToAddRows = false;
            this.AllergensTable.AllowUserToDeleteRows = false;
            this.AllergensTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AllergensTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AllergensTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.AllergensTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AllergensTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.AllergensTable.Location = new System.Drawing.Point(9, 22);
            this.AllergensTable.Name = "AllergensTable";
            this.AllergensTable.ReadOnly = true;
            this.AllergensTable.RowHeadersWidth = 51;
            this.AllergensTable.RowTemplate.Height = 25;
            this.AllergensTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AllergensTable.Size = new System.Drawing.Size(246, 371);
            this.AllergensTable.TabIndex = 10;
            this.AllergensTable.SelectionChanged += new System.EventHandler(this.TableSelectionChanged);
            // 
            // AnamnesisGroup
            // 
            this.AnamnesisGroup.Controls.Add(this.PerscriptionHint);
            this.AnamnesisGroup.Controls.Add(this.PerscriptionButton);
            this.AnamnesisGroup.Controls.Add(this.DoctorsComboBox);
            this.AnamnesisGroup.Controls.Add(this.SpecializationsComboBox);
            this.AnamnesisGroup.Controls.Add(this.ReferCheckBox);
            this.AnamnesisGroup.Controls.Add(this.FinishButton);
            this.AnamnesisGroup.Controls.Add(this.ConclusionTextBox);
            this.AnamnesisGroup.Controls.Add(this.label6);
            this.AnamnesisGroup.Controls.Add(this.label5);
            this.AnamnesisGroup.Controls.Add(this.SymptomsTextBox);
            this.AnamnesisGroup.Controls.Add(this.DescriptionTextBox);
            this.AnamnesisGroup.Controls.Add(this.label4);
            this.AnamnesisGroup.Location = new System.Drawing.Point(200, 10);
            this.AnamnesisGroup.Name = "AnamnesisGroup";
            this.AnamnesisGroup.Size = new System.Drawing.Size(904, 119);
            this.AnamnesisGroup.TabIndex = 12;
            this.AnamnesisGroup.TabStop = false;
            this.AnamnesisGroup.Text = "New Anamnesis";
            this.AnamnesisGroup.Visible = false;
            // 
            // PerscriptionHint
            // 
            this.PerscriptionHint.AutoSize = true;
            this.PerscriptionHint.Location = new System.Drawing.Point(596, 91);
            this.PerscriptionHint.Name = "PerscriptionHint";
            this.PerscriptionHint.Size = new System.Drawing.Size(156, 15);
            this.PerscriptionHint.TabIndex = 11;
            this.PerscriptionHint.Text = "Fill all anamnesis details first";
            // 
            // PerscriptionButton
            // 
            this.PerscriptionButton.Enabled = false;
            this.PerscriptionButton.Location = new System.Drawing.Point(758, 86);
            this.PerscriptionButton.Name = "PerscriptionButton";
            this.PerscriptionButton.Size = new System.Drawing.Size(137, 23);
            this.PerscriptionButton.TabIndex = 10;
            this.PerscriptionButton.Text = "Issue Perscription";
            this.PerscriptionButton.UseVisualStyleBackColor = true;
            this.PerscriptionButton.Click += new System.EventHandler(this.PerscriptionButtonClick);
            // 
            // DoctorsComboBox
            // 
            this.DoctorsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DoctorsComboBox.Enabled = false;
            this.DoctorsComboBox.FormattingEnabled = true;
            this.DoctorsComboBox.Location = new System.Drawing.Point(341, 88);
            this.DoctorsComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoctorsComboBox.Name = "DoctorsComboBox";
            this.DoctorsComboBox.Size = new System.Drawing.Size(133, 23);
            this.DoctorsComboBox.TabIndex = 9;
            // 
            // SpecializationsComboBox
            // 
            this.SpecializationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpecializationsComboBox.Enabled = false;
            this.SpecializationsComboBox.FormattingEnabled = true;
            this.SpecializationsComboBox.Location = new System.Drawing.Point(153, 88);
            this.SpecializationsComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SpecializationsComboBox.Name = "SpecializationsComboBox";
            this.SpecializationsComboBox.Size = new System.Drawing.Size(183, 23);
            this.SpecializationsComboBox.TabIndex = 8;
            this.SpecializationsComboBox.SelectedValueChanged += new System.EventHandler(this.SpecializationsComboBox_SelectedValueChanged);
            // 
            // ReferCheckBox
            // 
            this.ReferCheckBox.AutoSize = true;
            this.ReferCheckBox.Location = new System.Drawing.Point(10, 90);
            this.ReferCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReferCheckBox.Name = "ReferCheckBox";
            this.ReferCheckBox.Size = new System.Drawing.Size(118, 19);
            this.ReferCheckBox.TabIndex = 7;
            this.ReferCheckBox.Text = "Refer to specialist";
            this.ReferCheckBox.UseVisualStyleBackColor = true;
            this.ReferCheckBox.CheckedChanged += new System.EventHandler(this.ReferCheckBoxCheckedChanged);
            // 
            // FinishButton
            // 
            this.FinishButton.Location = new System.Drawing.Point(820, 37);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(75, 43);
            this.FinishButton.TabIndex = 6;
            this.FinishButton.Text = "FINISH";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButtonClick);
            // 
            // ConclusionTextBox
            // 
            this.ConclusionTextBox.Location = new System.Drawing.Point(552, 37);
            this.ConclusionTextBox.Multiline = true;
            this.ConclusionTextBox.Name = "ConclusionTextBox";
            this.ConclusionTextBox.Size = new System.Drawing.Size(265, 43);
            this.ConclusionTextBox.TabIndex = 5;
            this.ConclusionTextBox.TextChanged += new System.EventHandler(this.AnamnesisTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(552, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Conclusion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Symptoms";
            // 
            // SymptomsTextBox
            // 
            this.SymptomsTextBox.Location = new System.Drawing.Point(281, 37);
            this.SymptomsTextBox.Multiline = true;
            this.SymptomsTextBox.Name = "SymptomsTextBox";
            this.SymptomsTextBox.Size = new System.Drawing.Size(265, 43);
            this.SymptomsTextBox.TabIndex = 2;
            this.SymptomsTextBox.TextChanged += new System.EventHandler(this.AnamnesisTextChanged);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(10, 37);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(265, 43);
            this.DescriptionTextBox.TabIndex = 1;
            this.DescriptionTextBox.TextChanged += new System.EventHandler(this.AnamnesisTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description";
            // 
            // MedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 555);
            this.Controls.Add(this.AnamnesisGroup);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PatientNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MedicalRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medical Record";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnamnesesTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DiseasesTable)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllergensTable)).EndInit();
            this.AnamnesisGroup.ResumeLayout(false);
            this.AnamnesisGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label PatientNameLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label BloodTypeLabel;
        private Label HeightLabel;
        private Label WeightLabel;
        private GroupBox groupBox1;
        private DataGridView AnamnesesTable;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DataGridView DiseasesTable;
        private GroupBox groupBox4;
        private DataGridView AllergensTable;
        private GroupBox AnamnesisGroup;
        private Button FinishButton;
        private TextBox ConclusionTextBox;
        private Label label6;
        private Label label5;
        private TextBox SymptomsTextBox;
        private TextBox DescriptionTextBox;
        private Label label4;
        private ComboBox DoctorsComboBox;
        private ComboBox SpecializationsComboBox;
        private CheckBox ReferCheckBox;
        private Button PerscriptionButton;
        private Label PerscriptionHint;
    }
}
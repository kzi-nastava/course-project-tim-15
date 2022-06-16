namespace Klinika.GUI.Manager
{
    partial class Main
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.roomTable = new Klinika.Forms.RoomTable();
            this.renovateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.equipTable = new Klinika.Forms.RoomEquipmentTable();
            this.dateButton = new System.Windows.Forms.Button();
            this.equipmentComboBox = new System.Windows.Forms.ComboBox();
            this.roomComboBox = new System.Windows.Forms.ComboBox();
            this.quantityComboBox = new System.Windows.Forms.ComboBox();
            this.roomTypeTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.equipmentTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.drugsTable1 = new Klinika.Forms.DrugsTable();
            this.modifyDrugButton = new System.Windows.Forms.Button();
            this.addDrugButton = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ingredientsTable = new Klinika.Forms.IngredientsTable();
            this.deleteIngredientsButton = new System.Windows.Forms.Button();
            this.modifyIngredientsButton = new System.Windows.Forms.Button();
            this.addIngredientsButton = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.worstButton = new System.Windows.Forms.Button();
            this.bestButton = new System.Windows.Forms.Button();
            this.questionsButton = new System.Windows.Forms.Button();
            this.questionnaireTable = new Klinika.Forms.QuestionnaireTable();
            this.roomsTable = new Klinika.Forms.RoomTable();
            this.equipmentTable = new Klinika.Forms.RoomEquipmentTable();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomTable)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drugsTable1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsTable)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionnaireTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Controls.Add(this.tabPage4);
            this.tabs.Controls.Add(this.tabPage5);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(776, 426);
            this.tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.roomTable);
            this.tabPage1.Controls.Add(this.renovateButton);
            this.tabPage1.Controls.Add(this.deleteButton);
            this.tabPage1.Controls.Add(this.modifyButton);
            this.tabPage1.Controls.Add(this.addButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rooms";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // roomTable
            // 
            this.roomTable.AllowUserToAddRows = false;
            this.roomTable.AllowUserToDeleteRows = false;
            this.roomTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.roomTable.BackgroundColor = System.Drawing.Color.White;
            this.roomTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomTable.Location = new System.Drawing.Point(0, 3);
            this.roomTable.MultiSelect = false;
            this.roomTable.Name = "roomTable";
            this.roomTable.ReadOnly = true;
            this.roomTable.RowHeadersWidth = 51;
            this.roomTable.RowTemplate.Height = 30;
            this.roomTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.roomTable.Size = new System.Drawing.Size(765, 333);
            this.roomTable.TabIndex = 5;
            // 
            // renovateButton
            // 
            this.renovateButton.Enabled = false;
            this.renovateButton.Location = new System.Drawing.Point(527, 342);
            this.renovateButton.Name = "renovateButton";
            this.renovateButton.Size = new System.Drawing.Size(94, 29);
            this.renovateButton.TabIndex = 4;
            this.renovateButton.Text = "Renovate";
            this.renovateButton.UseVisualStyleBackColor = true;
            this.renovateButton.Click += new System.EventHandler(this.renovateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(371, 342);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 29);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Enabled = false;
            this.modifyButton.Location = new System.Drawing.Point(215, 342);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(94, 29);
            this.modifyButton.TabIndex = 2;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(70, 342);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add New";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.equipTable);
            this.tabPage2.Controls.Add(this.dateButton);
            this.tabPage2.Controls.Add(this.equipmentComboBox);
            this.tabPage2.Controls.Add(this.roomComboBox);
            this.tabPage2.Controls.Add(this.quantityComboBox);
            this.tabPage2.Controls.Add(this.roomTypeTextBox);
            this.tabPage2.Controls.Add(this.quantityTextBox);
            this.tabPage2.Controls.Add(this.typeTextBox);
            this.tabPage2.Controls.Add(this.equipmentTextBox);
            this.tabPage2.Controls.Add(this.numberTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Equipment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // equipTable
            // 
            this.equipTable.AllowUserToAddRows = false;
            this.equipTable.AllowUserToDeleteRows = false;
            this.equipTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.equipTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.equipTable.BackgroundColor = System.Drawing.Color.White;
            this.equipTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipTable.Location = new System.Drawing.Point(3, 48);
            this.equipTable.MultiSelect = false;
            this.equipTable.Name = "equipTable";
            this.equipTable.ReadOnly = true;
            this.equipTable.RowHeadersWidth = 51;
            this.equipTable.RowTemplate.Height = 30;
            this.equipTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.equipTable.Size = new System.Drawing.Size(765, 250);
            this.equipTable.TabIndex = 13;
            // 
            // dateButton
            // 
            this.dateButton.Location = new System.Drawing.Point(9, 304);
            this.dateButton.Name = "dateButton";
            this.dateButton.Size = new System.Drawing.Size(139, 29);
            this.dateButton.TabIndex = 12;
            this.dateButton.Text = "Transfer";
            this.dateButton.UseVisualStyleBackColor = true;
            this.dateButton.Click += new System.EventHandler(this.dateButton_Click);
            // 
            // equipmentComboBox
            // 
            this.equipmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equipmentComboBox.FormattingEnabled = true;
            this.equipmentComboBox.Location = new System.Drawing.Point(474, 304);
            this.equipmentComboBox.Name = "equipmentComboBox";
            this.equipmentComboBox.Size = new System.Drawing.Size(135, 28);
            this.equipmentComboBox.TabIndex = 11;
            this.equipmentComboBox.SelectedIndexChanged += new System.EventHandler(this.equipmentComboBox_SelectedIndexChanged);
            // 
            // roomComboBox
            // 
            this.roomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomComboBox.FormattingEnabled = true;
            this.roomComboBox.Location = new System.Drawing.Point(199, 304);
            this.roomComboBox.Name = "roomComboBox";
            this.roomComboBox.Size = new System.Drawing.Size(131, 28);
            this.roomComboBox.TabIndex = 10;
            this.roomComboBox.SelectedIndexChanged += new System.EventHandler(this.equipmentTextBox_TextChanged);
            // 
            // quantityComboBox
            // 
            this.quantityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quantityComboBox.FormattingEnabled = true;
            this.quantityComboBox.Location = new System.Drawing.Point(615, 304);
            this.quantityComboBox.Name = "quantityComboBox";
            this.quantityComboBox.Size = new System.Drawing.Size(147, 28);
            this.quantityComboBox.TabIndex = 9;
            this.quantityComboBox.SelectedIndexChanged += new System.EventHandler(this.quantityComboBox_SelectedIndexChanged);
            // 
            // roomTypeTextBox
            // 
            this.roomTypeTextBox.Location = new System.Drawing.Point(199, 15);
            this.roomTypeTextBox.Name = "roomTypeTextBox";
            this.roomTypeTextBox.Size = new System.Drawing.Size(131, 27);
            this.roomTypeTextBox.TabIndex = 8;
            this.roomTypeTextBox.TextChanged += new System.EventHandler(this.roomTypeTextBox_TextChanged);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(615, 15);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(147, 27);
            this.quantityTextBox.TabIndex = 4;
            this.quantityTextBox.TextChanged += new System.EventHandler(this.quantityTextBox_TextChanged);
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(474, 15);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(135, 27);
            this.typeTextBox.TabIndex = 3;
            this.typeTextBox.TextChanged += new System.EventHandler(this.typeTextBox_TextChanged);
            // 
            // equipmentTextBox
            // 
            this.equipmentTextBox.Location = new System.Drawing.Point(336, 15);
            this.equipmentTextBox.Name = "equipmentTextBox";
            this.equipmentTextBox.Size = new System.Drawing.Size(132, 27);
            this.equipmentTextBox.TabIndex = 2;
            this.equipmentTextBox.TextChanged += new System.EventHandler(this.equipmentTextBox_TextChanged);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(61, 15);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(132, 27);
            this.numberTextBox.TabIndex = 1;
            this.numberTextBox.TextChanged += new System.EventHandler(this.numberTextBox_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.drugsTable1);
            this.tabPage3.Controls.Add(this.modifyDrugButton);
            this.tabPage3.Controls.Add(this.addDrugButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Drugs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // drugsTable1
            // 
            this.drugsTable1.AllowUserToAddRows = false;
            this.drugsTable1.AllowUserToDeleteRows = false;
            this.drugsTable1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drugsTable1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.drugsTable1.BackgroundColor = System.Drawing.Color.White;
            this.drugsTable1.ColumnHeadersHeight = 29;
            this.drugsTable1.Location = new System.Drawing.Point(3, 3);
            this.drugsTable1.MultiSelect = false;
            this.drugsTable1.Name = "drugsTable1";
            this.drugsTable1.ReadOnly = true;
            this.drugsTable1.RowHeadersWidth = 51;
            this.drugsTable1.RowTemplate.Height = 30;
            this.drugsTable1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drugsTable1.Size = new System.Drawing.Size(765, 315);
            this.drugsTable1.TabIndex = 7;
            // 
            // modifyDrugButton
            // 
            this.modifyDrugButton.Location = new System.Drawing.Point(180, 334);
            this.modifyDrugButton.Name = "modifyDrugButton";
            this.modifyDrugButton.Size = new System.Drawing.Size(94, 29);
            this.modifyDrugButton.TabIndex = 2;
            this.modifyDrugButton.Text = "Modify";
            this.modifyDrugButton.UseVisualStyleBackColor = true;
            this.modifyDrugButton.Click += new System.EventHandler(this.modifyDrugButton_Click);
            // 
            // addDrugButton
            // 
            this.addDrugButton.Location = new System.Drawing.Point(43, 334);
            this.addDrugButton.Name = "addDrugButton";
            this.addDrugButton.Size = new System.Drawing.Size(94, 29);
            this.addDrugButton.TabIndex = 1;
            this.addDrugButton.Text = "Add New";
            this.addDrugButton.UseVisualStyleBackColor = true;
            this.addDrugButton.Click += new System.EventHandler(this.addDrugButton_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ingredientsTable);
            this.tabPage4.Controls.Add(this.deleteIngredientsButton);
            this.tabPage4.Controls.Add(this.modifyIngredientsButton);
            this.tabPage4.Controls.Add(this.addIngredientsButton);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(768, 393);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Ingredients";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ingredientsTable
            // 
            this.ingredientsTable.AllowUserToAddRows = false;
            this.ingredientsTable.AllowUserToDeleteRows = false;
            this.ingredientsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ingredientsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ingredientsTable.BackgroundColor = System.Drawing.Color.White;
            this.ingredientsTable.ColumnHeadersHeight = 29;
            this.ingredientsTable.Location = new System.Drawing.Point(3, 3);
            this.ingredientsTable.MultiSelect = false;
            this.ingredientsTable.Name = "ingredientsTable";
            this.ingredientsTable.ReadOnly = true;
            this.ingredientsTable.RowHeadersWidth = 51;
            this.ingredientsTable.RowTemplate.Height = 30;
            this.ingredientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ingredientsTable.Size = new System.Drawing.Size(762, 323);
            this.ingredientsTable.TabIndex = 7;
            // 
            // deleteIngredientsButton
            // 
            this.deleteIngredientsButton.Location = new System.Drawing.Point(348, 332);
            this.deleteIngredientsButton.Name = "deleteIngredientsButton";
            this.deleteIngredientsButton.Size = new System.Drawing.Size(94, 29);
            this.deleteIngredientsButton.TabIndex = 3;
            this.deleteIngredientsButton.Text = "Delete";
            this.deleteIngredientsButton.UseVisualStyleBackColor = true;
            this.deleteIngredientsButton.Click += new System.EventHandler(this.deleteIngredientsButton_Click);
            // 
            // modifyIngredientsButton
            // 
            this.modifyIngredientsButton.Location = new System.Drawing.Point(206, 332);
            this.modifyIngredientsButton.Name = "modifyIngredientsButton";
            this.modifyIngredientsButton.Size = new System.Drawing.Size(94, 29);
            this.modifyIngredientsButton.TabIndex = 2;
            this.modifyIngredientsButton.Text = "Modify";
            this.modifyIngredientsButton.UseVisualStyleBackColor = true;
            // 
            // addIngredientsButton
            // 
            this.addIngredientsButton.Location = new System.Drawing.Point(44, 332);
            this.addIngredientsButton.Name = "addIngredientsButton";
            this.addIngredientsButton.Size = new System.Drawing.Size(94, 29);
            this.addIngredientsButton.TabIndex = 1;
            this.addIngredientsButton.Text = "Add New";
            this.addIngredientsButton.UseVisualStyleBackColor = true;
            this.addIngredientsButton.Click += new System.EventHandler(this.addIngredientsButton_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.worstButton);
            this.tabPage5.Controls.Add(this.bestButton);
            this.tabPage5.Controls.Add(this.questionsButton);
            this.tabPage5.Controls.Add(this.questionnaireTable);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(768, 393);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Questionnaire";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // worstButton
            // 
            this.worstButton.Location = new System.Drawing.Point(279, 345);
            this.worstButton.Name = "worstButton";
            this.worstButton.Size = new System.Drawing.Size(94, 29);
            this.worstButton.TabIndex = 3;
            this.worstButton.Text = "Worst";
            this.worstButton.UseVisualStyleBackColor = true;
            this.worstButton.Click += new System.EventHandler(this.worstButton_Click);
            // 
            // bestButton
            // 
            this.bestButton.Location = new System.Drawing.Point(146, 345);
            this.bestButton.Name = "bestButton";
            this.bestButton.Size = new System.Drawing.Size(94, 29);
            this.bestButton.TabIndex = 2;
            this.bestButton.Text = "Best Doctors";
            this.bestButton.UseVisualStyleBackColor = true;
            this.bestButton.Click += new System.EventHandler(this.bestButton_Click);
            // 
            // questionsButton
            // 
            this.questionsButton.Location = new System.Drawing.Point(17, 345);
            this.questionsButton.Name = "questionsButton";
            this.questionsButton.Size = new System.Drawing.Size(94, 29);
            this.questionsButton.TabIndex = 1;
            this.questionsButton.Text = "Questions";
            this.questionsButton.UseVisualStyleBackColor = true;
            this.questionsButton.Click += new System.EventHandler(this.questionsButton_Click);
            // 
            // questionnaireTable
            // 
            this.questionnaireTable.AllowUserToAddRows = false;
            this.questionnaireTable.AllowUserToDeleteRows = false;
            this.questionnaireTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questionnaireTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.questionnaireTable.BackgroundColor = System.Drawing.Color.White;
            this.questionnaireTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionnaireTable.Location = new System.Drawing.Point(3, 0);
            this.questionnaireTable.MultiSelect = false;
            this.questionnaireTable.Name = "questionnaireTable";
            this.questionnaireTable.ReadOnly = true;
            this.questionnaireTable.RowHeadersWidth = 51;
            this.questionnaireTable.RowTemplate.Height = 30;
            this.questionnaireTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.questionnaireTable.Size = new System.Drawing.Size(762, 321);
            this.questionnaireTable.TabIndex = 0;
            // 
            // roomsTable
            // 
            this.roomsTable.AllowUserToAddRows = false;
            this.roomsTable.AllowUserToDeleteRows = false;
            this.roomsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.roomsTable.BackgroundColor = System.Drawing.Color.White;
            this.roomsTable.ColumnHeadersHeight = 29;
            this.roomsTable.Location = new System.Drawing.Point(0, 0);
            this.roomsTable.MultiSelect = false;
            this.roomsTable.Name = "roomsTable";
            this.roomsTable.ReadOnly = true;
            this.roomsTable.RowHeadersWidth = 51;
            this.roomsTable.RowTemplate.Height = 30;
            this.roomsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.roomsTable.Size = new System.Drawing.Size(240, 150);
            this.roomsTable.TabIndex = 0;
            // 
            // equipmentTable
            // 
            this.equipmentTable.AllowUserToAddRows = false;
            this.equipmentTable.AllowUserToDeleteRows = false;
            this.equipmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.equipmentTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.equipmentTable.BackgroundColor = System.Drawing.Color.White;
            this.equipmentTable.ColumnHeadersHeight = 29;
            this.equipmentTable.Location = new System.Drawing.Point(0, 0);
            this.equipmentTable.MultiSelect = false;
            this.equipmentTable.Name = "equipmentTable";
            this.equipmentTable.ReadOnly = true;
            this.equipmentTable.RowHeadersWidth = 51;
            this.equipmentTable.RowTemplate.Height = 30;
            this.equipmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.equipmentTable.Size = new System.Drawing.Size(240, 150);
            this.equipmentTable.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabs);
            this.Name = "Main";
            this.Text = "Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomTable)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drugsTable1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsTable)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionnaireTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabs;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button deleteButton;
        private Button modifyButton;
        private Button addButton;
        private Forms.RoomTable roomsTable;
        private Forms.RoomEquipmentTable equipmentTable;
        private TextBox typeTextBox;
        private TextBox equipmentTextBox;
        private TextBox numberTextBox;
        private TextBox quantityTextBox;
        private TextBox roomTypeTextBox;
        private ComboBox equipmentComboBox;
        private ComboBox roomComboBox;
        private ComboBox quantityComboBox;
        private Button dateButton;
        private Button renovateButton;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button addDrugButton;
        private Button deleteIngredientsButton;
        private Button modifyIngredientsButton;
        private Button addIngredientsButton;
        private Button modifyDrugButton;
        private Forms.DrugsTable drugsTable1;
        private Forms.IngredientsTable ingredientsTable;
        private Forms.RoomEquipmentTable equipTable;
        private TabPage tabPage5;
        private Forms.RoomTable roomTable;
        private Forms.QuestionnaireTable questionnaireTable;
        private Button worstButton;
        private Button bestButton;
        private Button questionsButton;
    }
}
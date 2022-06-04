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
            this.renovateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.roomsTable = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dateButton = new System.Windows.Forms.Button();
            this.equipmentComboBox = new System.Windows.Forms.ComboBox();
            this.roomComboBox = new System.Windows.Forms.ComboBox();
            this.quantityComboBox = new System.Windows.Forms.ComboBox();
            this.roomTypeTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.equipmentTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.equipmentTable = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.drugsTable = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.deleteIngredientsButton = new System.Windows.Forms.Button();
            this.modifyIngredientsButton = new System.Windows.Forms.Button();
            this.addIngredientsButton = new System.Windows.Forms.Button();
            this.ingredientsTable = new System.Windows.Forms.DataGridView();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsTable)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drugsTable)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Controls.Add(this.tabPage4);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(776, 426);
            this.tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.renovateButton);
            this.tabPage1.Controls.Add(this.deleteButton);
            this.tabPage1.Controls.Add(this.modifyButton);
            this.tabPage1.Controls.Add(this.addButton);
            this.tabPage1.Controls.Add(this.roomsTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rooms";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // roomsTable
            // 
            this.roomsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomsTable.Location = new System.Drawing.Point(6, 6);
            this.roomsTable.Name = "roomsTable";
            this.roomsTable.RowHeadersWidth = 51;
            this.roomsTable.RowTemplate.Height = 29;
            this.roomsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.roomsTable.Size = new System.Drawing.Size(756, 316);
            this.roomsTable.TabIndex = 0;
            this.roomsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomsTable_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dateButton);
            this.tabPage2.Controls.Add(this.equipmentComboBox);
            this.tabPage2.Controls.Add(this.roomComboBox);
            this.tabPage2.Controls.Add(this.quantityComboBox);
            this.tabPage2.Controls.Add(this.roomTypeTextBox);
            this.tabPage2.Controls.Add(this.quantityTextBox);
            this.tabPage2.Controls.Add(this.typeTextBox);
            this.tabPage2.Controls.Add(this.equipmentTextBox);
            this.tabPage2.Controls.Add(this.numberTextBox);
            this.tabPage2.Controls.Add(this.equipmentTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Equipment";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // equipmentTable
            // 
            this.equipmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.equipmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipmentTable.Location = new System.Drawing.Point(9, 48);
            this.equipmentTable.Name = "equipmentTable";
            this.equipmentTable.RowHeadersWidth = 51;
            this.equipmentTable.RowTemplate.Height = 29;
            this.equipmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.equipmentTable.Size = new System.Drawing.Size(756, 250);
            this.equipmentTable.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.drugsTable);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Drugs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // drugsTable
            // 
            this.drugsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drugsTable.Location = new System.Drawing.Point(3, 3);
            this.drugsTable.Name = "drugsTable";
            this.drugsTable.RowHeadersWidth = 51;
            this.drugsTable.RowTemplate.Height = 29;
            this.drugsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drugsTable.Size = new System.Drawing.Size(769, 308);
            this.drugsTable.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.deleteIngredientsButton);
            this.tabPage4.Controls.Add(this.modifyIngredientsButton);
            this.tabPage4.Controls.Add(this.addIngredientsButton);
            this.tabPage4.Controls.Add(this.ingredientsTable);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(768, 393);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Ingredients";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.modifyIngredientsButton.Click += new System.EventHandler(this.modifyIngredientsButton_Click);
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
            // ingredientsTable
            // 
            this.ingredientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsTable.Location = new System.Drawing.Point(3, 3);
            this.ingredientsTable.Name = "ingredientsTable";
            this.ingredientsTable.RowHeadersWidth = 51;
            this.ingredientsTable.RowTemplate.Height = 29;
            this.ingredientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ingredientsTable.Size = new System.Drawing.Size(762, 311);
            this.ingredientsTable.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.roomsTable)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drugsTable)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabs;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button deleteButton;
        private Button modifyButton;
        private Button addButton;
        private DataGridView roomsTable;
        private DataGridView equipmentTable;
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
        private DataGridView drugsTable;
        private DataGridView ingredientsTable;
        private Button button1;
        private Button deleteIngredientsButton;
        private Button modifyIngredientsButton;
        private Button addIngredientsButton;
    }
}
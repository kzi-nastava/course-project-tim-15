﻿namespace Klinika.GUI.Manager
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.roomsTable = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toButton = new System.Windows.Forms.Button();
            this.fromButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.equipmentTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.equipmentTable = new System.Windows.Forms.DataGridView();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsTable)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(776, 426);
            this.tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
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
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(473, 342);
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
            this.modifyButton.Location = new System.Drawing.Point(323, 342);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(94, 29);
            this.modifyButton.TabIndex = 2;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(178, 342);
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
            this.tabPage2.Controls.Add(this.toButton);
            this.tabPage2.Controls.Add(this.fromButton);
            this.tabPage2.Controls.Add(this.filterButton);
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
            // toButton
            // 
            this.toButton.Location = new System.Drawing.Point(276, 344);
            this.toButton.Name = "toButton";
            this.toButton.Size = new System.Drawing.Size(110, 29);
            this.toButton.TabIndex = 7;
            this.toButton.Text = "Select To";
            this.toButton.UseVisualStyleBackColor = true;
            // 
            // fromButton
            // 
            this.fromButton.Location = new System.Drawing.Point(133, 344);
            this.fromButton.Name = "fromButton";
            this.fromButton.Size = new System.Drawing.Size(110, 29);
            this.fromButton.TabIndex = 6;
            this.fromButton.Text = "Select From";
            this.fromButton.UseVisualStyleBackColor = true;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(9, 344);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(94, 29);
            this.filterButton.TabIndex = 5;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(592, 15);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(170, 27);
            this.quantityTextBox.TabIndex = 4;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(412, 15);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(174, 27);
            this.typeTextBox.TabIndex = 3;
            // 
            // equipmentTextBox
            // 
            this.equipmentTextBox.Location = new System.Drawing.Point(233, 15);
            this.equipmentTextBox.Name = "equipmentTextBox";
            this.equipmentTextBox.Size = new System.Drawing.Size(173, 27);
            this.equipmentTextBox.TabIndex = 2;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(61, 15);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(166, 27);
            this.numberTextBox.TabIndex = 1;
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
            this.equipmentTable.Size = new System.Drawing.Size(756, 271);
            this.equipmentTable.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabs);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomsTable)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private DataGridView roomsTable;
        private DataGridView equipmentTable;
        private TextBox typeTextBox;
        private TextBox equipmentTextBox;
        private TextBox numberTextBox;
        private TextBox quantityTextBox;
        private Button filterButton;
        private Button toButton;
        private Button fromButton;
    }
}
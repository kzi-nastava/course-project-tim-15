namespace Klinika.GUI.Manager
{
    partial class ChangeDrug
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
            this.addDrugButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ingredientsTable = new System.Windows.Forms.DataGridView();
            this.ingredientsBox = new System.Windows.Forms.ComboBox();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.removeIngredientButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // addDrugButton
            // 
            this.addDrugButton.Location = new System.Drawing.Point(304, 326);
            this.addDrugButton.Name = "addDrugButton";
            this.addDrugButton.Size = new System.Drawing.Size(149, 82);
            this.addDrugButton.TabIndex = 10;
            this.addDrugButton.Text = "Add Drug";
            this.addDrugButton.UseVisualStyleBackColor = true;
            this.addDrugButton.Click += new System.EventHandler(this.addDrugButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Drug Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(359, 156);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(125, 27);
            this.nameBox.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(24, 52);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(237, 356);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // ingredientsTable
            // 
            this.ingredientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsTable.Location = new System.Drawing.Point(490, 52);
            this.ingredientsTable.Name = "ingredientsTable";
            this.ingredientsTable.RowHeadersWidth = 51;
            this.ingredientsTable.RowTemplate.Height = 29;
            this.ingredientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ingredientsTable.Size = new System.Drawing.Size(300, 188);
            this.ingredientsTable.TabIndex = 12;
            // 
            // ingredientsBox
            // 
            this.ingredientsBox.FormattingEnabled = true;
            this.ingredientsBox.Location = new System.Drawing.Point(490, 246);
            this.ingredientsBox.Name = "ingredientsBox";
            this.ingredientsBox.Size = new System.Drawing.Size(151, 28);
            this.ingredientsBox.TabIndex = 13;
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(490, 283);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(94, 51);
            this.addIngredientButton.TabIndex = 14;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // removeIngredientButton
            // 
            this.removeIngredientButton.Location = new System.Drawing.Point(653, 283);
            this.removeIngredientButton.Name = "removeIngredientButton";
            this.removeIngredientButton.Size = new System.Drawing.Size(94, 51);
            this.removeIngredientButton.TabIndex = 15;
            this.removeIngredientButton.Text = "Remove Ingredient";
            this.removeIngredientButton.UseVisualStyleBackColor = true;
            this.removeIngredientButton.Click += new System.EventHandler(this.removeIngredientButton_Click);
            // 
            // ChangeDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removeIngredientButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.ingredientsBox);
            this.Controls.Add(this.ingredientsTable);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.addDrugButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Name = "ChangeDrug";
            this.Text = "ChangeDrug";
            this.Load += new System.EventHandler(this.ChangeDrug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addDrugButton;
        private Label label1;
        private TextBox nameBox;
        private RichTextBox richTextBox1;
        private DataGridView ingredientsTable;
        private ComboBox ingredientsBox;
        private Button addIngredientButton;
        private Button removeIngredientButton;
    }
}
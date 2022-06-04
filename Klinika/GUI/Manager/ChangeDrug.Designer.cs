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
            this.typeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ingredientsBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // addDrugButton
            // 
            this.addDrugButton.Location = new System.Drawing.Point(318, 303);
            this.addDrugButton.Name = "addDrugButton";
            this.addDrugButton.Size = new System.Drawing.Size(149, 82);
            this.addDrugButton.TabIndex = 10;
            this.addDrugButton.Text = "Add Drug";
            this.addDrugButton.UseVisualStyleBackColor = true;
            // 
            // typeBox
            // 
            this.typeBox.Location = new System.Drawing.Point(359, 186);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(125, 27);
            this.typeBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Drug Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Drug Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(359, 127);
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
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(490, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(300, 188);
            this.dataGridView1.TabIndex = 12;
            // 
            // ingredientsBox
            // 
            this.ingredientsBox.FormattingEnabled = true;
            this.ingredientsBox.Location = new System.Drawing.Point(490, 246);
            this.ingredientsBox.Name = "ingredientsBox";
            this.ingredientsBox.Size = new System.Drawing.Size(151, 28);
            this.ingredientsBox.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(490, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 51);
            this.button2.TabIndex = 14;
            this.button2.Text = "Add Ingredient";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 51);
            this.button1.TabIndex = 15;
            this.button1.Text = "Remove Ingredient";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ChangeDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ingredientsBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.addDrugButton);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Name = "ChangeDrug";
            this.Text = "ChangeDrug";
            this.Load += new System.EventHandler(this.ChangeDrug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addDrugButton;
        private TextBox typeBox;
        private Label label2;
        private Label label1;
        private TextBox nameBox;
        private RichTextBox richTextBox1;
        private DataGridView dataGridView1;
        private ComboBox ingredientsBox;
        private Button button2;
        private Button button1;
    }
}
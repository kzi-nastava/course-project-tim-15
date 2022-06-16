namespace Klinika.GUI.Manager
{
    partial class Questions
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
            this.questionsTable = new Klinika.Forms.DetailsTable();
            this.answersButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.questionsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // questionsTable
            // 
            this.questionsTable.AllowUserToAddRows = false;
            this.questionsTable.AllowUserToDeleteRows = false;
            this.questionsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questionsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.questionsTable.BackgroundColor = System.Drawing.Color.White;
            this.questionsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionsTable.Location = new System.Drawing.Point(12, 12);
            this.questionsTable.MultiSelect = false;
            this.questionsTable.Name = "questionsTable";
            this.questionsTable.ReadOnly = true;
            this.questionsTable.RowHeadersWidth = 51;
            this.questionsTable.RowTemplate.Height = 30;
            this.questionsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.questionsTable.Size = new System.Drawing.Size(776, 345);
            this.questionsTable.TabIndex = 0;
            // 
            // answersButton
            // 
            this.answersButton.Location = new System.Drawing.Point(353, 394);
            this.answersButton.Name = "answersButton";
            this.answersButton.Size = new System.Drawing.Size(94, 29);
            this.answersButton.TabIndex = 1;
            this.answersButton.Text = "Answers";
            this.answersButton.UseVisualStyleBackColor = true;
            this.answersButton.Click += new System.EventHandler(this.answersButton_Click);
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.answersButton);
            this.Controls.Add(this.questionsTable);
            this.Name = "Questions";
            this.Text = "Questions";
            this.Load += new System.EventHandler(this.Questions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.questionsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Klinika.Forms.DetailsTable questionsTable;
        private Button answersButton;
    }
}
namespace Klinika.GUI.Secretary
{
    partial class ChooseReferral
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
            this.referralsTable = new System.Windows.Forms.DataGridView();
            this.chooseReferalButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.referralsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // referralsTable
            // 
            this.referralsTable.AllowUserToAddRows = false;
            this.referralsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.referralsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.referralsTable.Location = new System.Drawing.Point(12, 12);
            this.referralsTable.MultiSelect = false;
            this.referralsTable.Name = "referralsTable";
            this.referralsTable.RowHeadersWidth = 51;
            this.referralsTable.RowTemplate.Height = 29;
            this.referralsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.referralsTable.Size = new System.Drawing.Size(776, 342);
            this.referralsTable.TabIndex = 1;
            this.referralsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.referralsTable_CellClick);
            // 
            // chooseReferalButton
            // 
            this.chooseReferalButton.Enabled = false;
            this.chooseReferalButton.Location = new System.Drawing.Point(330, 390);
            this.chooseReferalButton.Name = "chooseReferalButton";
            this.chooseReferalButton.Size = new System.Drawing.Size(140, 29);
            this.chooseReferalButton.TabIndex = 2;
            this.chooseReferalButton.Text = "Choose referral";
            this.chooseReferalButton.UseVisualStyleBackColor = true;
            this.chooseReferalButton.Click += new System.EventHandler(this.chooseReferalButton_Click);
            // 
            // ChooseReferral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.chooseReferalButton);
            this.Controls.Add(this.referralsTable);
            this.Name = "ChooseReferral";
            this.Text = "Choose Referral";
            this.Load += new System.EventHandler(this.ChooseReferal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.referralsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DataGridView referralsTable;
        private Button chooseReferalButton;
    }
}
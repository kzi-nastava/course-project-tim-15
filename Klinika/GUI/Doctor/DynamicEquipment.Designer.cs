namespace Klinika.GUI.Doctor
{
    partial class DynamicEquipment
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
            this.EquipmentTable = new Klinika.Forms.RoomEquipmentTable();
            this.SpentSpinner = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpentSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipmentTable
            // 
            this.EquipmentTable.Location = new System.Drawing.Point(12, 12);
            this.EquipmentTable.Name = "EquipmentTable";
            this.EquipmentTable.Size = new System.Drawing.Size(820, 347);
            this.EquipmentTable.TabIndex = 0;
            this.EquipmentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentTableCellClick);
            //
            // SpentSpinner
            // 
            this.SpentSpinner.Enabled = false;
            this.SpentSpinner.Location = new System.Drawing.Point(58, 367);
            this.SpentSpinner.Name = "SpentSpinner";
            this.SpentSpinner.Size = new System.Drawing.Size(120, 23);
            this.SpentSpinner.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spent:";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Enabled = false;
            this.ConfirmButton.Location = new System.Drawing.Point(184, 367);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 3;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // FinishButton
            // 
            this.FinishButton.Location = new System.Drawing.Point(757, 365);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(75, 23);
            this.FinishButton.TabIndex = 4;
            this.FinishButton.Text = "Finish";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButtonClick);
            // 
            // DynamicEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 402);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpentSpinner);
            this.Controls.Add(this.EquipmentTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DynamicEquipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamic Equipment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpentSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Klinika.Forms.RoomEquipmentTable EquipmentTable;
        private NumericUpDown SpentSpinner;
        private Label label1;
        private Button ConfirmButton;
        private Button FinishButton;
    }
}
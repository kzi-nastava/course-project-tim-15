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
            this.EquipmentTable = new Klinika.Forms.RoomEquipmentDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipmentTable
            // 
            this.EquipmentTable.AllowUserToAddRows = false;
            this.EquipmentTable.AllowUserToDeleteRows = false;
            this.EquipmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EquipmentTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.EquipmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EquipmentTable.Location = new System.Drawing.Point(12, 12);
            this.EquipmentTable.Name = "EquipmentTable";
            this.EquipmentTable.ReadOnly = true;
            this.EquipmentTable.RowHeadersWidth = 51;
            this.EquipmentTable.RowTemplate.Height = 29;
            this.EquipmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EquipmentTable.Size = new System.Drawing.Size(820, 347);
            this.EquipmentTable.TabIndex = 0;
            // 
            // DynamicEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 402);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.EquipmentTable);
            this.Name = "DynamicEquipment";
            this.Text = "Dynamic Equipment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DynamicEquipmentFormClosing);
            this.Load += new System.EventHandler(this.DynamicEquipmentLoad);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Klinika.Forms.RoomEquipmentDataGridView EquipmentTable;
    }
}
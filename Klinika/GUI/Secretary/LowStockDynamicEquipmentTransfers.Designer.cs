using Klinika.Forms;
namespace Klinika.GUI.Secretary
{
    partial class LowStockDynamicEquipmentTransfers
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
            this.getFromButton = new System.Windows.Forms.Button();
            this.lowStockDynamicEquipmentTable = new Klinika.Forms.LowStockDynamicEquipmentTable();
            ((System.ComponentModel.ISupportInitialize)(this.lowStockDynamicEquipmentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // getFromButton
            // 
            this.getFromButton.Location = new System.Drawing.Point(368, 414);
            this.getFromButton.Name = "getFromButton";
            this.getFromButton.Size = new System.Drawing.Size(195, 29);
            this.getFromButton.TabIndex = 1;
            this.getFromButton.Text = "Get from room/storage";
            this.getFromButton.UseVisualStyleBackColor = true;
            this.getFromButton.Click += new System.EventHandler(this.GetFromButton_Click);
            // 
            // lowStockTransfersTable
            // 
     
            // 
            // lowStockDynamicEquipmentTable1
            // 
            this.lowStockDynamicEquipmentTable.AllowUserToAddRows = false;
            this.lowStockDynamicEquipmentTable.AllowUserToDeleteRows = false;
            this.lowStockDynamicEquipmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lowStockDynamicEquipmentTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.lowStockDynamicEquipmentTable.BackgroundColor = System.Drawing.Color.White;
            this.lowStockDynamicEquipmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lowStockDynamicEquipmentTable.Location = new System.Drawing.Point(25, 24);
            this.lowStockDynamicEquipmentTable.MultiSelect = false;
            this.lowStockDynamicEquipmentTable.Name = "lowStockDynamicEquipmentTable1";
            this.lowStockDynamicEquipmentTable.ReadOnly = true;
            this.lowStockDynamicEquipmentTable.RowHeadersWidth = 51;
            this.lowStockDynamicEquipmentTable.RowTemplate.Height = 30;
            this.lowStockDynamicEquipmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lowStockDynamicEquipmentTable.Size = new System.Drawing.Size(886, 367);
            this.lowStockDynamicEquipmentTable.TabIndex = 2;
            // 
            // LowStockDynamicEquipmentTransfers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 470);
            this.Controls.Add(this.lowStockDynamicEquipmentTable);
            this.Controls.Add(this.getFromButton);
            this.Name = "LowStockDynamicEquipmentTransfers";
            this.Text = "Low Stock Dynamic Equipment Transfers";
            this.Load += new System.EventHandler(this.LowStockDynamicEquipmentTransfers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lowStockDynamicEquipmentTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button getFromButton;
        private LowStockDynamicEquipmentTable lowStockDynamicEquipmentTable;
    }
}
using Klinika.Forms;

namespace Klinika.GUI.Secretary
{
    partial class DynamicEquipmentOrdering
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
            this.orderButton = new System.Windows.Forms.Button();
            this.quantityPicker = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.missingDynamicEquipmentTable = new Klinika.Forms.MissingDynamicEquipmentTable();
            ((System.ComponentModel.ISupportInitialize)(this.quantityPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingDynamicEquipmentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // orderButton
            // 
            this.orderButton.Enabled = false;
            this.orderButton.Location = new System.Drawing.Point(587, 420);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(94, 29);
            this.orderButton.TabIndex = 14;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.OrderButton_Click);
            // 
            // quantityPicker
            // 
            this.quantityPicker.Enabled = false;
            this.quantityPicker.Location = new System.Drawing.Point(258, 421);
            this.quantityPicker.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.quantityPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityPicker.Name = "quantityPicker";
            this.quantityPicker.Size = new System.Drawing.Size(226, 27);
            this.quantityPicker.TabIndex = 13;
            this.quantityPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Quantity: ";
            // 
            // missingDynamicEquipmentTable
            // 
            this.missingDynamicEquipmentTable.AllowUserToAddRows = false;
            this.missingDynamicEquipmentTable.AllowUserToDeleteRows = false;
            this.missingDynamicEquipmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.missingDynamicEquipmentTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.missingDynamicEquipmentTable.BackgroundColor = System.Drawing.Color.White;
            this.missingDynamicEquipmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.missingDynamicEquipmentTable.Location = new System.Drawing.Point(24, 19);
            this.missingDynamicEquipmentTable.MultiSelect = false;
            this.missingDynamicEquipmentTable.Name = "missingDynamicEquipmentTable";
            this.missingDynamicEquipmentTable.ReadOnly = true;
            this.missingDynamicEquipmentTable.RowHeadersWidth = 51;
            this.missingDynamicEquipmentTable.RowTemplate.Height = 29;
            this.missingDynamicEquipmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.missingDynamicEquipmentTable.Size = new System.Drawing.Size(920, 379);
            this.missingDynamicEquipmentTable.TabIndex = 15;
            this.missingDynamicEquipmentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MissingDynamicEquipmentTable_CellClick);
            // 
            // DynamicEquipmentOrdering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 479);
            this.Controls.Add(this.missingDynamicEquipmentTable);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.quantityPicker);
            this.Controls.Add(this.label5);
            this.Name = "DynamicEquipmentOrdering";
            this.Text = "Dynamic Equipment Ordering";
            this.Load += new System.EventHandler(this.DynamicEquipmentOrdering_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantityPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingDynamicEquipmentTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button orderButton;
        private NumericUpDown quantityPicker;
        private Label label5;
        private MissingDynamicEquipmentTable missingDynamicEquipmentTable;
    }
}
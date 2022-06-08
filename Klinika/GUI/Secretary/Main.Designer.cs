namespace Klinika.GUI.Secretary
{
    partial class mainWindow
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
            this.patientsButton = new System.Windows.Forms.Button();
            this.patientsRequestsButton = new System.Windows.Forms.Button();
            this.referralsButton = new System.Windows.Forms.Button();
            this.dynamicEquipmentOrderingButton = new System.Windows.Forms.Button();
            this.dynamicEquipmentTransfersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // patientsButton
            // 
            this.patientsButton.Location = new System.Drawing.Point(65, 25);
            this.patientsButton.Name = "patientsButton";
            this.patientsButton.Size = new System.Drawing.Size(248, 29);
            this.patientsButton.TabIndex = 0;
            this.patientsButton.Text = "Patients";
            this.patientsButton.UseVisualStyleBackColor = true;
            this.patientsButton.Click += new System.EventHandler(this.PatientsButton_Click);
            // 
            // patientsRequestsButton
            // 
            this.patientsRequestsButton.Location = new System.Drawing.Point(65, 83);
            this.patientsRequestsButton.Name = "patientsRequestsButton";
            this.patientsRequestsButton.Size = new System.Drawing.Size(248, 29);
            this.patientsRequestsButton.TabIndex = 1;
            this.patientsRequestsButton.Text = "Patients\' requests";
            this.patientsRequestsButton.UseVisualStyleBackColor = true;
            this.patientsRequestsButton.Click += new System.EventHandler(this.PatientsRequestsButton_Click);
            // 
            // referralsButton
            // 
            this.referralsButton.Location = new System.Drawing.Point(65, 149);
            this.referralsButton.Name = "referralsButton";
            this.referralsButton.Size = new System.Drawing.Size(248, 29);
            this.referralsButton.TabIndex = 2;
            this.referralsButton.Text = "Referrals";
            this.referralsButton.UseVisualStyleBackColor = true;
            this.referralsButton.Click += new System.EventHandler(this.ReferralsButton_Click);
            // 
            // dynamicEquipmentOrderingButton
            // 
            this.dynamicEquipmentOrderingButton.Location = new System.Drawing.Point(65, 208);
            this.dynamicEquipmentOrderingButton.Name = "dynamicEquipmentOrderingButton";
            this.dynamicEquipmentOrderingButton.Size = new System.Drawing.Size(248, 29);
            this.dynamicEquipmentOrderingButton.TabIndex = 3;
            this.dynamicEquipmentOrderingButton.Text = "Dynamic equipment ordering";
            this.dynamicEquipmentOrderingButton.UseVisualStyleBackColor = true;
            this.dynamicEquipmentOrderingButton.Click += new System.EventHandler(this.DynamicEquipmentOrderingButton_Click);
            // 
            // dynamicEquipmentTransfersButton
            // 
            this.dynamicEquipmentTransfersButton.Location = new System.Drawing.Point(65, 277);
            this.dynamicEquipmentTransfersButton.Name = "dynamicEquipmentTransfersButton";
            this.dynamicEquipmentTransfersButton.Size = new System.Drawing.Size(248, 29);
            this.dynamicEquipmentTransfersButton.TabIndex = 4;
            this.dynamicEquipmentTransfersButton.Text = "Dynamic equipment transfers";
            this.dynamicEquipmentTransfersButton.UseVisualStyleBackColor = true;
            this.dynamicEquipmentTransfersButton.Click += new System.EventHandler(this.DynamicEquipmentTransfersButton_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 341);
            this.Controls.Add(this.dynamicEquipmentTransfersButton);
            this.Controls.Add(this.dynamicEquipmentOrderingButton);
            this.Controls.Add(this.referralsButton);
            this.Controls.Add(this.patientsRequestsButton);
            this.Controls.Add(this.patientsButton);
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secretary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Button patientsButton;
        private Button patientsRequestsButton;
        private Button referralsButton;
        private Button dynamicEquipmentOrderingButton;
        private Button dynamicEquipmentTransfersButton;
    }
}
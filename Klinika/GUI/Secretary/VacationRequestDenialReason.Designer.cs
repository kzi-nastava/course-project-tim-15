namespace Klinika.GUI.Secretary
{
    partial class VacationRequestDenialReason
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
            this.denialReasonField = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // denialReasonField
            // 
            this.denialReasonField.Location = new System.Drawing.Point(21, 14);
            this.denialReasonField.Multiline = true;
            this.denialReasonField.Name = "denialReasonField";
            this.denialReasonField.Size = new System.Drawing.Size(421, 161);
            this.denialReasonField.TabIndex = 0;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(177, 194);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(94, 29);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // VacationRequestDenialReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 245);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.denialReasonField);
            this.Name = "VacationRequestDenialReason";
            this.Text = "Vacation Request Denial Reason";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox denialReasonField;
        private Button confirmButton;
    }
}
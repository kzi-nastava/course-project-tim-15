namespace Klinika.GUI.Secretary
{
    partial class UrgentScheduling
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
            this.label1 = new System.Windows.Forms.Label();
            this.patientSelection = new System.Windows.Forms.ComboBox();
            this.specializationSelection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient:";
            // 
            // patientSelection
            // 
            this.patientSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.patientSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patientSelection.FormattingEnabled = true;
            this.patientSelection.Location = new System.Drawing.Point(193, 54);
            this.patientSelection.Name = "patientSelection";
            this.patientSelection.Size = new System.Drawing.Size(230, 28);
            this.patientSelection.TabIndex = 1;
            // 
            // specializationSelection
            // 
            this.specializationSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.specializationSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.specializationSelection.FormattingEnabled = true;
            this.specializationSelection.Location = new System.Drawing.Point(193, 123);
            this.specializationSelection.Name = "specializationSelection";
            this.specializationSelection.Size = new System.Drawing.Size(230, 28);
            this.specializationSelection.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Doctor specialization:";
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(182, 328);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(94, 29);
            this.scheduleButton.TabIndex = 4;
            this.scheduleButton.Text = "Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Doctor:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(230, 27);
            this.textBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Appointment:";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(193, 261);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(230, 28);
            this.comboBox1.TabIndex = 8;
            // 
            // UrgentScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 391);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.specializationSelection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patientSelection);
            this.Controls.Add(this.label1);
            this.Name = "UrgentScheduling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Urgent Scheduling";
            this.Load += new System.EventHandler(this.UrgentScheduling_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox patientSelection;
        private ComboBox specializationSelection;
        private Label label2;
        private Button scheduleButton;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private ComboBox comboBox1;
    }
}
namespace Klinika.GUI.Manager
{
    partial class Renovation
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
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.noneRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitRadio = new System.Windows.Forms.RadioButton();
            this.mergeRadio = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Location = new System.Drawing.Point(264, 81);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(250, 27);
            this.fromDateTimePicker.TabIndex = 0;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Location = new System.Drawing.Point(264, 142);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(250, 27);
            this.toDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // noneRadio
            // 
            this.noneRadio.AutoSize = true;
            this.noneRadio.Location = new System.Drawing.Point(16, 47);
            this.noneRadio.Name = "noneRadio";
            this.noneRadio.Size = new System.Drawing.Size(66, 24);
            this.noneRadio.TabIndex = 4;
            this.noneRadio.TabStop = true;
            this.noneRadio.Text = "None";
            this.noneRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitRadio);
            this.groupBox1.Controls.Add(this.mergeRadio);
            this.groupBox1.Controls.Add(this.noneRadio);
            this.groupBox1.Location = new System.Drawing.Point(205, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced";
            // 
            // splitRadio
            // 
            this.splitRadio.AutoSize = true;
            this.splitRadio.Location = new System.Drawing.Point(214, 47);
            this.splitRadio.Name = "splitRadio";
            this.splitRadio.Size = new System.Drawing.Size(60, 24);
            this.splitRadio.TabIndex = 6;
            this.splitRadio.TabStop = true;
            this.splitRadio.Text = "Split";
            this.splitRadio.UseVisualStyleBackColor = true;
            // 
            // mergeRadio
            // 
            this.mergeRadio.AutoSize = true;
            this.mergeRadio.Location = new System.Drawing.Point(109, 47);
            this.mergeRadio.Name = "mergeRadio";
            this.mergeRadio.Size = new System.Drawing.Size(73, 24);
            this.mergeRadio.TabIndex = 5;
            this.mergeRadio.TabStop = true;
            this.mergeRadio.Text = "Merge";
            this.mergeRadio.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Commit renovation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Renovation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Name = "Renovation";
            this.Text = "Renovation";
            this.Load += new System.EventHandler(this.Renovation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker fromDateTimePicker;
        private DateTimePicker toDateTimePicker;
        private Label label1;
        private Label label2;
        private RadioButton noneRadio;
        private GroupBox groupBox1;
        private RadioButton splitRadio;
        private RadioButton mergeRadio;
        private Button button1;
    }
}
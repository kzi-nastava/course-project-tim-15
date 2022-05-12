namespace Klinika.GUI.Secretary
{
    partial class AddPatient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.genderSelection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.jmbgField = new System.Windows.Forms.MaskedTextBox();
            this.birthdatePicker = new System.Windows.Forms.DateTimePicker();
            this.nameField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.surnameField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.emailField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.genderSelection);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.jmbgField);
            this.groupBox1.Controls.Add(this.birthdatePicker);
            this.groupBox1.Controls.Add(this.nameField);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.surnameField);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Information";
            // 
            // genderSelection
            // 
            this.genderSelection.FormattingEnabled = true;
            this.genderSelection.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.genderSelection.Location = new System.Drawing.Point(325, 169);
            this.genderSelection.Name = "genderSelection";
            this.genderSelection.Size = new System.Drawing.Size(151, 28);
            this.genderSelection.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Gender:";
            // 
            // jmbgField
            // 
            this.jmbgField.Location = new System.Drawing.Point(115, 43);
            this.jmbgField.Mask = "0000000000000";
            this.jmbgField.Name = "jmbgField";
            this.jmbgField.Size = new System.Drawing.Size(206, 27);
            this.jmbgField.TabIndex = 9;
            this.jmbgField.ValidatingType = typeof(int);
            // 
            // birthdatePicker
            // 
            this.birthdatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdatePicker.Location = new System.Drawing.Point(490, 105);
            this.birthdatePicker.Name = "birthdatePicker";
            this.birthdatePicker.Size = new System.Drawing.Size(192, 27);
            this.birthdatePicker.TabIndex = 8;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(490, 43);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(192, 27);
            this.nameField.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Birthdate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
            // 
            // surnameField
            // 
            this.surnameField.Location = new System.Drawing.Point(115, 102);
            this.surnameField.Name = "surnameField";
            this.surnameField.Size = new System.Drawing.Size(206, 27);
            this.surnameField.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Surname:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "JMBG:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passwordField);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.emailField);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(797, 139);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Information";
            // 
            // passwordField
            // 
            this.passwordField.Location = new System.Drawing.Point(490, 61);
            this.passwordField.Name = "passwordField";
            this.passwordField.PlaceholderText = "4 characters minimum";
            this.passwordField.Size = new System.Drawing.Size(192, 27);
            this.passwordField.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Password:";
            // 
            // emailField
            // 
            this.emailField.Location = new System.Drawing.Point(115, 64);
            this.emailField.Name = "emailField";
            this.emailField.PlaceholderText = "example@mail.com";
            this.emailField.Size = new System.Drawing.Size(206, 27);
            this.emailField.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Email:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(356, 464);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 526);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddPatient";
            this.Text = "New Patient";
            this.Load += new System.EventHandler(this.AddPatient_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox genderSelection;
        private Label label5;
        private MaskedTextBox jmbgField;
        private DateTimePicker birthdatePicker;
        private TextBox nameField;
        private Label label4;
        private Label label2;
        private TextBox surnameField;
        private Label label3;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox passwordField;
        private Label label7;
        private Label label6;
        private Button addButton;
        private TextBox emailField;
    }
}
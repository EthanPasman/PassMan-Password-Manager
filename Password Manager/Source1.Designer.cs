namespace Password_Manager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewRB = new System.Windows.Forms.RadioButton();
            this.SearchRB = new System.Windows.Forms.RadioButton();
            this.GenRB = new System.Windows.Forms.RadioButton();
            this.PwmLbl = new System.Windows.Forms.Label();
            this.PwmTB = new System.Windows.Forms.TextBox();
            this.PwmBtn = new System.Windows.Forms.Button();
            this.EditRB = new System.Windows.Forms.RadioButton();
            this.PwmBtn2 = new System.Windows.Forms.Button();
            this.SpecialCB = new System.Windows.Forms.CheckBox();
            this.LengthTB = new System.Windows.Forms.TextBox();
            this.LengthLbl = new System.Windows.Forms.Label();
            this.AccountRB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // NewRB
            // 
            this.NewRB.AutoSize = true;
            this.NewRB.Location = new System.Drawing.Point(12, 12);
            this.NewRB.Name = "NewRB";
            this.NewRB.Size = new System.Drawing.Size(127, 19);
            this.NewRB.TabIndex = 0;
            this.NewRB.TabStop = true;
            this.NewRB.Text = "Add New Password";
            this.NewRB.UseVisualStyleBackColor = true;
            this.NewRB.CheckedChanged += new System.EventHandler(this.NewRB_CheckedChanged);
            // 
            // SearchRB
            // 
            this.SearchRB.AutoSize = true;
            this.SearchRB.Location = new System.Drawing.Point(145, 12);
            this.SearchRB.Name = "SearchRB";
            this.SearchRB.Size = new System.Drawing.Size(113, 19);
            this.SearchRB.TabIndex = 1;
            this.SearchRB.TabStop = true;
            this.SearchRB.Text = "Search Password";
            this.SearchRB.UseVisualStyleBackColor = true;
            this.SearchRB.CheckedChanged += new System.EventHandler(this.SearchRB_CheckedChanged);
            // 
            // GenRB
            // 
            this.GenRB.AutoSize = true;
            this.GenRB.Location = new System.Drawing.Point(368, 12);
            this.GenRB.Name = "GenRB";
            this.GenRB.Size = new System.Drawing.Size(173, 19);
            this.GenRB.TabIndex = 2;
            this.GenRB.TabStop = true;
            this.GenRB.Text = "Generate Random Password";
            this.GenRB.UseVisualStyleBackColor = true;
            this.GenRB.CheckedChanged += new System.EventHandler(this.GenRB_CheckedChanged);
            // 
            // PwmLbl
            // 
            this.PwmLbl.AutoSize = true;
            this.PwmLbl.Location = new System.Drawing.Point(12, 34);
            this.PwmLbl.Name = "PwmLbl";
            this.PwmLbl.Size = new System.Drawing.Size(35, 15);
            this.PwmLbl.TabIndex = 3;
            this.PwmLbl.Text = "Label";
            // 
            // PwmTB
            // 
            this.PwmTB.Location = new System.Drawing.Point(12, 52);
            this.PwmTB.Name = "PwmTB";
            this.PwmTB.Size = new System.Drawing.Size(529, 23);
            this.PwmTB.TabIndex = 4;
            // 
            // PwmBtn
            // 
            this.PwmBtn.Location = new System.Drawing.Point(12, 81);
            this.PwmBtn.Name = "PwmBtn";
            this.PwmBtn.Size = new System.Drawing.Size(127, 23);
            this.PwmBtn.TabIndex = 5;
            this.PwmBtn.Text = "Button";
            this.PwmBtn.UseVisualStyleBackColor = true;
            this.PwmBtn.Click += new System.EventHandler(this.PwmBtn_Click);
            // 
            // EditRB
            // 
            this.EditRB.AutoSize = true;
            this.EditRB.Location = new System.Drawing.Point(264, 12);
            this.EditRB.Name = "EditRB";
            this.EditRB.Size = new System.Drawing.Size(98, 19);
            this.EditRB.TabIndex = 6;
            this.EditRB.TabStop = true;
            this.EditRB.Text = "Edit Password";
            this.EditRB.UseVisualStyleBackColor = true;
            this.EditRB.CheckedChanged += new System.EventHandler(this.EditRB_CheckedChanged);
            // 
            // PwmBtn2
            // 
            this.PwmBtn2.Location = new System.Drawing.Point(414, 81);
            this.PwmBtn2.Name = "PwmBtn2";
            this.PwmBtn2.Size = new System.Drawing.Size(127, 23);
            this.PwmBtn2.TabIndex = 7;
            this.PwmBtn2.Text = "Button2";
            this.PwmBtn2.UseVisualStyleBackColor = true;
            this.PwmBtn2.Click += new System.EventHandler(this.PwmBtn2_Click);
            // 
            // SpecialCB
            // 
            this.SpecialCB.AutoSize = true;
            this.SpecialCB.Location = new System.Drawing.Point(53, 127);
            this.SpecialCB.Name = "SpecialCB";
            this.SpecialCB.Size = new System.Drawing.Size(122, 19);
            this.SpecialCB.TabIndex = 8;
            this.SpecialCB.Text = "Special Characters";
            this.SpecialCB.UseVisualStyleBackColor = true;
            // 
            // LengthTB
            // 
            this.LengthTB.Location = new System.Drawing.Point(12, 125);
            this.LengthTB.MaxLength = 3;
            this.LengthTB.Name = "LengthTB";
            this.LengthTB.Size = new System.Drawing.Size(35, 23);
            this.LengthTB.TabIndex = 9;
            this.LengthTB.Text = "20";
            this.LengthTB.TextChanged += new System.EventHandler(this.LengthTB_TextChanged);
            // 
            // LengthLbl
            // 
            this.LengthLbl.AutoSize = true;
            this.LengthLbl.Location = new System.Drawing.Point(12, 107);
            this.LengthLbl.Name = "LengthLbl";
            this.LengthLbl.Size = new System.Drawing.Size(188, 15);
            this.LengthLbl.TabIndex = 10;
            this.LengthLbl.Text = "Password Length (Min 8, Max 127)";
            // 
            // AccountRB
            // 
            this.AccountRB.AutoSize = true;
            this.AccountRB.Location = new System.Drawing.Point(426, 127);
            this.AccountRB.Name = "AccountRB";
            this.AccountRB.Size = new System.Drawing.Size(115, 19);
            this.AccountRB.TabIndex = 12;
            this.AccountRB.TabStop = true;
            this.AccountRB.Text = "Account Settings";
            this.AccountRB.UseVisualStyleBackColor = true;
            this.AccountRB.CheckedChanged += new System.EventHandler(this.AccountRB_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 162);
            this.Controls.Add(this.AccountRB);
            this.Controls.Add(this.LengthLbl);
            this.Controls.Add(this.LengthTB);
            this.Controls.Add(this.SpecialCB);
            this.Controls.Add(this.PwmBtn2);
            this.Controls.Add(this.EditRB);
            this.Controls.Add(this.PwmBtn);
            this.Controls.Add(this.PwmTB);
            this.Controls.Add(this.PwmLbl);
            this.Controls.Add(this.GenRB);
            this.Controls.Add(this.SearchRB);
            this.Controls.Add(this.NewRB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Password Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton NewRB;
        private RadioButton SearchRB;
        private RadioButton GenRB;
        private Label PwmLbl;
        private TextBox PwmTB;
        private Button PwmBtn;
        private RadioButton EditRB;
        private Button PwmBtn2;
        private CheckBox SpecialCB;
        private TextBox LengthTB;
        private Label LengthLbl;
        private RadioButton AccountRB;
    }
}
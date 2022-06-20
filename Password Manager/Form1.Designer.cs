namespace Password_Manager
{
    partial class LoginForm
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
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RegBtn = new System.Windows.Forms.Button();
            this.SecBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(87, 112);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 0;
            this.LoginBtn.Text = "Log In";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // UserTextBox
            // 
            this.UserTextBox.Location = new System.Drawing.Point(87, 54);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(190, 23);
            this.UserTextBox.TabIndex = 3;
            // 
            // PassTextBox
            // 
            this.PassTextBox.Location = new System.Drawing.Point(87, 83);
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.PasswordChar = '*';
            this.PassTextBox.Size = new System.Drawing.Size(190, 23);
            this.PassTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Helvetica", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password Manager";
            // 
            // RegBtn
            // 
            this.RegBtn.Location = new System.Drawing.Point(202, 112);
            this.RegBtn.Name = "RegBtn";
            this.RegBtn.Size = new System.Drawing.Size(75, 23);
            this.RegBtn.TabIndex = 6;
            this.RegBtn.Text = "Register";
            this.RegBtn.UseVisualStyleBackColor = true;
            this.RegBtn.Click += new System.EventHandler(this.RegBtn_Click);
            // 
            // SecBtn
            // 
            this.SecBtn.Location = new System.Drawing.Point(164, 152);
            this.SecBtn.Name = "SecBtn";
            this.SecBtn.Size = new System.Drawing.Size(113, 23);
            this.SecBtn.TabIndex = 7;
            this.SecBtn.Text = "Security Overview";
            this.SecBtn.UseVisualStyleBackColor = true;
            this.SecBtn.Click += new System.EventHandler(this.SecBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 187);
            this.Controls.Add(this.SecBtn);
            this.Controls.Add(this.RegBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PassTextBox);
            this.Controls.Add(this.UserTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.Text = "Password Manager - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button LoginBtn;
        private Label label1;
        private Label label2;
        private TextBox UserTextBox;
        private TextBox PassTextBox;
        private Label label3;
        private Button RegBtn;
        private Button SecBtn;
    }
}
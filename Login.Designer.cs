namespace Jegyfoglalo
{
    partial class Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.textBox_pw = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.checkBox_Show_Hide = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bejelentkezés";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Felhasználónév";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jelszó";
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(176, 116);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(210, 22);
            this.textBox_user.TabIndex = 3;
            // 
            // textBox_pw
            // 
            this.textBox_pw.Location = new System.Drawing.Point(176, 168);
            this.textBox_pw.Name = "textBox_pw";
            this.textBox_pw.Size = new System.Drawing.Size(210, 22);
            this.textBox_pw.TabIndex = 4;
            this.textBox_pw.UseSystemPasswordChar = true;
            this.textBox_pw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_pw_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(412, 216);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(89, 34);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Belépés";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // checkBox_Show_Hide
            // 
            this.checkBox_Show_Hide.AutoSize = true;
            this.checkBox_Show_Hide.Location = new System.Drawing.Point(412, 170);
            this.checkBox_Show_Hide.Name = "checkBox_Show_Hide";
            this.checkBox_Show_Hide.Size = new System.Drawing.Size(76, 21);
            this.checkBox_Show_Hide.TabIndex = 6;
            this.checkBox_Show_Hide.Text = "Mutasd";
            this.checkBox_Show_Hide.UseVisualStyleBackColor = true;
            this.checkBox_Show_Hide.CheckedChanged += new System.EventHandler(this.checkBox_Show_Hide_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 298);
            this.Controls.Add(this.checkBox_Show_Hide);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBox_pw);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.TextBox textBox_pw;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox checkBox_Show_Hide;
    }
}


namespace CarClient
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.status = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.mail = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.status2 = new System.Windows.Forms.Label();
            this.addAccount = new System.Windows.Forms.Button();
            this.newMail = new System.Windows.Forms.TextBox();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.newName = new System.Windows.Forms.TextBox();
            this.newSurname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(321, 67);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(35, 13);
            this.status.TabIndex = 0;
            this.status.Text = "status";
            this.status.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(219, 62);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(96, 23);
            this.buttonLogin.TabIndex = 1;
            this.buttonLogin.Text = "Log in";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(113, 38);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(100, 20);
            this.mail.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(113, 64);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mail);
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonLogin);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 96);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login to Super Car Rent";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.status2);
            this.groupBox2.Controls.Add(this.addAccount);
            this.groupBox2.Controls.Add(this.newMail);
            this.groupBox2.Controls.Add(this.newPassword);
            this.groupBox2.Controls.Add(this.newName);
            this.groupBox2.Controls.Add(this.newSurname);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 158);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Customer";
            // 
            // status2
            // 
            this.status2.AutoSize = true;
            this.status2.Location = new System.Drawing.Point(321, 124);
            this.status2.Name = "status2";
            this.status2.Size = new System.Drawing.Size(35, 13);
            this.status2.TabIndex = 7;
            this.status2.Text = "status";
            // 
            // addAccount
            // 
            this.addAccount.Location = new System.Drawing.Point(219, 119);
            this.addAccount.Name = "addAccount";
            this.addAccount.Size = new System.Drawing.Size(96, 23);
            this.addAccount.TabIndex = 8;
            this.addAccount.Text = "Add account";
            this.addAccount.UseVisualStyleBackColor = true;
            this.addAccount.Click += new System.EventHandler(this.addAccount_Click);
            // 
            // newMail
            // 
            this.newMail.Location = new System.Drawing.Point(113, 95);
            this.newMail.Name = "newMail";
            this.newMail.Size = new System.Drawing.Size(100, 20);
            this.newMail.TabIndex = 7;
            // 
            // newPassword
            // 
            this.newPassword.Location = new System.Drawing.Point(113, 121);
            this.newPassword.Name = "newPassword";
            this.newPassword.PasswordChar = '*';
            this.newPassword.Size = new System.Drawing.Size(100, 20);
            this.newPassword.TabIndex = 6;
            // 
            // newName
            // 
            this.newName.Location = new System.Drawing.Point(113, 43);
            this.newName.Name = "newName";
            this.newName.Size = new System.Drawing.Size(100, 20);
            this.newName.TabIndex = 5;
            // 
            // newSurname
            // 
            this.newSurname.Location = new System.Drawing.Point(113, 69);
            this.newSurname.Name = "newSurname";
            this.newSurname.Size = new System.Drawing.Size(100, 20);
            this.newSurname.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Surname:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 313);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Super Car Rent";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label status2;
        private System.Windows.Forms.Button addAccount;
        private System.Windows.Forms.TextBox newMail;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.TextBox newName;
        private System.Windows.Forms.TextBox newSurname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}


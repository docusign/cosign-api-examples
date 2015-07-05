namespace DOCXsample
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
            this.gbFile = new System.Windows.Forms.GroupBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnCloseFile = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSign = new System.Windows.Forms.GroupBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.lstFields = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.btnLogon = new System.Windows.Forms.Button();
            this.gbFile.SuspendLayout();
            this.gbSign.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFile
            // 
            this.gbFile.Controls.Add(this.btnOpenFile);
            this.gbFile.Controls.Add(this.btnCloseFile);
            this.gbFile.Controls.Add(this.btnBrowse);
            this.gbFile.Controls.Add(this.txtFile);
            this.gbFile.Controls.Add(this.label1);
            this.gbFile.Enabled = false;
            this.gbFile.Location = new System.Drawing.Point(12, 140);
            this.gbFile.Name = "gbFile";
            this.gbFile.Size = new System.Drawing.Size(323, 104);
            this.gbFile.TabIndex = 0;
            this.gbFile.TabStop = false;
            this.gbFile.Text = "File to Sign";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(9, 69);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnCloseFile
            // 
            this.btnCloseFile.Enabled = false;
            this.btnCloseFile.Location = new System.Drawing.Point(90, 69);
            this.btnCloseFile.Name = "btnCloseFile";
            this.btnCloseFile.Size = new System.Drawing.Size(81, 23);
            this.btnCloseFile.TabIndex = 9;
            this.btnCloseFile.Text = "Close";
            this.btnCloseFile.UseVisualStyleBackColor = true;
            this.btnCloseFile.Click += new System.EventHandler(this.btnCloseFile_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(238, 40);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(9, 43);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(223, 20);
            this.txtFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select File to sign";
            // 
            // gbSign
            // 
            this.gbSign.Controls.Add(this.btnSign);
            this.gbSign.Controls.Add(this.lstFields);
            this.gbSign.Controls.Add(this.label2);
            this.gbSign.Enabled = false;
            this.gbSign.Location = new System.Drawing.Point(12, 258);
            this.gbSign.Name = "gbSign";
            this.gbSign.Size = new System.Drawing.Size(323, 251);
            this.gbSign.TabIndex = 1;
            this.gbSign.TabStop = false;
            this.gbSign.Text = "Signin/Verify";
            // 
            // btnSign
            // 
            this.btnSign.Enabled = false;
            this.btnSign.Location = new System.Drawing.Point(9, 220);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(90, 23);
            this.btnSign.TabIndex = 8;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // lstFields
            // 
            this.lstFields.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstFields.FormattingEnabled = true;
            this.lstFields.ItemHeight = 14;
            this.lstFields.Location = new System.Drawing.Point(9, 41);
            this.lstFields.Name = "lstFields";
            this.lstFields.Size = new System.Drawing.Size(304, 172);
            this.lstFields.TabIndex = 1;
            this.lstFields.SelectedIndexChanged += new System.EventHandler(this.lstFields_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Please select Signature Field to Sign";
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(17, 32);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(55, 13);
            this.Label.TabIndex = 2;
            this.Label.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Domain";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(78, 29);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(154, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(78, 56);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(154, 20);
            this.txtDomain.TabIndex = 6;
            this.txtDomain.Text = " ";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(78, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(154, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnLogoff);
            this.gbLogin.Controls.Add(this.btnLogon);
            this.gbLogin.Controls.Add(this.txtUsername);
            this.gbLogin.Controls.Add(this.Label);
            this.gbLogin.Controls.Add(this.label4);
            this.gbLogin.Controls.Add(this.txtPassword);
            this.gbLogin.Controls.Add(this.label5);
            this.gbLogin.Controls.Add(this.txtDomain);
            this.gbLogin.Location = new System.Drawing.Point(12, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(323, 122);
            this.gbLogin.TabIndex = 2;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "User";
            // 
            // btnLogoff
            // 
            this.btnLogoff.Enabled = false;
            this.btnLogoff.Location = new System.Drawing.Point(238, 80);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(75, 23);
            this.btnLogoff.TabIndex = 9;
            this.btnLogoff.Text = "Logoff";
            this.btnLogoff.UseVisualStyleBackColor = true;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(238, 29);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(75, 23);
            this.btnLogon.TabIndex = 8;
            this.btnLogon.Text = "Logon";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 519);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.gbSign);
            this.Controls.Add(this.gbFile);
            this.Name = "Form1";
            this.Text = "DOCX Signer";
            this.gbFile.ResumeLayout(false);
            this.gbFile.PerformLayout();
            this.gbSign.ResumeLayout(false);
            this.gbSign.PerformLayout();
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSign;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.ListBox lstFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnCloseFile;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Button btnLogoff;
        private System.Windows.Forms.Button btnLogon;
    }
}


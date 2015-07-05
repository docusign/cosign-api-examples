namespace XMLSign
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
            this.lblShowCert = new System.Windows.Forms.Label();
            this.txtFileToVerify = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSigningTime = new System.Windows.Forms.Label();
            this.chkIsValid = new System.Windows.Forms.CheckBox();
            this.lblSignerName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabVerify = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabSign = new System.Windows.Forms.TabPage();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSign = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.tabVerify.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabSign.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblShowCert
            // 
            this.lblShowCert.AutoSize = true;
            this.lblShowCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblShowCert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblShowCert.Location = new System.Drawing.Point(79, 52);
            this.lblShowCert.Name = "lblShowCert";
            this.lblShowCert.Size = new System.Drawing.Size(94, 13);
            this.lblShowCert.TabIndex = 7;
            this.lblShowCert.Text = "Signer\'s Certificate";
            this.lblShowCert.Click += new System.EventHandler(this.lblShowCert_Click);
            this.lblShowCert.MouseEnter += new System.EventHandler(this.lblShowCert_MouseEnter);
            this.lblShowCert.MouseLeave += new System.EventHandler(this.lblShowCert_MouseLeave);
            // 
            // txtFileToVerify
            // 
            this.txtFileToVerify.Location = new System.Drawing.Point(9, 42);
            this.txtFileToVerify.Name = "txtFileToVerify";
            this.txtFileToVerify.Size = new System.Drawing.Size(210, 20);
            this.txtFileToVerify.TabIndex = 3;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(6, 130);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(304, 23);
            this.btnVerify.TabIndex = 2;
            this.btnVerify.Text = "Verify Signature";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblShowCert);
            this.groupBox3.Controls.Add(this.lblSigningTime);
            this.groupBox3.Controls.Add(this.chkIsValid);
            this.groupBox3.Controls.Add(this.lblSignerName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(7, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(303, 109);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Signature Details";
            // 
            // lblSigningTime
            // 
            this.lblSigningTime.BackColor = System.Drawing.Color.White;
            this.lblSigningTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSigningTime.Location = new System.Drawing.Point(82, 76);
            this.lblSigningTime.Name = "lblSigningTime";
            this.lblSigningTime.Size = new System.Drawing.Size(211, 18);
            this.lblSigningTime.TabIndex = 6;
            this.lblSigningTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIsValid
            // 
            this.chkIsValid.AutoSize = true;
            this.chkIsValid.Enabled = false;
            this.chkIsValid.Location = new System.Drawing.Point(225, 23);
            this.chkIsValid.Name = "chkIsValid";
            this.chkIsValid.Size = new System.Drawing.Size(49, 17);
            this.chkIsValid.TabIndex = 4;
            this.chkIsValid.Text = "Valid";
            this.chkIsValid.UseVisualStyleBackColor = true;
            // 
            // lblSignerName
            // 
            this.lblSignerName.BackColor = System.Drawing.Color.White;
            this.lblSignerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSignerName.Location = new System.Drawing.Point(82, 23);
            this.lblSignerName.Name = "lblSignerName";
            this.lblSignerName.Size = new System.Drawing.Size(100, 18);
            this.lblSignerName.TabIndex = 3;
            this.lblSignerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Signing Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Signer Name:";
            // 
            // tabVerify
            // 
            this.tabVerify.Controls.Add(this.btnVerify);
            this.tabVerify.Controls.Add(this.groupBox3);
            this.tabVerify.Controls.Add(this.groupBox2);
            this.tabVerify.Location = new System.Drawing.Point(4, 22);
            this.tabVerify.Name = "tabVerify";
            this.tabVerify.Padding = new System.Windows.Forms.Padding(3);
            this.tabVerify.Size = new System.Drawing.Size(316, 274);
            this.tabVerify.TabIndex = 1;
            this.tabVerify.Text = "Verify Signature";
            this.tabVerify.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseFile);
            this.groupBox2.Controls.Add(this.txtFileToVerify);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 77);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contents";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(225, 40);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(72, 23);
            this.btnBrowseFile.TabIndex = 4;
            this.btnBrowseFile.Text = "Browse...";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Signed XML file";
            // 
            // tabSign
            // 
            this.tabSign.Controls.Add(this.gbLogin);
            this.tabSign.Controls.Add(this.groupBox1);
            this.tabSign.Controls.Add(this.btnSign);
            this.tabSign.Location = new System.Drawing.Point(4, 22);
            this.tabSign.Name = "tabSign";
            this.tabSign.Padding = new System.Windows.Forms.Padding(3);
            this.tabSign.Size = new System.Drawing.Size(316, 274);
            this.tabSign.TabIndex = 0;
            this.tabSign.Text = "Sign XML";
            this.tabSign.UseVisualStyleBackColor = true;
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.txtUsername);
            this.gbLogin.Controls.Add(this.Label);
            this.gbLogin.Controls.Add(this.label4);
            this.gbLogin.Controls.Add(this.txtPassword);
            this.gbLogin.Controls.Add(this.label5);
            this.gbLogin.Controls.Add(this.txtDomain);
            this.gbLogin.Location = new System.Drawing.Point(6, 6);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(298, 122);
            this.gbLogin.TabIndex = 3;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "User";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(78, 29);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(214, 20);
            this.txtUsername.TabIndex = 5;
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
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(78, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(214, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
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
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(78, 56);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(214, 20);
            this.txtDomain.TabIndex = 6;
            this.txtDomain.Text = " ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 95);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML to sign";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(219, 56);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(72, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(10, 56);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(202, 20);
            this.txtFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select an XML file, which content will be signed";
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(7, 239);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 23);
            this.btnSign.TabIndex = 5;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSign);
            this.tabControl1.Controls.Add(this.tabVerify);
            this.tabControl1.Location = new System.Drawing.Point(13, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(324, 300);
            this.tabControl1.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(262, 321);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 355);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabVerify.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabSign.ResumeLayout(false);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblShowCert;
        private System.Windows.Forms.TextBox txtFileToVerify;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSigningTime;
        private System.Windows.Forms.CheckBox chkIsValid;
        private System.Windows.Forms.Label lblSignerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabVerify;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabSign;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnExit;
    }
}


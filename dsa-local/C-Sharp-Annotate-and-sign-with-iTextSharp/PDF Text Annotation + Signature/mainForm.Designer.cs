namespace PDF_Annotation_Signature
{
    partial class mainForm
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
            this.buttonSign = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelDomain = new System.Windows.Forms.Label();
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxPDF = new System.Windows.Forms.TextBox();
            this.buttonBrowsePDF = new System.Windows.Forms.Button();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.groupBoxBrowse = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.groupBoxTitle = new System.Windows.Forms.GroupBox();
            this.groupBoxCredentials.SuspendLayout();
            this.groupBoxBrowse.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSign
            // 
            this.buttonSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonSign.Location = new System.Drawing.Point(12, 427);
            this.buttonSign.Name = "buttonSign";
            this.buttonSign.Size = new System.Drawing.Size(302, 28);
            this.buttonSign.TabIndex = 100;
            this.buttonSign.Text = "Sign with CoSign";
            this.buttonSign.UseVisualStyleBackColor = true;
            this.buttonSign.Click += new System.EventHandler(this.buttonSign_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(9, 41);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(83, 20);
            this.textBoxUsername.TabIndex = 50;
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.Location = new System.Drawing.Point(110, 41);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(83, 20);
            this.textBoxDomain.TabIndex = 60;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(6, 25);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Username";
            // 
            // labelDomain
            // 
            this.labelDomain.AutoSize = true;
            this.labelDomain.Location = new System.Drawing.Point(107, 25);
            this.labelDomain.Name = "labelDomain";
            this.labelDomain.Size = new System.Drawing.Size(43, 13);
            this.labelDomain.TabIndex = 4;
            this.labelDomain.Text = "Domain";
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxCredentials.Controls.Add(this.labelPassword);
            this.groupBoxCredentials.Controls.Add(this.textBoxPassword);
            this.groupBoxCredentials.Controls.Add(this.labelUsername);
            this.groupBoxCredentials.Controls.Add(this.textBoxUsername);
            this.groupBoxCredentials.Controls.Add(this.labelDomain);
            this.groupBoxCredentials.Controls.Add(this.textBoxDomain);
            this.groupBoxCredentials.Location = new System.Drawing.Point(12, 76);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(302, 72);
            this.groupBoxCredentials.TabIndex = 45;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "User Authentication";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(206, 25);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(209, 41);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(83, 20);
            this.textBoxPassword.TabIndex = 70;
            // 
            // textBoxPDF
            // 
            this.textBoxPDF.Location = new System.Drawing.Point(9, 19);
            this.textBoxPDF.Name = "textBoxPDF";
            this.textBoxPDF.Size = new System.Drawing.Size(197, 20);
            this.textBoxPDF.TabIndex = 10;
            // 
            // buttonBrowsePDF
            // 
            this.buttonBrowsePDF.Location = new System.Drawing.Point(212, 17);
            this.buttonBrowsePDF.Name = "buttonBrowsePDF";
            this.buttonBrowsePDF.Size = new System.Drawing.Size(80, 23);
            this.buttonBrowsePDF.TabIndex = 20;
            this.buttonBrowsePDF.Text = "Browse";
            this.buttonBrowsePDF.UseVisualStyleBackColor = true;
            this.buttonBrowsePDF.Click += new System.EventHandler(this.buttonBrowsePDF_Click);
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Location = new System.Drawing.Point(6, 24);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(49, 13);
            this.labelRemarks.TabIndex = 10;
            this.labelRemarks.Text = "Contents";
            // 
            // groupBoxBrowse
            // 
            this.groupBoxBrowse.Controls.Add(this.buttonBrowsePDF);
            this.groupBoxBrowse.Controls.Add(this.textBoxPDF);
            this.groupBoxBrowse.Location = new System.Drawing.Point(12, 15);
            this.groupBoxBrowse.Name = "groupBoxBrowse";
            this.groupBoxBrowse.Size = new System.Drawing.Size(302, 52);
            this.groupBoxBrowse.TabIndex = 5;
            this.groupBoxBrowse.TabStop = false;
            this.groupBoxBrowse.Text = "PDF to Sign";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPage);
            this.groupBox1.Controls.Add(this.textBoxPage);
            this.groupBox1.Controls.Add(this.labelY);
            this.groupBox1.Controls.Add(this.labelX);
            this.groupBox1.Controls.Add(this.textBoxRemarks);
            this.groupBox1.Controls.Add(this.textBoxX);
            this.groupBox1.Controls.Add(this.textBoxY);
            this.groupBox1.Controls.Add(this.labelRemarks);
            this.groupBox1.Location = new System.Drawing.Point(12, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 199);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memo";
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(9, 155);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(52, 13);
            this.labelPage.TabIndex = 91;
            this.labelPage.Text = "Page No.";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(12, 171);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(83, 20);
            this.textBoxPage.TabIndex = 92;
            this.textBoxPage.Text = "1";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(203, 155);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(68, 13);
            this.labelY.TabIndex = 4;
            this.labelY.Text = "Y Coordinate";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(107, 155);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(68, 13);
            this.labelX.TabIndex = 3;
            this.labelX.Text = "X Coordinate";
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxRemarks.Location = new System.Drawing.Point(9, 40);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(278, 100);
            this.textBoxRemarks.TabIndex = 75;
            this.textBoxRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRemarks_KeyPress);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(110, 171);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(78, 20);
            this.textBoxX.TabIndex = 80;
            this.textBoxX.Text = "225";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(206, 171);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(83, 20);
            this.textBoxY.TabIndex = 90;
            this.textBoxY.Text = "500";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(24, 380);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(277, 20);
            this.textBoxTitle.TabIndex = 72;
            // 
            // groupBoxTitle
            // 
            this.groupBoxTitle.Location = new System.Drawing.Point(12, 362);
            this.groupBoxTitle.Name = "groupBoxTitle";
            this.groupBoxTitle.Size = new System.Drawing.Size(302, 50);
            this.groupBoxTitle.TabIndex = 101;
            this.groupBoxTitle.TabStop = false;
            this.groupBoxTitle.Text = "Signer\'s Title (Optional)";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 467);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonSign);
            this.Controls.Add(this.groupBoxCredentials);
            this.Controls.Add(this.groupBoxBrowse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxTitle);
            this.Name = "mainForm";
            this.Text = "PDF Text Annotation + Signature";
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            this.groupBoxBrowse.ResumeLayout(false);
            this.groupBoxBrowse.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSign;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelDomain;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxPDF;
        private System.Windows.Forms.Button buttonBrowsePDF;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.GroupBox groupBoxBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.GroupBox groupBoxTitle;
    }
}


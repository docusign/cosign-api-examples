using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CSPdfSign
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox FileUrl;
		private System.Windows.Forms.Button BrowseBut;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox PageBox;
		private System.Windows.Forms.TextBox XBox;
		private System.Windows.Forms.TextBox YBox;
		private System.Windows.Forms.TextBox WBox;
		private System.Windows.Forms.TextBox HBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox UserBox;
		private System.Windows.Forms.TextBox PassBox;
        private Label label10;
        private TextBox txtReason;
        private RadioButton rbCreateNew;
        private GroupBox gbCreateNew;
        private RadioButton rbSignExisting;
        private GroupBox gbSignExisting;
        private TextBox txtFieldName;
        private Label label11;
        private GroupBox groupBox1;
        private CheckBox chkSignTime;
        private CheckBox chkReason;
        private CheckBox chkGraphicalImage;
        private CheckBox chkName;
        private TextBox txtNewSigFieldName;
        private Label label12;
        private Label label13;
        private TextBox txtGraphSig;
        private Label label14;
        private TextBox signPassBox;
        private CheckBox chkPFS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.FileUrl = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BrowseBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PageBox = new System.Windows.Forms.TextBox();
            this.XBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.YBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.rbCreateNew = new System.Windows.Forms.RadioButton();
            this.gbCreateNew = new System.Windows.Forms.GroupBox();
            this.txtNewSigFieldName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSignTime = new System.Windows.Forms.CheckBox();
            this.chkReason = new System.Windows.Forms.CheckBox();
            this.chkGraphicalImage = new System.Windows.Forms.CheckBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.rbSignExisting = new System.Windows.Forms.RadioButton();
            this.gbSignExisting = new System.Windows.Forms.GroupBox();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGraphSig = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.signPassBox = new System.Windows.Forms.TextBox();
            this.chkPFS = new System.Windows.Forms.CheckBox();
            this.gbCreateNew.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSignExisting.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileUrl
            // 
            this.FileUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FileUrl.Location = new System.Drawing.Point(16, 32);
            this.FileUrl.Name = "FileUrl";
            this.FileUrl.Size = new System.Drawing.Size(328, 23);
            this.FileUrl.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PDF files | *.pdf";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // BrowseBut
            // 
            this.BrowseBut.Location = new System.Drawing.Point(350, 32);
            this.BrowseBut.Name = "BrowseBut";
            this.BrowseBut.Size = new System.Drawing.Size(96, 24);
            this.BrowseBut.TabIndex = 1;
            this.BrowseBut.Text = "Browse";
            this.BrowseBut.Click += new System.EventHandler(this.BrowseBut_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "PDF to be signed";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Page:";
            // 
            // PageBox
            // 
            this.PageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PageBox.Location = new System.Drawing.Point(72, 43);
            this.PageBox.Name = "PageBox";
            this.PageBox.Size = new System.Drawing.Size(104, 23);
            this.PageBox.TabIndex = 4;
            this.PageBox.Text = "1";
            // 
            // XBox
            // 
            this.XBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.XBox.Location = new System.Drawing.Point(72, 75);
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(104, 23);
            this.XBox.TabIndex = 6;
            this.XBox.Text = "100";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "X:";
            // 
            // YBox
            // 
            this.YBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.YBox.Location = new System.Drawing.Point(72, 107);
            this.YBox.Name = "YBox";
            this.YBox.Size = new System.Drawing.Size(104, 23);
            this.YBox.TabIndex = 8;
            this.YBox.Text = "100";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y:";
            // 
            // WBox
            // 
            this.WBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.WBox.Location = new System.Drawing.Point(240, 43);
            this.WBox.Name = "WBox";
            this.WBox.Size = new System.Drawing.Size(104, 23);
            this.WBox.TabIndex = 10;
            this.WBox.Text = "150";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(192, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Width:";
            // 
            // HBox
            // 
            this.HBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.HBox.Location = new System.Drawing.Point(240, 75);
            this.HBox.Name = "HBox";
            this.HBox.Size = new System.Drawing.Size(104, 23);
            this.HBox.TabIndex = 12;
            this.HBox.Text = "80";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(192, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Height:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(192, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Visible:";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(240, 115);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(32, 16);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 56);
            this.button1.TabIndex = 15;
            this.button1.Text = "Sign";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserBox
            // 
            this.UserBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserBox.Location = new System.Drawing.Point(95, 479);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(190, 23);
            this.UserBox.TabIndex = 17;
            this.UserBox.Text = "John Miller";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 487);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "UserName:";
            // 
            // PassBox
            // 
            this.PassBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PassBox.Location = new System.Drawing.Point(95, 511);
            this.PassBox.Name = "PassBox";
            this.PassBox.PasswordChar = '*';
            this.PassBox.Size = new System.Drawing.Size(190, 23);
            this.PassBox.TabIndex = 19;
            this.PassBox.Text = "12345678";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 519);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(66, 68);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(380, 20);
            this.txtReason.TabIndex = 21;
            // 
            // rbCreateNew
            // 
            this.rbCreateNew.AutoSize = true;
            this.rbCreateNew.Checked = true;
            this.rbCreateNew.Location = new System.Drawing.Point(13, 134);
            this.rbCreateNew.Name = "rbCreateNew";
            this.rbCreateNew.Size = new System.Drawing.Size(200, 17);
            this.rbCreateNew.TabIndex = 22;
            this.rbCreateNew.TabStop = true;
            this.rbCreateNew.Text = "Create new Signature Field in the File";
            this.rbCreateNew.UseVisualStyleBackColor = true;
            this.rbCreateNew.CheckedChanged += new System.EventHandler(this.rbCreateNew_CheckedChanged);
            // 
            // gbCreateNew
            // 
            this.gbCreateNew.Controls.Add(this.txtNewSigFieldName);
            this.gbCreateNew.Controls.Add(this.label12);
            this.gbCreateNew.Controls.Add(this.groupBox1);
            this.gbCreateNew.Controls.Add(this.WBox);
            this.gbCreateNew.Controls.Add(this.label2);
            this.gbCreateNew.Controls.Add(this.PageBox);
            this.gbCreateNew.Controls.Add(this.label3);
            this.gbCreateNew.Controls.Add(this.XBox);
            this.gbCreateNew.Controls.Add(this.label4);
            this.gbCreateNew.Controls.Add(this.YBox);
            this.gbCreateNew.Controls.Add(this.label5);
            this.gbCreateNew.Controls.Add(this.label6);
            this.gbCreateNew.Controls.Add(this.checkBox1);
            this.gbCreateNew.Controls.Add(this.HBox);
            this.gbCreateNew.Controls.Add(this.label7);
            this.gbCreateNew.Location = new System.Drawing.Point(32, 157);
            this.gbCreateNew.Name = "gbCreateNew";
            this.gbCreateNew.Size = new System.Drawing.Size(414, 190);
            this.gbCreateNew.TabIndex = 23;
            this.gbCreateNew.TabStop = false;
            // 
            // txtNewSigFieldName
            // 
            this.txtNewSigFieldName.Location = new System.Drawing.Point(123, 13);
            this.txtNewSigFieldName.Name = "txtNewSigFieldName";
            this.txtNewSigFieldName.Size = new System.Drawing.Size(273, 20);
            this.txtNewSigFieldName.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Signature Field Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSignTime);
            this.groupBox1.Controls.Add(this.chkReason);
            this.groupBox1.Controls.Add(this.chkGraphicalImage);
            this.groupBox1.Controls.Add(this.chkName);
            this.groupBox1.Location = new System.Drawing.Point(7, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 45);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Signature Field Appearance";
            // 
            // chkSignTime
            // 
            this.chkSignTime.AutoSize = true;
            this.chkSignTime.Checked = true;
            this.chkSignTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSignTime.Location = new System.Drawing.Point(178, 21);
            this.chkSignTime.Name = "chkSignTime";
            this.chkSignTime.Size = new System.Drawing.Size(87, 17);
            this.chkSignTime.TabIndex = 3;
            this.chkSignTime.Text = "Signing Time";
            this.chkSignTime.UseVisualStyleBackColor = true;
            // 
            // chkReason
            // 
            this.chkReason.AutoSize = true;
            this.chkReason.Checked = true;
            this.chkReason.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReason.Location = new System.Drawing.Point(109, 21);
            this.chkReason.Name = "chkReason";
            this.chkReason.Size = new System.Drawing.Size(63, 17);
            this.chkReason.TabIndex = 2;
            this.chkReason.Text = "Reason";
            this.chkReason.UseVisualStyleBackColor = true;
            // 
            // chkGraphicalImage
            // 
            this.chkGraphicalImage.AutoSize = true;
            this.chkGraphicalImage.Checked = true;
            this.chkGraphicalImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGraphicalImage.Location = new System.Drawing.Point(271, 21);
            this.chkGraphicalImage.Name = "chkGraphicalImage";
            this.chkGraphicalImage.Size = new System.Drawing.Size(119, 17);
            this.chkGraphicalImage.TabIndex = 1;
            this.chkGraphicalImage.Text = "Graphical Signature";
            this.chkGraphicalImage.UseVisualStyleBackColor = true;
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Checked = true;
            this.chkName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkName.Location = new System.Drawing.Point(7, 20);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(94, 17);
            this.chkName.TabIndex = 0;
            this.chkName.Text = "Signer\'s Name";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // rbSignExisting
            // 
            this.rbSignExisting.AutoSize = true;
            this.rbSignExisting.Location = new System.Drawing.Point(13, 355);
            this.rbSignExisting.Name = "rbSignExisting";
            this.rbSignExisting.Size = new System.Drawing.Size(172, 17);
            this.rbSignExisting.TabIndex = 24;
            this.rbSignExisting.Text = "Sign an existing Signature Field";
            this.rbSignExisting.UseVisualStyleBackColor = true;
            // 
            // gbSignExisting
            // 
            this.gbSignExisting.Controls.Add(this.txtFieldName);
            this.gbSignExisting.Controls.Add(this.label11);
            this.gbSignExisting.Enabled = false;
            this.gbSignExisting.Location = new System.Drawing.Point(32, 379);
            this.gbSignExisting.Name = "gbSignExisting";
            this.gbSignExisting.Size = new System.Drawing.Size(414, 73);
            this.gbSignExisting.TabIndex = 25;
            this.gbSignExisting.TabStop = false;
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(9, 43);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(399, 20);
            this.txtFieldName.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Name of Signature Field to Sign:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Graphical Signature Name:";
            // 
            // txtGraphSig
            // 
            this.txtGraphSig.Location = new System.Drawing.Point(148, 99);
            this.txtGraphSig.Name = "txtGraphSig";
            this.txtGraphSig.Size = new System.Drawing.Size(298, 20);
            this.txtGraphSig.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 546);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Sign Password";
            // 
            // signPassBox
            // 
            this.signPassBox.Enabled = false;
            this.signPassBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.signPassBox.Location = new System.Drawing.Point(95, 543);
            this.signPassBox.Name = "signPassBox";
            this.signPassBox.PasswordChar = '*';
            this.signPassBox.Size = new System.Drawing.Size(190, 23);
            this.signPassBox.TabIndex = 29;
            this.signPassBox.Text = "12345678";
            this.signPassBox.TextChanged += new System.EventHandler(this.signPassBox_TextChanged);
            // 
            // chkPFS
            // 
            this.chkPFS.AutoSize = true;
            this.chkPFS.Location = new System.Drawing.Point(301, 546);
            this.chkPFS.Name = "chkPFS";
            this.chkPFS.Size = new System.Drawing.Size(141, 17);
            this.chkPFS.TabIndex = 30;
            this.chkPFS.Text = "Require Prompt-For-Sign";
            this.chkPFS.UseVisualStyleBackColor = true;
            this.chkPFS.CheckedChanged += new System.EventHandler(this.chkPFS_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(455, 578);
            this.Controls.Add(this.chkPFS);
            this.Controls.Add(this.signPassBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtGraphSig);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gbSignExisting);
            this.Controls.Add(this.rbSignExisting);
            this.Controls.Add(this.gbCreateNew);
            this.Controls.Add(this.rbCreateNew);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseBut);
            this.Controls.Add(this.FileUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PDF Sign";
            this.gbCreateNew.ResumeLayout(false);
            this.gbCreateNew.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSignExisting.ResumeLayout(false);
            this.gbSignExisting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            PageBox.Enabled = checkBox1.Checked;
            XBox.Enabled = checkBox1.Checked;
            YBox.Enabled = checkBox1.Checked;
            WBox.Enabled = checkBox1.Checked;
            HBox.Enabled = checkBox1.Checked;
            groupBox1.Enabled = checkBox1.Checked;
        }

		private void BrowseBut_Click(object sender, System.EventArgs e) {
			openFileDialog1.ShowDialog();
		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
			FileUrl.Text = openFileDialog1.FileName;
		}
		
		private void button1_Click(object sender, System.EventArgs e) 
        {
            try
            {
                string signPass = chkPFS.Checked ? signPassBox.Text : null;

                if (rbSignExisting.Checked)
                    FileSign.SAPI_sign_file(FileUrl.Text, txtFieldName.Text,
                        UserBox.Text, PassBox.Text, signPass, txtReason.Text, txtGraphSig.Text);
                else
                {

                    int Flags = 0;
                    if (chkGraphicalImage.Checked) Flags |= FileSign.SAPI_ENUM_DRAWING_ELEMENT_GRAPHICAL_IMAGE;
                    if (chkName.Checked) Flags |= FileSign.SAPI_ENUM_DRAWING_ELEMENT_SIGNED_BY;
                    if (chkReason.Checked) Flags |= FileSign.SAPI_ENUM_DRAWING_ELEMENT_REASON;
                    if (chkSignTime.Checked) Flags |= FileSign.SAPI_ENUM_DRAWING_ELEMENT_TIME;
                    
                    FileSign.SAPI_sign_file(FileUrl.Text, null, UserBox.Text,
                        PassBox.Text, signPass, int.Parse(PageBox.Text), int.Parse(XBox.Text),
                        int.Parse(YBox.Text), int.Parse(HBox.Text),
                        int.Parse(WBox.Text), !checkBox1.Checked, txtReason.Text, Flags, 
                        txtNewSigFieldName.Text, txtGraphSig.Text);
                }

                MessageBox.Show("PDF Signed OK", "PDF Sign", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on signning PDF:\n\n" + ex.Message, "PDF Sign", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

        private void rbCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            gbCreateNew.Enabled = rbCreateNew.Checked;
            gbSignExisting.Enabled = rbSignExisting.Checked;
        }

        private void signPassBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkPFS_CheckedChanged(object sender, EventArgs e)
        {
            signPassBox.Enabled = chkPFS.Checked;
        }
	}
}

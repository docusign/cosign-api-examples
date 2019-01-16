namespace SAPIWS_Sample
{
    partial class frmMain
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ListUsersButtton = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPDFFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.chkIsVisible = new System.Windows.Forms.CheckBox();
            this.nudPage = new System.Windows.Forms.NumericUpDown();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.SignPdfBox = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGrSigName = new System.Windows.Forms.TextBox();
            this.DSAtextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPdfPass = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.AdminPassword = new System.Windows.Forms.TextBox();
            this.AdminUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.NewUserPassword = new System.Windows.Forms.TextBox();
            this.NewUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.NewUserCN = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.NewUserEmail = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.UserManagement = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.GMTOffsetNum = new System.Windows.Forms.NumericUpDown();
            this.AppearanceMaskNum = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.SignPdfBox.SuspendLayout();
            this.UserManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GMTOffsetNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppearanceMaskNum)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 74);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(692, 146);
            this.richTextBox1.TabIndex = 52;
            this.richTextBox1.Text = "";
            // 
            // ListUsersButtton
            // 
            this.ListUsersButtton.Location = new System.Drawing.Point(589, 39);
            this.ListUsersButtton.Margin = new System.Windows.Forms.Padding(4);
            this.ListUsersButtton.Name = "ListUsersButtton";
            this.ListUsersButtton.Size = new System.Drawing.Size(111, 28);
            this.ListUsersButtton.TabIndex = 68;
            this.ListUsersButtton.Text = "List Users";
            this.ListUsersButtton.UseVisualStyleBackColor = true;
            this.ListUsersButtton.Click += new System.EventHandler(this.ListUsers_click);
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(589, 254);
            this.addUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(111, 28);
            this.addUserButton.TabIndex = 60;
            this.addUserButton.Text = "Add User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 51);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 17);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "PDF:";
            // 
            // txtPDFFile
            // 
            this.txtPDFFile.Location = new System.Drawing.Point(64, 49);
            this.txtPDFFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtPDFFile.Name = "txtPDFFile";
            this.txtPDFFile.Size = new System.Drawing.Size(516, 22);
            this.txtPDFFile.TabIndex = 43;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(592, 46);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(111, 28);
            this.btnBrowse.TabIndex = 23;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(245, 81);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(50, 17);
            this.Label2.TabIndex = 24;
            this.Label2.Text = "Page:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(243, 147);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 17);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "Height";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(11, 144);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(54, 17);
            this.Label5.TabIndex = 26;
            this.Label5.Text = "Width:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(247, 114);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(23, 17);
            this.Label6.TabIndex = 27;
            this.Label6.Text = "Y:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(11, 110);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(23, 17);
            this.Label7.TabIndex = 28;
            this.Label7.Text = "X:";
            // 
            // chkIsVisible
            // 
            this.chkIsVisible.AutoSize = true;
            this.chkIsVisible.Checked = true;
            this.chkIsVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsVisible.Location = new System.Drawing.Point(14, 81);
            this.chkIsVisible.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsVisible.Name = "chkIsVisible";
            this.chkIsVisible.Size = new System.Drawing.Size(78, 21);
            this.chkIsVisible.TabIndex = 44;
            this.chkIsVisible.Text = "Visible";
            this.chkIsVisible.UseVisualStyleBackColor = true;
            // 
            // nudPage
            // 
            this.nudPage.Location = new System.Drawing.Point(302, 79);
            this.nudPage.Margin = new System.Windows.Forms.Padding(4);
            this.nudPage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPage.Name = "nudPage";
            this.nudPage.Size = new System.Drawing.Size(160, 22);
            this.nudPage.TabIndex = 45;
            this.nudPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(65, 110);
            this.nudX.Margin = new System.Windows.Forms.Padding(4);
            this.nudX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudX.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(160, 22);
            this.nudX.TabIndex = 46;
            this.nudX.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudX.ValueChanged += new System.EventHandler(this.nudX_ValueChanged);
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(302, 114);
            this.nudY.Margin = new System.Windows.Forms.Padding(4);
            this.nudY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudY.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(160, 22);
            this.nudY.TabIndex = 47;
            this.nudY.Value = new decimal(new int[] {
            93,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(65, 142);
            this.nudWidth.Margin = new System.Windows.Forms.Padding(4);
            this.nudWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(160, 22);
            this.nudWidth.TabIndex = 48;
            this.nudWidth.Value = new decimal(new int[] {
            260,
            0,
            0,
            0});
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(302, 144);
            this.nudHeight.Margin = new System.Windows.Forms.Padding(4);
            this.nudHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(160, 22);
            this.nudHeight.TabIndex = 49;
            this.nudHeight.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(11, 224);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(138, 17);
            this.Label3.TabIndex = 35;
            this.Label3.Text = "Signer Username:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(221, 224);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(134, 17);
            this.Label8.TabIndex = 36;
            this.Label8.Text = "Signer Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(14, 241);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(185, 22);
            this.txtUsername.TabIndex = 55;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(224, 241);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(170, 22);
            this.txtPassword.TabIndex = 57;
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(592, 235);
            this.btnSign.Margin = new System.Windows.Forms.Padding(4);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(111, 28);
            this.btnSign.TabIndex = 62;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // SignPdfBox
            // 
            this.SignPdfBox.Controls.Add(this.label19);
            this.SignPdfBox.Controls.Add(this.AppearanceMaskNum);
            this.SignPdfBox.Controls.Add(this.GMTOffsetNum);
            this.SignPdfBox.Controls.Add(this.label18);
            this.SignPdfBox.Controls.Add(this.label17);
            this.SignPdfBox.Controls.Add(this.txtGrSigName);
            this.SignPdfBox.Controls.Add(this.DSAtextBox);
            this.SignPdfBox.Controls.Add(this.label16);
            this.SignPdfBox.Controls.Add(this.txtPdfPass);
            this.SignPdfBox.Controls.Add(this.label15);
            this.SignPdfBox.Controls.Add(this.btnSign);
            this.SignPdfBox.Controls.Add(this.txtPassword);
            this.SignPdfBox.Controls.Add(this.txtUsername);
            this.SignPdfBox.Controls.Add(this.Label8);
            this.SignPdfBox.Controls.Add(this.Label3);
            this.SignPdfBox.Controls.Add(this.nudHeight);
            this.SignPdfBox.Controls.Add(this.nudWidth);
            this.SignPdfBox.Controls.Add(this.nudY);
            this.SignPdfBox.Controls.Add(this.nudX);
            this.SignPdfBox.Controls.Add(this.nudPage);
            this.SignPdfBox.Controls.Add(this.chkIsVisible);
            this.SignPdfBox.Controls.Add(this.Label7);
            this.SignPdfBox.Controls.Add(this.Label6);
            this.SignPdfBox.Controls.Add(this.Label5);
            this.SignPdfBox.Controls.Add(this.Label4);
            this.SignPdfBox.Controls.Add(this.Label2);
            this.SignPdfBox.Controls.Add(this.btnBrowse);
            this.SignPdfBox.Controls.Add(this.txtPDFFile);
            this.SignPdfBox.Controls.Add(this.Label1);
            this.SignPdfBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignPdfBox.Location = new System.Drawing.Point(12, 8);
            this.SignPdfBox.Name = "SignPdfBox";
            this.SignPdfBox.Size = new System.Drawing.Size(716, 277);
            this.SignPdfBox.TabIndex = 45;
            this.SignPdfBox.TabStop = false;
            this.SignPdfBox.Text = "Sign PDF";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 180);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(161, 17);
            this.label17.TabIndex = 44;
            this.label17.Text = "Graphical Sig\' Name:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // txtGrSigName
            // 
            this.txtGrSigName.Location = new System.Drawing.Point(14, 197);
            this.txtGrSigName.Name = "txtGrSigName";
            this.txtGrSigName.Size = new System.Drawing.Size(185, 22);
            this.txtGrSigName.TabIndex = 60;
            // 
            // DSAtextBox
            // 
            this.DSAtextBox.Location = new System.Drawing.Point(62, 22);
            this.DSAtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DSAtextBox.Name = "DSAtextBox";
            this.DSAtextBox.Size = new System.Drawing.Size(518, 22);
            this.DSAtextBox.TabIndex = 42;
            this.DSAtextBox.Text = "prime-dsa-devctr.docusign.net";
            this.DSAtextBox.TextChanged += new System.EventHandler(this.DSAtextBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "DSA:";
            // 
            // txtPdfPass
            // 
            this.txtPdfPass.Location = new System.Drawing.Point(421, 241);
            this.txtPdfPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPdfPass.Name = "txtPdfPass";
            this.txtPdfPass.PasswordChar = '*';
            this.txtPdfPass.Size = new System.Drawing.Size(159, 22);
            this.txtPdfPass.TabIndex = 58;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(418, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 17);
            this.label15.TabIndex = 40;
            this.label15.Text = "PDF password:";
            // 
            // AdminPassword
            // 
            this.AdminPassword.Location = new System.Drawing.Point(272, 45);
            this.AdminPassword.Margin = new System.Windows.Forms.Padding(4);
            this.AdminPassword.Name = "AdminPassword";
            this.AdminPassword.PasswordChar = '*';
            this.AdminPassword.Size = new System.Drawing.Size(236, 22);
            this.AdminPassword.TabIndex = 67;
            // 
            // AdminUser
            // 
            this.AdminUser.Location = new System.Drawing.Point(9, 45);
            this.AdminUser.Margin = new System.Windows.Forms.Padding(4);
            this.AdminUser.Name = "AdminUser";
            this.AdminUser.Size = new System.Drawing.Size(235, 22);
            this.AdminUser.TabIndex = 66;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 17);
            this.label10.TabIndex = 47;
            this.label10.Text = "Admin Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 24);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 46;
            this.label11.Text = "Admin User";
            // 
            // NewUserPassword
            // 
            this.NewUserPassword.Location = new System.Drawing.Point(272, 260);
            this.NewUserPassword.Margin = new System.Windows.Forms.Padding(4);
            this.NewUserPassword.Name = "NewUserPassword";
            this.NewUserPassword.PasswordChar = '*';
            this.NewUserPassword.Size = new System.Drawing.Size(236, 22);
            this.NewUserPassword.TabIndex = 54;
            // 
            // NewUserName
            // 
            this.NewUserName.Location = new System.Drawing.Point(9, 260);
            this.NewUserName.Margin = new System.Windows.Forms.Padding(4);
            this.NewUserName.Name = "NewUserName";
            this.NewUserName.Size = new System.Drawing.Size(235, 22);
            this.NewUserName.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 239);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 17);
            this.label9.TabIndex = 51;
            this.label9.Text = "New User Password";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 239);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 17);
            this.label12.TabIndex = 50;
            this.label12.Text = "New User Name";
            // 
            // NewUserCN
            // 
            this.NewUserCN.Location = new System.Drawing.Point(9, 306);
            this.NewUserCN.Margin = new System.Windows.Forms.Padding(4);
            this.NewUserCN.Name = "NewUserCN";
            this.NewUserCN.Size = new System.Drawing.Size(235, 22);
            this.NewUserCN.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 285);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(189, 17);
            this.label13.TabIndex = 54;
            this.label13.Text = "New User Common Name";
            // 
            // NewUserEmail
            // 
            this.NewUserEmail.Location = new System.Drawing.Point(273, 304);
            this.NewUserEmail.Margin = new System.Windows.Forms.Padding(4);
            this.NewUserEmail.Name = "NewUserEmail";
            this.NewUserEmail.Size = new System.Drawing.Size(235, 22);
            this.NewUserEmail.TabIndex = 57;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(270, 283);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 17);
            this.label14.TabIndex = 56;
            this.label14.Text = "New User Email";
            // 
            // UserManagement
            // 
            this.UserManagement.Controls.Add(this.NewUserEmail);
            this.UserManagement.Controls.Add(this.label14);
            this.UserManagement.Controls.Add(this.NewUserCN);
            this.UserManagement.Controls.Add(this.label13);
            this.UserManagement.Controls.Add(this.NewUserPassword);
            this.UserManagement.Controls.Add(this.NewUserName);
            this.UserManagement.Controls.Add(this.label9);
            this.UserManagement.Controls.Add(this.label12);
            this.UserManagement.Controls.Add(this.AdminPassword);
            this.UserManagement.Controls.Add(this.AdminUser);
            this.UserManagement.Controls.Add(this.label10);
            this.UserManagement.Controls.Add(this.label11);
            this.UserManagement.Controls.Add(this.addUserButton);
            this.UserManagement.Controls.Add(this.ListUsersButtton);
            this.UserManagement.Controls.Add(this.richTextBox1);
            this.UserManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserManagement.Location = new System.Drawing.Point(15, 301);
            this.UserManagement.Name = "UserManagement";
            this.UserManagement.Size = new System.Drawing.Size(712, 335);
            this.UserManagement.TabIndex = 58;
            this.UserManagement.TabStop = false;
            this.UserManagement.Text = "User Management";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(221, 180);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "GMTOffset:";
            // 
            // GMTOffsetNum
            // 
            this.GMTOffsetNum.Increment = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.GMTOffsetNum.Location = new System.Drawing.Point(224, 197);
            this.GMTOffsetNum.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.GMTOffsetNum.Minimum = new decimal(new int[] {
            1440,
            0,
            0,
            -2147483648});
            this.GMTOffsetNum.Name = "GMTOffsetNum";
            this.GMTOffsetNum.Size = new System.Drawing.Size(170, 22);
            this.GMTOffsetNum.TabIndex = 63;
            this.GMTOffsetNum.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // AppearanceMaskNum
            // 
            this.AppearanceMaskNum.Location = new System.Drawing.Point(421, 197);
            this.AppearanceMaskNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AppearanceMaskNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AppearanceMaskNum.Name = "AppearanceMaskNum";
            this.AppearanceMaskNum.Size = new System.Drawing.Size(159, 22);
            this.AppearanceMaskNum.TabIndex = 64;
            this.AppearanceMaskNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(421, 180);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(142, 17);
            this.label19.TabIndex = 65;
            this.label19.Text = "Appearance Mask:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(755, 646);
            this.Controls.Add(this.UserManagement);
            this.Controls.Add(this.SignPdfBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "DSA SOAP API Sample";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.SignPdfBox.ResumeLayout(false);
            this.SignPdfBox.PerformLayout();
            this.UserManagement.ResumeLayout(false);
            this.UserManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GMTOffsetNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppearanceMaskNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button ListUsersButtton;
        private System.Windows.Forms.Button addUserButton;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtPDFFile;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.CheckBox chkIsVisible;
        internal System.Windows.Forms.NumericUpDown nudPage;
        internal System.Windows.Forms.NumericUpDown nudX;
        internal System.Windows.Forms.NumericUpDown nudY;
        internal System.Windows.Forms.NumericUpDown nudWidth;
        internal System.Windows.Forms.NumericUpDown nudHeight;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.GroupBox SignPdfBox;
        internal System.Windows.Forms.TextBox AdminPassword;
        internal System.Windows.Forms.TextBox AdminUser;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox NewUserPassword;
        internal System.Windows.Forms.TextBox NewUserName;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox NewUserCN;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox NewUserEmail;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox UserManagement;
        private System.Windows.Forms.TextBox txtPdfPass;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox DSAtextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGrSigName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown GMTOffsetNum;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown AppearanceMaskNum;
    }
}


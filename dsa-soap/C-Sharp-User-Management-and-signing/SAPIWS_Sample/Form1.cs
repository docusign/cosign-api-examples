using System;
using System.Windows.Forms;

namespace SAPIWS_Sample
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*";
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.Cancel) return;

            txtPDFFile.Text = ofd.FileName;
        }


        private void btnSign_Click(object sender, EventArgs e)
        {
            SAPIWSWrapper SapiWS = new SAPIWSWrapper();

            if (this.txtPDFFile.Text.Trim().Length < 3)
            {
                MessageBox.Show("Please select PDF file to Sign", "Error");
                this.txtPDFFile.Focus();
                return;
            }

            if (this.txtUsername.Text.Trim().Length < 1)
            {
                MessageBox.Show("Please Define UserName", "Error");
                this.txtUsername.Focus();
                return;
            }

            if (this.txtPassword.Text.Trim().Length < 1)
            {
                MessageBox.Show("Please define CoSign password", "Error");
                this.txtPassword.Focus();
                return;
            }
            
            bool res = SapiWS.SignPDFFile(DSAtextBox.Text, 
                                          txtPDFFile.Text, 
                                          txtUsername.Text, 
                                          txtPassword.Text, 
                                          txtPdfPass.Text,
                                          txtGrSigName.Text,
                                          (int)nudX.Value, 
                                          (int)nudY.Value, 
                                          (int)nudWidth.Value, 
                                          (int)nudHeight.Value, 
                                          (int)nudPage.Value, 
                                          chkIsVisible.Checked,
                                          (int)GMTOffsetNum.Value,
                                          (int)AppearanceMaskNum.Value);

            if (!res)
                MessageBox.Show("Signing Failed", "SAPI WS Demo");
            else
                MessageBox.Show("Signature was applied successfully", "SAPI WS Demo");
        }


        private void ListUsers_click(object sender, EventArgs e)
        {
            if (this.AdminUser.Text.Trim().Length < 1)
            {
                MessageBox.Show("Please Define AdminUser", "Error");
                this.AdminUser.Focus();
                return;
            }

            if (this.AdminPassword.Text.Trim().Length < 1)
            {
                MessageBox.Show("Please define AdminPassword", "Error");
                this.AdminPassword.Focus();
                return;
            }

            SAPIWSWrapper SapiWS = new SAPIWSWrapper();

            SPMLSoapClient.PSOType[] Users = SapiWS.ListUsers(this.AdminUser.Text, this.AdminPassword.Text);
            if (Users != null)
                for (int i = 0; i < Users.Length; i++)
                {
                    String usrs = (i + 1) + ": " + Users[i].psoID.ID + ", " + Users[i].UserRecord.UserCN +
                                 "," + Users[i].UserRecord.EmailAddress + ", " + Users[i].UserRecord.RightsMask;
                    richTextBox1.Text += (usrs + "\n");
                }
        }


        private void addUserButton_Click(object sender, EventArgs e)
        {
            SAPIWSWrapper SapiWS = new SAPIWSWrapper();
            if (SapiWS.AddUser(AdminUser.Text, AdminPassword.Text, NewUserName.Text, NewUserPassword.Text, NewUserCN.Text, NewUserEmail.Text))
                MessageBox.Show("User was added successfully", "SAPI WS Demo");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void nudX_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DSAtextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
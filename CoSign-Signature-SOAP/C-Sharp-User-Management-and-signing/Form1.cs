using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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



            bool res = SapiWS.SignPDFFile(txtPDFFile.Text, txtUsername.Text, txtPassword.Text, (int)nudX.Value, (int)nudY.Value,
                (int)nudWidth.Value, (int)nudHeight.Value, (int)nudPage.Value, true);

            if (!res)
                MessageBox.Show("Signing Failed", "SAPI WS Demo");
            else
                MessageBox.Show("Signature was applied successfully", "SAPI WS Demo");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new SPMLSoapClient.SPML();
            
            // build the CoSign Logon Data
            var data = new SPMLSoapClient.CoSignLogonData();
            data.User = txtUsername.Text; 
            data.Password = txtPassword.Text; 

            // buils a search request
            var searchRequest = new SPMLSoapClient.SearchRequestType();
            searchRequest.CoSignLogonData = data;
            searchRequest.returnData = SPMLSoapClient.ReturnDataType.data;
            searchRequest.maxSelect = 20; // number of users to fetch
            searchRequest.maxSelectSpecified = true;

            SPMLSoapClient.SearchResponseType response;
            try
            {
                // make the call
                response = client.search(searchRequest);
                if (response.status != SPMLSoapClient.StatusCodeType.success)
                {
                    MessageBox.Show("Error on search: " + response.status + ", " + response.error + ", " + response.errorMessage[0], "Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            if (response.pso == null)
            {
                MessageBox.Show("No users!", "OK");
                return;
            }

            //populate the text box with the users from the response
            for (int i = 0; i < response.pso.Length; i++)
            {
                String usrs = (i + 1) + ": " + response.pso[i].psoID.ID + ", " + response.pso[i].UserRecord.UserCN +
                             "," + response.pso[i].UserRecord.EmailAddress + ", " + response.pso[i].UserRecord.RightsMask;
                richTextBox1.Text += (usrs + "\n");
            }            
        }
    }
}
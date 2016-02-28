using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XMLSign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string OpenFileDialog_GetFile(string filter, string title)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filter;
            ofd.Title = title;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() != DialogResult.OK) return string.Empty;
            return ofd.FileName;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtFileToVerify.Text = txtFile.Text = OpenFileDialog_GetFile(
                "All files (*.xml)|*.xml",
                "Please select file whose content will be signed");
        }



        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            txtFileToVerify.Text = OpenFileDialog_GetFile(
                "All files (*.xml)|*.xml",
                "Please select file whose content was signed");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please provide Username");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please provide Password");
                return;
            }

            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show(string.Format("The file '{0}' doesn't exist!",
                    txtFile.Text));
                return;
            }

            try
            {

                //Sign XML Stream 
                SAPIWrapper.SignXML(
                    txtUsername.Text,
                    txtDomain.Text,
                    txtPassword.Text,
                    txtFile.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


            MessageBox.Show("The data was signed successfully");
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {

            if (!File.Exists(txtFileToVerify.Text))
            {
                MessageBox.Show("Please select the file containing the XML Signature");
                return;
            }

            try
            {
                SAPIWrapper.SignatureDetails details = SAPIWrapper.ValidateXMLSignature(txtFileToVerify.Text);
                if (details == null)
                {
                    MessageBox.Show("Signature could not be validated");
                    return;
                }
                lblSignerName.Text = details.SignerName;
                lblSigningTime.Text = details.SignatureTimeTicks == 0 ?
                    "Not Available" : string.Format("{0}, {1}",
                        new DateTime(details.SignatureTimeTicks).ToShortDateString(),
                        new DateTime(details.SignatureTimeTicks).ToShortTimeString());
                chkIsValid.Checked = details.isValid;
                lblShowCert.Tag = details.SignerCertificate;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void lblShowCert_Click(object sender, EventArgs e)
        {
            if (lblShowCert.Tag == null)
            {
                MessageBox.Show("Please validate any signature before");
                return;
            }
            this.Cursor = Cursors.Default;
            System.Security.Cryptography.X509Certificates.X509Certificate2UI.DisplayCertificate(
                lblShowCert.Tag as System.Security.Cryptography.X509Certificates.X509Certificate2);
        }

        private void lblShowCert_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblShowCert_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

    }
}

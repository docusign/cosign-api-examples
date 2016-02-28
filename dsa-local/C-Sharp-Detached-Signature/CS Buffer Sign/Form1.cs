using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CS_Buffer_Sign
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
                "All files (*.*)|*.*",
                "Please select file whose content will be signed");
        }

        private void btnBrowseSignature_Click(object sender, EventArgs e)
        {
            txtSignatureFile.Text = OpenFileDialog_GetFile(
                "Signature files (*.p7b)|*.p7b",
                "Please select PKCS#7 Signature File");
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            txtFileToVerify.Text = OpenFileDialog_GetFile(
                "All files (*.*)|*.*",
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
                using (Stream dataToSign = File.OpenRead(txtFile.Text), 
                    Signature = new MemoryStream())
                {

                    //Sign Stream data
                    SAPIWrapper.SignStream(
                        txtUsername.Text,
                        txtDomain.Text,
                        txtPassword.Text,
                        dataToSign, Signature);

                    //Close input stream
                    dataToSign.Close();

                    //Save signature data to file
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Signature file (*.p7b)|*.p7b";
                    sfd.Title = "Please select the file to save the signature to";
                    sfd.FileName = Path.GetFileNameWithoutExtension(txtFile.Text) + ".p7b";
                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        Signature.Close();
                        return;
                    }


                    File.WriteAllBytes(sfd.FileName,
                        (Signature as MemoryStream).ToArray());

                    txtSignatureFile.Text = sfd.FileName;

                    Signature.Close();
                }
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
            if (!File.Exists (txtFileToVerify.Text))
            {
                MessageBox.Show ("Please select the file containing the signed content");
                return;
            }

            if (!File.Exists (txtSignatureFile.Text))
            {
                MessageBox.Show ("Please select the file containing the PKCS#7 Signature");
                return;
            }

            try
            {
                using (Stream data = File.OpenRead(txtFileToVerify.Text),
                    sig = File.OpenRead(txtSignatureFile.Text))
                {
                    SAPIWrapper.SignatureDetails details =
                        SAPIWrapper.ValidateSignature(data, sig);


                    lblSignerName.Text = details.SignerName;
                    lblSigningTime.Text = details.SignatureTimeTicks == 0 ?
                        "Not Available" : string.Format("{0}, {1}",
                            new DateTime(details.SignatureTimeTicks).ToShortDateString(),
                            new DateTime(details.SignatureTimeTicks).ToShortTimeString());
                    lblEmail.Text = details.SignerEmail;
                    chkIsValid.Checked = details.isValid;
                    lblShowCert.Tag = details.SignerCertificate;

                    data.Close();
                    sig.Close();
                }
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

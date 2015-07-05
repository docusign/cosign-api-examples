using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DOCXsample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            try
            {
                SAPIWrapper.Logon(txtUsername.Text, txtDomain.Text, txtPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                return;
            }

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtDomain.Enabled = false;
            btnLogoff.Enabled = true;
            btnLogon.Enabled = false;
            gbFile.Enabled = true;
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            try
            {
                SAPIWrapper.Logoff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                return;
            }

            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtDomain.Enabled = true;
            btnLogoff.Enabled = false;
            btnLogon.Enabled = true;
            gbFile.Enabled = false;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word 2007 Files (*.docx)|*.docx";
            ofd.Multiselect = false;

            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.Cancel) return;

            txtFile.Text = ofd.FileName;


        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DOCXField[] Fields = null;
            try
            {
                Fields = SAPIWrapper.GetSignatureFields(txtFile.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                return;
            }

            if (Fields == null)
            {
                MessageBox.Show ("Selected file doesn't contain Signature Fields");
                return;
            }


            btnCloseFile.Enabled = true;
            btnOpenFile.Enabled = false;
            txtFile.Enabled = false;
            btnBrowse.Enabled = false;
            gbLogin.Enabled = false;
            gbSign.Enabled = true;

            for (int i = 0; i< Fields.Length; i++)
                lstFields.Items.Add (Fields[i]);

        }

        private void btnCloseFile_Click(object sender, EventArgs e)
        {
            lstFields.Items.Clear();
            lstFields.SelectedItem = null;
            btnCloseFile.Enabled = false;
            btnOpenFile.Enabled = true;
            txtFile.Enabled = true;
            btnBrowse.Enabled = true;
            gbLogin.Enabled = true;
            gbSign.Enabled = false;
        }

        private void lstFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFields.SelectedIndex >= 0)
            {
                DOCXField fld = (DOCXField)lstFields.SelectedItem;
                if (fld.sInfo.IsSigned != 0)
                {
                    btnSign.Enabled = false;
                }
                else
                {
                    btnSign.Enabled = true;
                }
            }
            else
            {
                btnSign.Enabled = false;
            }

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                SAPIWrapper.SignField((DOCXField)lstFields.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            //Refresh the list
            lstFields.Items.Clear();
            btnOpenFile_Click(null, null);

            MessageBox.Show("The Field was successfully signed");
        }
    }
}
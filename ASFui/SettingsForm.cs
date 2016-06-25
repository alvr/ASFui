using System;
using System.Net;
using System.Windows.Forms;

namespace ASFui
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            lbPath.Text = Properties.Settings.Default.ASFBinary;
            rbLocal.Checked = Properties.Settings.Default.IsLocal;
            rbRemote.Checked = !Properties.Settings.Default.IsLocal;
            tbRemoteURL.Enabled = rbRemote.Checked;
            tbRemoteURL.Text = Properties.Settings.Default.RemoteURL;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ofdBinarySearch.ShowDialog();
            Properties.Settings.Default.ASFBinary = ofdBinarySearch.FileName;
            lbPath.Text = Properties.Settings.Default.ASFBinary;
        }

        private void rbRemote_CheckedChanged(object sender, EventArgs e)
        {
            tbRemoteURL.Enabled = rbRemote.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsLocal = rbLocal.Checked;
            Properties.Settings.Default.RemoteURL = tbRemoteURL.Text;
            if (rbRemote.Checked)
            {
                if (CheckUrl())
                {
                    Properties.Settings.Default.Save();
                    lbSaved.Text = @"Settings saved.";
                }
                else
                {
                    MessageBox.Show(@"Invalid remote URL", @"Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Properties.Settings.Default.Save();
                lbSaved.Text = @"Settings saved.";
            }
        }

        private bool CheckUrl()
        {
            const string validContentType = "text/xml; charset=utf-8";

            var request = WebRequest.Create(tbRemoteURL.Text);
            request.Method = "GET";
            request.ContentType = validContentType;

            try
            {
                var response = request.GetResponse();
                return response.ContentType == validContentType;
            }
            catch (WebException ex)
            {
                if (ex.Response == null) return false;
                using (var responseEx = ex.Response)
                {
                    return responseEx.ContentType == validContentType;
                }
            }
        }
    }
}

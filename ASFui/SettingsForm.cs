using System;
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
            cbOK.Checked = Properties.Settings.Default.ClearOk;
            cbDuplicated.Checked = Properties.Settings.Default.ClearDuplicated;
            cbInvalid.Checked = Properties.Settings.Default.ClearInvalid;
            cbOwned.Checked = Properties.Settings.Default.ClearOwned;
            cbCooldown.Checked = Properties.Settings.Default.ClearCooldown;
            cbAutostart.Checked = Properties.Settings.Default.Autostart;
            cbTray.Checked = Properties.Settings.Default.ToTray;
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
            Properties.Settings.Default.ClearOk = cbOK.Checked;
            Properties.Settings.Default.ClearDuplicated = cbDuplicated.Checked;
            Properties.Settings.Default.ClearInvalid = cbInvalid.Checked;
            Properties.Settings.Default.ClearOwned = cbOwned.Checked;
            Properties.Settings.Default.ClearCooldown = cbCooldown.Checked;
            Properties.Settings.Default.Autostart = cbAutostart.Checked;
            Properties.Settings.Default.ToTray = cbTray.Checked;

            if (rbRemote.Checked)
            {
                if (Util.CheckUrl(tbRemoteURL.Text))
                {
                    Properties.Settings.Default.RemoteURL = tbRemoteURL.Text;
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
    }
}

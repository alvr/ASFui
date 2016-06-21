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
            Properties.Settings.Default.Save();
        }
    }
}

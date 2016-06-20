using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ofdBinarySearch.ShowDialog();
            Properties.Settings.Default.ASFBinary = ofdBinarySearch.FileName;
            lbPath.Text = Properties.Settings.Default.ASFBinary;
            Properties.Settings.Default.Save();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}

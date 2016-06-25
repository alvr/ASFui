using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASFui
{
    public partial class Password : Form
    {
        private readonly Process _p;
        public Password(Process p, string txt)
        {
            InitializeComponent();
            lbInfo.Text = txt;
            _p = p;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _p.StandardInput.WriteLine(tbPassword.Text);
            _p.StandardInput.Flush();
            Dispose();
            Close();
        }
    }
}

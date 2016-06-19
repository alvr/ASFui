using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASFui
{
    public partial class ASFui : Form
    {
        bool ASFRunning = false;

        public ASFui()
        {
            if (!Util.CheckBinary())
            {
                MessageBox.Show("ASF binary should be in the same folder as ASFui.",
                    "ASF binary not found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            InitializeComponent();
        }

        private void ASFui_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ASFRunning)
            {
                ASFProcess.Kill();
                ASFProcess.CancelOutputRead();
                BackgroundWorker.CancelAsync();
            }
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ASFProcess.Start();
            ASFProcess.BeginOutputReadLine();
            ASFProcess.WaitForExit();
        }

        private void ProcesoASF_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            rtbOutput.AppendText(e.Data + Environment.NewLine);
            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void ASFProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            rtbOutput.AppendText(e.Data + Environment.NewLine);
            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        public void GetBotList()
        {
            CbBotList.Items.Clear();
            string status = Util.SendCommand("statusall");
            MatchCollection matches = Regex.Matches(status, @"Bot (.*) is");
            foreach (Match m in matches)
            {
                CbBotList.Items.Add(m.Groups[1].Value);
            }
            CbBotList.SelectedIndex = 0;
        }

        #region Buttons Events
        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            rtbOutput.AppendText("Starting ASF..." + Environment.NewLine);
            BackgroundWorker.RunWorkerAsync();
            btnStop.Enabled = true;
            ASFRunning = true;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            rtbOutput.AppendText("Stopping ASF..." + Environment.NewLine);
            ASFProcess.Kill();
            ASFProcess.CancelOutputRead();
            BackgroundWorker.CancelAsync();
            btnStart.Enabled = true;
            ASFRunning = false;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
        }

        private void btnReloadBots_Click(object sender, EventArgs e)
        {
            GetBotList();
        }
        #endregion
    }
}

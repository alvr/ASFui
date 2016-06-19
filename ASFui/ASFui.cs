using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
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

        private void ASFui_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                TrayIcon.Visible = true;
            }
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
            cbBotList.Items.Clear();
            string status = Util.SendCommand("statusall");
            MatchCollection matches = Regex.Matches(status, @"Bot (.*) is");
            foreach (Match m in matches)
            {
                cbBotList.Items.Add(m.Groups[1].Value);
            }
            cbBotList.SelectedIndex = 0;
        }

        #region Buttons Events
        #region Start/Stop Buttons
        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            rtbOutput.AppendText("Starting ASF..." + Environment.NewLine);
            BackgroundWorker.RunWorkerAsync();
            btnStop.Enabled = true;
            btnClear.Enabled = true;
            cbBotList.Enabled = true;
            rtbOutput.Enabled = true;
            btnReloadBots.Enabled = true;
            btnReloadBots.Focus();
            ASFRunning = true;
            tsslCommandOutput.Text = "Started ASF server.";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            rtbOutput.AppendText("Stopping ASF..." + Environment.NewLine);
            Util.SendCommand("exit");
            ASFProcess.CancelOutputRead();
            BackgroundWorker.CancelAsync();
            DisableElements();
            tsslCommandOutput.Text = "Stopped ASF server.";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            tsslCommandOutput.Text = "Cleared log.";
        }

        private void btnReloadBots_Click(object sender, EventArgs e)
        {
            GetBotList();
            EnableElements();
            tsslCommandOutput.Text = "Updated Bot list.";
        }
        #endregion

        #region Cards Buttons
        private void btnFarm_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("farm", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!farm <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btnLoot_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("loot", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!loot <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }
        #endregion

        #region Keys Buttons
        private void btnRedeem_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("redeem", cbBotList.SelectedItem.ToString(), Util.MultiToOne(tbInput.Lines)));
            tsslCommandOutput.Text = "!redeem <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btnAddLicense_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("addlicense", cbBotList.SelectedItem.ToString(), Util.MultiToOne(tbInput.Lines)));
            tsslCommandOutput.Text = "!addlicense <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }
        #endregion

        #region Games Buttons
        private void btnOwns_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("owns", cbBotList.SelectedItem.ToString(), Util.MultiToOne(tbInput.Lines)));
            tsslCommandOutput.Text = "!owns <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("play", cbBotList.SelectedItem.ToString(), Util.MultiToOne(tbInput.Lines)));
            tsslCommandOutput.Text = "!play <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }
        #endregion

        #region Chat Buttons
        private void btnLeave_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("leave", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!leave <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btnRejoin_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("rejoinchat", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!rejoinchat <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }
        #endregion

        #region Bots Buttons
        private void btnStartBot_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("start", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!start <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btnStopBot_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("stop", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!stop <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btnPauseBot_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("pause", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!pause <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btnStatusBot_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("status", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!status <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btnStatusAll_Click(object sender, EventArgs e)
        {
            Util.SendCommand("statusall");
        }
        #endregion

        #region ASF Buttons
        private void btnASFHelp_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand("help");
            tsslCommandOutput.Text = "!help: " + result;
        }

        private void btnASFUpdate_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand("update");
            tsslCommandOutput.Text = "!update: " + result;
        }

        private void btnASFVersion_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand("version");
            tsslCommandOutput.Text = "!version: " + result;
        }
        #endregion

        #region 2FA Buttons
        private void btn2FA_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("2fa", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!2fa <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btn2FAOff_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("2faoff", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!2faoff <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btn2FAOk_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("2faok", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!2faok <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }

        private void btn2FANo_Click(object sender, EventArgs e)
        {
            string result = Util.SendCommand(Util.GenerateCommand("2fano", cbBotList.SelectedItem.ToString()));
            tsslCommandOutput.Text = "!2fano <" + cbBotList.SelectedItem.ToString() + ">: " + result;
        }
        #endregion
        #endregion

        private void EnableElements()
        {
            tbInput.Enabled = true;
            btnFarm.Enabled = true;
            btnLoot.Enabled = true;
            btnRedeem.Enabled = true;
            btnAddLicense.Enabled = true;
            btnOwns.Enabled = true;
            btnPlay.Enabled = true;
            btnLeave.Enabled = true;
            btnRejoin.Enabled = true;
            btnStartBot.Enabled = true;
            btnStopBot.Enabled = true;
            btnPauseBot.Enabled = true;
            btnStatusBot.Enabled = true;
            btnStatusAll.Enabled = true;
            btnASFHelp.Enabled = true;
            btnASFUpdate.Enabled = true;
            btnASFVersion.Enabled = true;
            btn2FA.Enabled = true;
            btn2FAOff.Enabled = true;
            btn2FAOk.Enabled = true;
            btn2FANo.Enabled = true;
        }

        private void DisableElements()
        {
            tbInput.Enabled = false;
            btnFarm.Enabled = false;
            btnLoot.Enabled = false;
            btnRedeem.Enabled = false;
            btnAddLicense.Enabled = false;
            btnOwns.Enabled = false;
            btnPlay.Enabled = false;
            btnLeave.Enabled = false;
            btnRejoin.Enabled = false;
            btnStartBot.Enabled = false;
            btnStopBot.Enabled = false;
            btnPauseBot.Enabled = false;
            btnStatusBot.Enabled = false;
            btnStatusAll.Enabled = false;
            btnASFHelp.Enabled = false;
            btnASFUpdate.Enabled = false;
            btnASFVersion.Enabled = false;
            btn2FA.Enabled = false;
            btn2FAOff.Enabled = false;
            btn2FAOk.Enabled = false;
            btn2FANo.Enabled = false;

            cbBotList.Enabled = false;
            cbBotList.Items.Clear();
            btnReloadBots.Enabled = false;
            btnStart.Enabled = true;
            ASFRunning = false;
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

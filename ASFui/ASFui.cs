using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASFui
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class ASFui : Form
    {
        private bool _asfRunning;
        private ASFProcess _asf;

        public ASFui()
        {
            Util.CheckVersion();
            Util.UpgradeSettings();
            while (!Util.CheckBinary())
            {
                var result = MessageBox.Show(@"ASF binary setting not configured. Configure now?",
                    @"ASF binary not found.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.ASFBinary = "Setting not configured.";
                    var settings = new SettingsForm();
                    settings.ShowDialog();
                }
                else
                {
                    Environment.Exit(-1);
                }
            }

            if (Util.CheckIfAsfIsRunning())
            {
                MessageBox.Show(@"An instance of ASF is already running. Close it.",
                    @"ASF already running.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-2);
            }
            InitializeComponent();
        }

        private void ASFui_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            Hide();
            TrayIcon.Visible = true;
        }

        private void ASFui_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }

            Location = Properties.Settings.Default.Location;
            var formRectangle = new Rectangle(Left, Top, Width, Height);
            if (!Util.IsOnScreen(formRectangle))
            {
                var settingsProperty = Properties.Settings.Default.Properties["Location"];
                if (settingsProperty != null)
                {
                    var coords = settingsProperty.DefaultValue.ToString().Split(',');
                    Location = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                }
            }

            Size = Properties.Settings.Default.Size;
            if (Size.Height < MinimumSize.Height || Size.Width < MinimumSize.Width)
            {
                var settingsProperty = Properties.Settings.Default.Properties["Size"];
                if (settingsProperty != null)
                    Size = (Size)settingsProperty.DefaultValue;
            }

            if (Properties.Settings.Default.Autostart)
            {
                Task.Delay(500).ContinueWith(t => btnStart.PerformClick());
            }
        }

        private void ASFui_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    Properties.Settings.Default.Location = RestoreBounds.Location;
                    Properties.Settings.Default.Size = RestoreBounds.Size;
                    Properties.Settings.Default.Maximized = true;
                    break;
                case FormWindowState.Normal:
                    Properties.Settings.Default.Location = Location;
                    Properties.Settings.Default.Size = Size;
                    Properties.Settings.Default.Maximized = false;
                    break;
                case FormWindowState.Minimized:
                    break;
                default:
                    Properties.Settings.Default.Location = RestoreBounds.Location;
                    Properties.Settings.Default.Size = RestoreBounds.Size;
                    Properties.Settings.Default.Maximized = false;
                    break;
            }
            Properties.Settings.Default.Save();
            if (!_asfRunning || !Properties.Settings.Default.IsLocal) return;
            _asf.Stop();
            Logging.Info(@"Closing ASFui.");
        }

        public void GetBotList()
        {
            cbBotList.Invoke(new MethodInvoker(delegate { cbBotList.Items.Clear(); }));

            var status = Util.SendCommand("statusall");
            var matches = Regex.Matches(status, @"Bot (.*) is");
            cbBotList.Invoke(new MethodInvoker(delegate
             {
                 foreach (Match m in matches)
                 {
                     cbBotList.Items.Add(m.Groups[1].Value);
                 }
             }));
             if (cbBotList.Items.Count <= 0) return;
             cbBotList.Invoke(new MethodInvoker(delegate
             {
                 cbBotList.SelectedIndex = 0;
                 EnableElements();
             }));
        }

        #region Buttons Events

        #region Start/Stop Buttons

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IsLocal)
            {
                _asf = new ASFProcess(this, rtbOutput);
                _asf.Start();
            }
            else
            {
                if (!Util.CheckUrl(Properties.Settings.Default.RemoteURL))
                {
                    rtbOutput.AppendText(@"Cannot connect to remote URL " + Properties.Settings.Default.RemoteURL +
                        @". Please check your config or run ASF in local." + Environment.NewLine);
                    return;
                }
                GetBotList();
            }
            btnStart.Enabled = false;
            rtbOutput.AppendText(@"Starting ASF..." + Environment.NewLine);
            btnStop.Enabled = true;
            btnClear.Enabled = true;
            cbBotList.Enabled = true;
            rtbOutput.Enabled = true;
            btnReloadBots.Enabled = true;
            _asfRunning = true;
            btnASFuiSettings.Enabled = false;
            Logging.Info("Server started successfully.");
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            rtbOutput.AppendText("Stopping ASF..." + Environment.NewLine);
            if (Properties.Settings.Default.IsLocal)
            {
                _asf.Stop();
            }
            DisableElements();
            Logging.Info("Server stopped successfully.");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
        }

        private void btnReloadBots_Click(object sender, EventArgs e)
        {
            GetBotList();
        }

        private void btnASFuiSettings_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void btnASFuiHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/alvr/ASFui/wiki");
        }

        #endregion

        #region Cards Buttons

        private void btnFarm_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Util.SendCommand(Util.GenerateCommand("farm", cbBotList.SelectedItem.ToString()));
                rtbOutput.SelectionStart = rtbOutput.Text.Length;
                rtbOutput.ScrollToCaret();
            });
        }

        private void btnLoot_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Util.SendCommand(Util.GenerateCommand("loot", cbBotList.SelectedItem.ToString()));
                rtbOutput.SelectionStart = rtbOutput.Text.Length;
                rtbOutput.ScrollToCaret();
            });
        }

        private void btnLootAll_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Util.SendCommand("lootall");
                rtbOutput.SelectionStart = rtbOutput.Text.Length;
                rtbOutput.ScrollToCaret();
            });
        }

        #endregion

        #region Keys Buttons

        private void btnRedeem_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!tbInput.Text.Equals(""))
                {
                    Util.SendCommand(Util.GenerateCommand("redeem", cbBotList.SelectedItem.ToString(),
                        Util.MultiToOne(tbInput.Lines)));

                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }
                else
                {
                    Logging.Error(@"Input required (!redeem)");
                    MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        private void btnRedeemNF_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!tbInput.Text.Equals(""))
                {
                    Util.SendCommand(Util.GenerateCommand("redeem^", cbBotList.SelectedItem.ToString(),
                        Util.MultiToOne(tbInput.Lines)));

                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }
                else
                {
                    Logging.Error(@"Input required (!redeem^)");
                    MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        private void btnRedeemFF_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!tbInput.Text.Equals(""))
                {
                    Util.SendCommand(Util.GenerateCommand("redeem&", cbBotList.SelectedItem.ToString(),
                        Util.MultiToOne(tbInput.Lines)));

                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }
                else
                {
                    Logging.Error(@"Input required (!redeem&)");
                    MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        private void btnAddLicense_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!tbInput.Text.Equals(""))
                {
                    Util.SendCommand(Util.GenerateCommand("addlicense", cbBotList.SelectedItem.ToString(), 
                        Util.MultiToOne(tbInput.Lines)));

                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }
                else
                {
                    Logging.Error(@"Input required (!addlicense)");
                    MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        #endregion

        #region Games Buttons

        private void btnOwns_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!tbInput.Text.Equals(""))
                {
                    Util.SendCommand(Util.GenerateCommand("owns", cbBotList.SelectedItem.ToString(), 
                        Util.MultiToOne(tbInput.Lines)));

                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }
                else
                {
                    Logging.Error(@"Input required (!owns)");
                    MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        private void btnOwnAll_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!tbInput.Text.Equals(""))
                {
                    Util.SendCommand(Util.GenerateCommand("ownsall", string.Empty, Util.MultiToOne(tbInput.Lines)));
                    
                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }
                else
                {
                    Logging.Error(@"Input required (!ownsall)");
                    MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!tbInput.Text.Equals(""))
                {
                    Util.SendCommand(Util.GenerateCommand("play", cbBotList.SelectedItem.ToString(), 
                        Util.MultiToOne(tbInput.Lines)));

                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }
                else
                {
                    Logging.Error(@"Input required (!play)");
                    MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        #endregion

        #region Chat Buttons

        private void btnRejoin_Click(object sender, EventArgs e)
        {
            Util.SendCommand("rejoinchat");

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        #endregion

        #region Bots Buttons

        private void btnStartBot_Click(object sender, EventArgs e)
        {
            Util.SendCommand(Util.GenerateCommand("start", cbBotList.SelectedItem.ToString()));

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            Util.SendCommand("startall");
            GetBotList();

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnStopBot_Click(object sender, EventArgs e)
        {
            Util.SendCommand(Util.GenerateCommand("stop", cbBotList.SelectedItem.ToString()));

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnPauseBot_Click(object sender, EventArgs e)
        {
            Util.SendCommand(Util.GenerateCommand("pause", cbBotList.SelectedItem.ToString()));

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            Util.SendCommand(Util.GenerateCommand("resume", cbBotList.SelectedItem.ToString()));

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            Util.SendCommand(Util.GenerateCommand("password", cbBotList.SelectedItem.ToString()));

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnStatusBot_Click(object sender, EventArgs e)
        {
            Util.SendCommand(Util.GenerateCommand("status", cbBotList.SelectedItem.ToString()));

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnStatusAll_Click(object sender, EventArgs e)
        {
            Util.SendCommand("statusall");

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        #endregion

        #region ASF Buttons

        private void btnASFHelp_Click(object sender, EventArgs e)
        {
            Util.SendCommand("help");

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnASFUpdate_Click(object sender, EventArgs e)
        {
            Util.SendCommand("update");

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnASFVersion_Click(object sender, EventArgs e)
        {
            Util.SendCommand("version");

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnAPI_Click(object sender, EventArgs e)
        {
            var result = Util.SendCommand("api");
            Task.Run(() =>
            {
                var api = new Api(result);
                MessageBox.Show(api.AllApi(), @"API result", MessageBoxButtons.OK);
            });

        }

        #endregion

        #region 2FA Buttons

        private void btn2FA_Click(object sender, EventArgs e)
        {
            Util.SendCommand(Util.GenerateCommand("2fa", cbBotList.SelectedItem.ToString()));

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btn2FAOk_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Util.SendCommand(Util.GenerateCommand("2faok", cbBotList.SelectedItem.ToString()));

                rtbOutput.SelectionStart = rtbOutput.Text.Length;
                rtbOutput.ScrollToCaret();
            });
        }

        private void btn2FANo_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Util.SendCommand(Util.GenerateCommand("2fano", cbBotList.SelectedItem.ToString()));

                rtbOutput.SelectionStart = rtbOutput.Text.Length;
                rtbOutput.ScrollToCaret();
            });
        }

        #endregion

        #endregion

        private void EnableElements()
        {
            tbInput.Enabled = true;
            btnFarm.Enabled = true;
            btnLoot.Enabled = true;
            btnLootAll.Enabled = true;
            btnRedeem.Enabled = true;
            btnRedeemNF.Enabled = true;
            btnRedeemFF.Enabled = true;
            btnAddLicense.Enabled = true;
            btnOwns.Enabled = true;
            btnOwnAll.Enabled = true;
            btnPlay.Enabled = true;
            btnRejoin.Enabled = true;
            btnStartBot.Enabled = true;
            btnStartAll.Enabled = true;
            btnStopBot.Enabled = true;
            btnPauseBot.Enabled = true;
            btnResumeBot.Enabled = true;
            btnPasswordBot.Enabled = true;
            btnStatusBot.Enabled = true;
            btnStatusAll.Enabled = true;
            btnASFHelp.Enabled = true;
            btnASFUpdate.Enabled = true;
            btnASFVersion.Enabled = true;
            btnAPI.Enabled = true;
            btn2FA.Enabled = true;
            btn2FAOk.Enabled = true;
            btn2FANo.Enabled = true;
        }

        private void DisableElements()
        {
            tbInput.Enabled = false;
            tbInput.Clear();
            btnFarm.Enabled = false;
            btnLoot.Enabled = false;
            btnLootAll.Enabled = false;
            btnRedeem.Enabled = false;
            btnRedeemNF.Enabled = false;
            btnRedeemFF.Enabled = false;
            btnAddLicense.Enabled = false;
            btnOwns.Enabled = false;
            btnOwnAll.Enabled = false;
            btnPlay.Enabled = false;
            btnRejoin.Enabled = false;
            btnStartBot.Enabled = false;
            btnStartAll.Enabled = false;
            btnStopBot.Enabled = false;
            btnPauseBot.Enabled = false;
            btnResumeBot.Enabled = false;
            btnPasswordBot.Enabled = false;
            btnStatusBot.Enabled = false;
            btnStatusAll.Enabled = false;
            btnASFHelp.Enabled = false;
            btnASFUpdate.Enabled = false;
            btnASFVersion.Enabled = false;
            btnAPI.Enabled = false;
            btn2FA.Enabled = false;
            btn2FAOk.Enabled = false;
            btn2FANo.Enabled = false;
            cbBotList.Enabled = false;
            cbBotList.Items.Clear();
            btnReloadBots.Enabled = false;
            btnStart.Enabled = true;
            btnASFuiSettings.Enabled = true;
            _asfRunning = false;
        }

        private void rtbOutput_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
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

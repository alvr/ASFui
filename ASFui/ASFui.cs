using System;
using ASFui.Properties;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                var result= MessageBox.Show(@"An instance of ASF is already running. Switching to remote mode.",
                    @"ASF already running.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (result == System.Windows.Forms.DialogResult.OK) {
                    Settings.Default.IsLocal = false;
                    Settings.Default.RemoteURL = Util.GetEndpointAddress();
                } else {
                    Environment.Exit(-2);
                }
            }
            InitializeComponent();
        }

        private void ASFui_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized || !Properties.Settings.Default.ToTray) return;
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
                Task.Delay(500).ContinueWith(t => cbBotList.Invoke(new MethodInvoker(() => btnStart.PerformClick())));
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
            cbBotList.Invoke(new MethodInvoker(() => cbBotList.Items.Clear()));

            var status = Util.SendCommand("statusall");
            var matches = Regex.Matches(status, @"Bot (.*) is");
            cbBotList.Invoke(new MethodInvoker(() =>
            {
                foreach (Match m in matches)
                    cbBotList.Items.Add(m.Groups[1].Value);
            }));

            Logging.Info("Bot list refreshed. Detected " + matches.Count + " bots.");

            if (matches.Count <= 0) return;
            cbBotList.Invoke(new MethodInvoker(() =>
            {
                cbBotList.SelectedIndex = 0;
                EnableElements();
            }));
        }

        public bool GetFileBotList() {
            string binary = Settings.Default.ASFBinary;
            int index = binary.LastIndexOf('/');
            if (index == -1) { 
                index = binary.LastIndexOf('\\');
            }
            if (index == -1) {
                return false;
            }
            // not sure about if I should use \\ or /
            string folder = binary.Substring(0, index) + "\\config";
            string[] files = Directory.GetFiles(folder, "*.json");
            if (files.Length <= 1) return false;

            cbBotList.Invoke(new MethodInvoker(() => cbBotList.Items.Clear()));
            foreach (string file in files) {
                index = file.LastIndexOf('/');
                if (index == -1) {
                    index = file.LastIndexOf('\\');
                }
                string name = file.Substring(index+1).Replace(".json", "");
                if (!"ASF".Equals(name) && !"minimal".Equals(name) && !"example".Equals(name)) {
                    cbBotList.Items.Add(name);
                }
            }
            Logging.Info("Bot list refreshed. Detected " + (files.Length-1) + " bots.");

            
            cbBotList.Invoke(new MethodInvoker(() => {
                cbBotList.SelectedIndex = 0;
                EnableElements();
            }));

            return true;
        }

        #region Buttons Events

        #region Start/Stop Buttons

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IsLocal)
            {
                string binary = Settings.Default.ASFBinary;
                int index = binary.LastIndexOf('/');
                if (index == -1) {
                    index = binary.LastIndexOf('\\');
                }
                if (index != -1) {
                    string message = "The following Parameter will be changed automatically. Abort to change them manually." + Environment.NewLine;
                    // not sure about if I should use \\ or /
                    string asfJson = binary.Substring(0, index) + "\\config\\ASF.json";
                    dynamic asfConfig= JsonConvert.DeserializeObject(File.ReadAllText(asfJson));
                    string culture = asfConfig.CurrentCulture;
                    bool msg = false;
                    if (!"en".Equals(culture)) {
                        message=message+ "Language (CurrentCulture): is: "+ asfConfig.CurrentCulture +", will be: \"en\""+ Environment.NewLine;
                        asfConfig.CurrentCulture = "en";
                        msg = true;
                    }
                    if (asfConfig.AutoRestart.Value) {
                        message = message + "AutoRestart (ASFui always restart ASF): is: " + asfConfig.AutoRestart + ", will be: false" + Environment.NewLine;
                        asfConfig.AutoRestart.Value = false;
                        msg = true;
                    }
                    if (0 == asfConfig.SteamOwnerID.Value) {
                        // this is not yet confirmed by archi to be allowed, otherwise message here "change manually" and exit.
                        message = message + "SteamOwnerID (CHANGE THIS TO YOUR MAIN ACCOUNT ASAP!): is: " + asfConfig.SteamOwnerID + ", will be: " + ulong.MaxValue + Environment.NewLine;
                        asfConfig.SteamOwnerID.Value = ulong.MaxValue;
                        msg = true;
                    }
                    if (msg) {
                        var result = MessageBox.Show(message, @"Config needs to be changed.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        if (result == System.Windows.Forms.DialogResult.OK) {
                            try {
                                File.WriteAllText(asfJson, JsonConvert.SerializeObject(asfConfig, Formatting.Indented));
                            } catch (Exception ex) {
                                MessageBox.Show("Error writing changes. Change manually and restart." + Environment.NewLine + "Exiting....");
                                Application.Exit();
                                return;
                            }
                        } else {
                            Application.Exit();
                            return;
                        }
                    }
                }

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
            GetFileBotList();
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
                sendCommand(Util.GenerateCommand("farm", cbBotList.SelectedItem.ToString()));
            });
        }

        private void btnLoot_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                sendCommand(Util.GenerateCommand("loot", cbBotList.SelectedItem.ToString()));
            });
        }

        private void btnLootAll_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                sendCommand("lootall");
            });
        }

        #endregion

        #region Keys Buttons

        private void sendMultiCommand(object sender, EventArgs e, string command) {
            Task.Run(() => {
                if (!tbInput.Text.Equals("")) {
                    tbInput.Invoke(new MethodInvoker(() => {
                        tbInput.Text = Regex.Replace(tbInput.Text, @"(,+|\s+)+", Environment.NewLine); // cleaning up the list
                    }));
                    sendCommand(Util.GenerateCommand(command, (string) cbBotList.Invoke((Func<string>) delegate {
                        return cbBotList.SelectedItem.ToString();
                    }), Util.MultiToOne(tbInput.Lines)));
                } else {
                    Logging.Error("Input required (!" + command +")");
                    MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        private void btnRedeem_Click(object sender, EventArgs e)
        {
            sendMultiCommand(sender, e, "redeem");
        }

        private void btnRedeemNF_Click(object sender, EventArgs e)
        {
            sendMultiCommand(sender, e, "redeem^");
        }

        private void btnRedeemFF_Click(object sender, EventArgs e)
        {
            sendMultiCommand(sender, e, "redeem&");
        }

        private void btnAddLicense_Click(object sender, EventArgs e)
        {
            sendMultiCommand(sender, e, "addlicense");
        }

        #endregion

        #region Games Buttons

        private void btnOwns_Click(object sender, EventArgs e)
        {
            sendMultiCommand(sender, e, "owns");
        }

        private void btnOwnAll_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!tbInput.Text.Equals(""))
                {
                    sendCommand(Util.GenerateCommand("ownsall", string.Empty, Util.MultiToOne(tbInput.Lines)));
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
            sendMultiCommand(sender, e, "play");
        }

        #endregion

        #region Chat Buttons

        private void btnRejoin_Click(object sender, EventArgs e)
        {
            sendCommand("rejoinchat");
        }

        #endregion

        #region Bots Buttons

        private void btnStartBot_Click(object sender, EventArgs e)
        {
            sendCommand(Util.GenerateCommand("start", cbBotList.SelectedItem.ToString()));
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            sendCommand("startall");
            GetBotList();
        }

        private void btnStopBot_Click(object sender, EventArgs e)
        {
            sendCommand(Util.GenerateCommand("stop", cbBotList.SelectedItem.ToString()));
        }

        private void btnPauseBot_Click(object sender, EventArgs e)
        {
            sendCommand(Util.GenerateCommand("pause", cbBotList.SelectedItem.ToString()));
        }

        private void btnPauseBotPerma_Click(object sender, EventArgs e)
        {
            sendCommand(Util.GenerateCommand("pause^", cbBotList.SelectedItem.ToString()));
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            sendCommand(Util.GenerateCommand("resume", cbBotList.SelectedItem.ToString()));
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            sendCommand(Util.GenerateCommand("password", cbBotList.SelectedItem.ToString()));
        }

        private void btnStatusBot_Click(object sender, EventArgs e)
        {
            sendCommand(Util.GenerateCommand("status", cbBotList.SelectedItem.ToString()));
        }

        private void btnStatusAll_Click(object sender, EventArgs e)
        {
            sendCommand("statusall");
        }

        #endregion

        #region ASF Buttons

        private void btnASFHelp_Click(object sender, EventArgs e)
        {
            sendCommand("help");
        }

        private void btnASFUpdate_Click(object sender, EventArgs e)
        {
            sendCommand("update");
        }

        private void btnASFVersion_Click(object sender, EventArgs e)
        {
            sendCommand("version");
        }

        private void btnAPI_Click(object sender, EventArgs e)
        {
            var result = sendCommand("api");
            Task.Run(() =>
            {
                var api = new Api(result);
                MessageBox.Show(api.AllApi(), @"API result", MessageBoxButtons.OK);
            });

        }

        #endregion

        #region 2FA Buttons

        private string sendCommand(string str) {
            string ret = Util.SendCommand(str);
            if (!Settings.Default.IsLocal) {
                rtbOutput.AppendText(ret + "\n");
            }
            if (!"api".Equals(str)) { // don't know, why you did not had that here, but just to be sure.
                rtbOutput.Invoke(new MethodInvoker(() => {// In debug mode I get errors here, if I do not use invoke...
                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }));
            }
            return ret;
        }

        private void btn2FA_Click(object sender, EventArgs e)
        {
            sendCommand(Util.GenerateCommand("2fa", cbBotList.SelectedItem.ToString()));
        }

        private void btn2FAOk_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                sendCommand(Util.GenerateCommand("2faok", cbBotList.SelectedItem.ToString()));
            });
        }

        private void btn2FANo_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                sendCommand(Util.GenerateCommand("2fano", cbBotList.SelectedItem.ToString()));
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
            btnPauseBotPerma.Enabled = true;
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
            btnPauseBotPerma.Enabled = false;
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

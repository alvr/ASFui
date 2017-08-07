using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASFui.Properties;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace ASFui
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class ASFui : Form
    {
        private ASFProcess _asf;
        private bool _asfRunning;

        public ASFui()
        {
            Util.CheckVersion();
            Util.UpgradeSettings();
            while (!Util.CheckBinary())
            {
                var result = MessageBox.Show(@"ASF binary setting not configured. Configure now?", @"ASF binary not found.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Settings.Default.ASFBinary = "Setting not configured.";
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
                var result = MessageBox.Show(@"An instance of ASF is already running. Switching to remote mode.", @"ASF already running.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    Settings.Default.IsLocal = false;
                    Settings.Default.RemoteURL = Util.GetEndpointAddress();
                }
                else
                {
                    Environment.Exit(-2);
                }
            }
            InitializeComponent();
        }

        private void ASFui_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized || !Settings.Default.ToTray) return;
            Hide();
            TrayIcon.Visible = true;
        }

        private void ASFui_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Maximized)
                WindowState = FormWindowState.Maximized;

            Location = Settings.Default.Location;
            var formRectangle = new Rectangle(Left, Top, Width, Height);
            if (!Util.IsOnScreen(formRectangle))
            {
                var settingsProperty = Settings.Default.Properties["Location"];
                if (settingsProperty != null)
                {
                    var coords = settingsProperty.DefaultValue.ToString().Split(',');
                    Location = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                }
            }

            Size = Settings.Default.Size;
            if (Size.Height < MinimumSize.Height || Size.Width < MinimumSize.Width)
            {
                var settingsProperty = Settings.Default.Properties["Size"];
                if (settingsProperty != null)
                    Size = (Size) settingsProperty.DefaultValue;
            }

            if (Settings.Default.Autostart)
                Task.Delay(500).ContinueWith(t => cbBotList.Invoke(new MethodInvoker(() => btnStart.PerformClick())));
        }

        private void ASFui_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    Settings.Default.Location = RestoreBounds.Location;
                    Settings.Default.Size = RestoreBounds.Size;
                    Settings.Default.Maximized = true;
                    break;
                case FormWindowState.Normal:
                    Settings.Default.Location = Location;
                    Settings.Default.Size = Size;
                    Settings.Default.Maximized = false;
                    break;
                case FormWindowState.Minimized:
                    break;
                default:
                    Settings.Default.Location = RestoreBounds.Location;
                    Settings.Default.Size = RestoreBounds.Size;
                    Settings.Default.Maximized = false;
                    break;
            }
            Settings.Default.Save();
            if (!_asfRunning || !Settings.Default.IsLocal) return;
            _asf.Stop();
            Logging.Info(@"Closing ASFui.");
        }

        public void GetBotList()
        {
            cbBotList.Invoke(new MethodInvoker(() => cbBotList.Items.Clear()));

            var status = Util.SendCommand("status ASF");
            var matches = Regex.Matches(status, @"<(.+?)> Bot is");
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

        public bool GetFileBotList()
        {
            var binary = Settings.Default.ASFBinary;
            var index = binary.LastIndexOf('/');

            if (index == -1) index = binary.LastIndexOf('\\');
            if (index == -1) return false;

            var folder = binary.Substring(0, index) + "\\config";
            var files = Directory.GetFiles(folder, "*.json");
            if (files.Length <= 1) return false;

            cbBotList.Invoke(new MethodInvoker(() => cbBotList.Items.Clear()));
            foreach (var file in files)
            {
                index = file.LastIndexOf('/');
                if (index == -1) index = file.LastIndexOf('\\');
                var name = file.Substring(index + 1).Replace(".json", "");
                if (!"ASF".Equals(name) && !"minimal".Equals(name) && !"example".Equals(name))
                    cbBotList.Items.Add(name);
            }
            Logging.Info("Bot list refreshed. Detected " + (files.Length - 1) + " bots.");


            cbBotList.Invoke(new MethodInvoker(() =>
            {
                cbBotList.SelectedIndex = 0;
                EnableElements();
            }));

            return true;
        }

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
            btnAddLicenseAll.Enabled = true;
            btnOwns.Enabled = true;
            btnOwnAll.Enabled = true;
            btnPlay.Enabled = true;
            btnRejoin.Enabled = true;
            btnStartBot.Enabled = true;
            btnStartAll.Enabled = true;
            btnStopBot.Enabled = true;
            btnDistribute.Enabled = true;
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
            btnUnpack.Enabled = true;
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
            btnAddLicenseAll.Enabled = false;
            btnRedeem.Enabled = false;
            btnDistribute.Enabled = false;
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
            btnUnpack.Enabled = false;
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

        private void rtbOutput_LinkClicked(object sender, LinkClickedEventArgs e) => Process.Start(e.LinkText);

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
        }

        private void tsmiClose_Click(object sender, EventArgs e) => Close();

        #region Buttons Events

        #region Start/Stop Buttons

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (Settings.Default.IsLocal)
            {
                var binary = Settings.Default.ASFBinary;
                var index = binary.LastIndexOf('/');
                if (index == -1) index = binary.LastIndexOf('\\');
                if (index != -1)
                {
                    var message = "The following arameter will be changed automatically. Abort to change them manually." + Environment.NewLine;
                    var asfJson = binary.Substring(0, index) + "\\config\\ASF.json";
                    dynamic asfConfig = JsonConvert.DeserializeObject(File.ReadAllText(asfJson));
                    string culture = asfConfig.CurrentCulture;
                    var dialog = false;
                    if (!"en".Equals(culture))
                    {
                        message += "Language (CurrentCulture): is: ${asfConfig.CurrentCulture}, will be: \"en\"" + Environment.NewLine;
                        asfConfig.CurrentCulture = "en";
                        dialog = true;
                    }
                    if (asfConfig.AutoRestart.Value)
                    {
                        message += "AutoRestart (ASFui always restart ASF): is: " + asfConfig.AutoRestart + ", will be: false" + Environment.NewLine;
                        asfConfig.AutoRestart.Value = false;
                        dialog = true;
                    }
                    if (asfConfig.SteamOwnerID.Value == 0)
                    {
                        var result = Interaction.InputBox(@"SteamOwnerID is set to 0. It should be the Steam64ID of your primary account. Go to http://steamid.co if you don't know yours.", @"Enter necessary input");
                        asfConfig.SteamOwnerID.Value = ulong.Parse(result);
                        message += "SteamOwnerID is 0, will be ${asfConfig.SteamOwnerID.Value}" + Environment.NewLine;
                        dialog = true;
                    }

                    if (dialog)
                    {
                        var result = MessageBox.Show(message, @"Config needs to be changed.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            try
                            {
                                File.WriteAllText(asfJson, JsonConvert.SerializeObject(asfConfig, Formatting.Indented));
                            }
                            catch (Exception)
                            {
                                MessageBox.Show(@"Error writing changes. Change manually and restart." + Environment.NewLine + @"Exiting....");
                                Application.Exit();
                                return;
                            }
                        }
                        else
                        {
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
                if (!Util.CheckUrl(Settings.Default.RemoteURL))
                {
                    rtbOutput.AppendText(@"Cannot connect to remote URL " + Settings.Default.RemoteURL +
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
            if (Settings.Default.IsLocal)
                _asf.Stop();
            DisableElements();
            Logging.Info("Server stopped successfully.");
        }

        private void BtnClear_Click(object sender, EventArgs e) => rtbOutput.Clear();

        private void btnReloadBots_Click(object sender, EventArgs e) => GetBotList();

        private void btnASFuiSettings_Click(object sender, EventArgs e) => new SettingsForm().ShowDialog();

        private void btnASFuiHelp_Click(object sender, EventArgs e) => Process.Start("https://github.com/alvr/ASFui/wiki");

        #endregion

        #region Cards Buttons

        private void btnFarm_Click(object sender, EventArgs e) => Task.Run(() => { SendCommand(Util.GenerateCommand("farm", cbBotList.SelectedItem.ToString())); });

        private void btnLoot_Click(object sender, EventArgs e) => Task.Run(() => { SendCommand(Util.GenerateCommand("loot", cbBotList.SelectedItem.ToString())); });

        private void btnLootAll_Click(object sender, EventArgs e) => Task.Run(() => { SendCommand("loot ASF"); });

        #endregion

        #region Keys Buttons

        private void SendMultiCommand(string command, string commandPrepend = "") => Task.Run(() =>
        {
            if (!tbInput.Text.Equals(""))
            {
                tbInput.Invoke(new MethodInvoker(() =>
                {
                    tbInput.Text = Regex.Replace(tbInput.Text, @"(,+|\s+)+", Environment.NewLine); // cleaning up the list
                }));
                SendCommand(Util.GenerateCommand(command,
                    (string) cbBotList.Invoke((Func<string>) (() => cbBotList.SelectedItem.ToString())),
                    commandPrepend + Util.MultiToOne(tbInput.Lines)));
            }
            else
            {
                Logging.Error("Input required (!" + command + ")");
                MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        });

        private void btnRedeem_Click(object sender, EventArgs e) => SendMultiCommand("redeem");

        private void btnRedeemNF_Click(object sender, EventArgs e) => SendMultiCommand("redeem^", " sf,sd ");

        private void btnRedeemFF_Click(object sender, EventArgs e) => SendMultiCommand("redeem^", " ff,si ");

        private void btnDistribute_Click(object sender, EventArgs e) => SendMultiCommand("redeem^", " fd ");

        private void btnAddLicense_Click(object sender, EventArgs e) => SendMultiCommand("addlicense");

        private void btnAddLicenseAllClick(object sender, EventArgs e) => Task.Run(() =>
        {
            if (!tbInput.Text.Equals(""))
            {
                var objs = (ComboBox.ObjectCollection) cbBotList.Invoke((Func<ComboBox.ObjectCollection>) (() => cbBotList.Items));
                var bots = objs.Cast<string>().ToArray();
                foreach (var bot in bots)
                {
                    tbInput.Invoke(new MethodInvoker(() => {
                        tbInput.Text = Regex.Replace(tbInput.Text, @"(,+|\s+)+", Environment.NewLine); // cleaning up the list
                    }));
                    SendCommand(Util.GenerateCommand("addlicense", bot, Util.MultiToOne(tbInput.Lines)));
                }
            }
            else
            {
                Logging.Error("Input required (!addlicense)");
                MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        });

        #endregion

        #region Games Buttons

        private void btnOwns_Click(object sender, EventArgs e) => SendMultiCommand("owns");

        private void btnOwnAll_Click(object sender, EventArgs e) => Task.Run(() =>
        {
            if (!tbInput.Text.Equals(""))
            {
                SendCommand(Util.GenerateCommand("owns", "ASF", Util.MultiToOne(tbInput.Lines)));
            }
            else
            {
                Logging.Error(@"Input required (!owns ASF)");
                MessageBox.Show(@"An input is required.", @"Input required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        });

        private void btnPlay_Click(object sender, EventArgs e) => SendMultiCommand("play");

        #endregion

        #region Chat Buttons

        private void btnRejoin_Click(object sender, EventArgs e) => SendCommand("rejoinchat");

        #endregion

        #region Bots Buttons

        private void btnStartBot_Click(object sender, EventArgs e) => SendCommand(Util.GenerateCommand("start", cbBotList.SelectedItem.ToString()));

        private void btnUnpack_Click(object sender, EventArgs e) => SendCommand(Util.GenerateCommand("unpack", cbBotList.SelectedItem.ToString()));

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            SendCommand("start ASF");
            GetBotList();
        }

        private void btnStopBot_Click(object sender, EventArgs e) => SendCommand(Util.GenerateCommand("stop", cbBotList.SelectedItem.ToString()));

        private void btnPauseBot_Click(object sender, EventArgs e) => SendCommand(Util.GenerateCommand("pause", cbBotList.SelectedItem.ToString()));

        private void btnPauseBotPerma_Click(object sender, EventArgs e) => SendCommand(Util.GenerateCommand("pause^", cbBotList.SelectedItem.ToString()));

        private void btnResume_Click(object sender, EventArgs e) => SendCommand(Util.GenerateCommand("resume", cbBotList.SelectedItem.ToString()));

        private void btnPassword_Click(object sender, EventArgs e) => SendCommand(Util.GenerateCommand("password", cbBotList.SelectedItem.ToString()));

        private void btnStatusBot_Click(object sender, EventArgs e) => SendCommand(Util.GenerateCommand("status", cbBotList.SelectedItem.ToString()));

        private void btnStatusAll_Click(object sender, EventArgs e) => SendCommand("status ASF");

        #endregion

        #region ASF Buttons

        private void btnASFHelp_Click(object sender, EventArgs e) => SendCommand("help");

        private void btnASFUpdate_Click(object sender, EventArgs e) => Task.Run(() =>
        {
            DisableElements();
            btnASFuiSettings.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnClear.Enabled = false;
            SendCommand("update");
            InvokeOnClick(btnStop, EventArgs.Empty);
        }).ContinueWith(t => InvokeOnClick(btnStart, EventArgs.Empty));

        private void btnASFVersion_Click(object sender, EventArgs e) => SendCommand("version");

        private void btnAPI_Click(object sender, EventArgs e)
        {
            var result = SendCommand("api");
            Task.Run(() =>
            {
                var api = new Api(result);
                MessageBox.Show(api.AllApi(), @"API result", MessageBoxButtons.OK);
            });
        }

        #endregion

        #region 2FA Buttons

        private string SendCommand(string str)
        {
            var ret = Util.SendCommand(str);
            if (!Settings.Default.IsLocal)
                rtbOutput.AppendText(ret + "\n");

            if (!"api".Equals(str))
                rtbOutput.Invoke(new MethodInvoker(() =>
                {
                    // In debug mode I get errors here, if I do not use invoke...
                    rtbOutput.SelectionStart = rtbOutput.Text.Length;
                    rtbOutput.ScrollToCaret();
                }));
            return ret;
        }

        private void btn2FA_Click(object sender, EventArgs e) => Task.Run(() => { SendCommand(Util.GenerateCommand("2fa", cbBotList.SelectedItem.ToString())); });

        private void btn2FAOk_Click(object sender, EventArgs e) => Task.Run(() => { SendCommand(Util.GenerateCommand("2faok", cbBotList.SelectedItem.ToString())); });

        private void btn2FANo_Click(object sender, EventArgs e) => Task.Run(() => { SendCommand(Util.GenerateCommand("2fano", cbBotList.SelectedItem.ToString())); });

        #endregion

        #endregion
    }
}
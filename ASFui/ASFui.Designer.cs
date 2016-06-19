namespace ASFui
{
    partial class ASFui
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ASFProcess = new System.Diagnostics.Process();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbBotList = new System.Windows.Forms.ComboBox();
            this.lbCurrentBot = new System.Windows.Forms.Label();
            this.btnReloadBots = new System.Windows.Forms.Button();
            this.gbKeys = new System.Windows.Forms.GroupBox();
            this.tlpKeys = new System.Windows.Forms.TableLayoutPanel();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.btnAddLicense = new System.Windows.Forms.Button();
            this.gb2FA = new System.Windows.Forms.GroupBox();
            this.tlp2FA = new System.Windows.Forms.TableLayoutPanel();
            this.btn2FA = new System.Windows.Forms.Button();
            this.btn2FAOk = new System.Windows.Forms.Button();
            this.btn2FANo = new System.Windows.Forms.Button();
            this.btn2FAOff = new System.Windows.Forms.Button();
            this.gbCards = new System.Windows.Forms.GroupBox();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.btnFarm = new System.Windows.Forms.Button();
            this.btnLoot = new System.Windows.Forms.Button();
            this.gbBots = new System.Windows.Forms.GroupBox();
            this.tlpBots = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartBot = new System.Windows.Forms.Button();
            this.btnStopBot = new System.Windows.Forms.Button();
            this.btnStatusAll = new System.Windows.Forms.Button();
            this.btnStatusBot = new System.Windows.Forms.Button();
            this.btnPauseBot = new System.Windows.Forms.Button();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.gbChat = new System.Windows.Forms.GroupBox();
            this.tlpChat = new System.Windows.Forms.TableLayoutPanel();
            this.btnLeave = new System.Windows.Forms.Button();
            this.btnRejoin = new System.Windows.Forms.Button();
            this.gbGames = new System.Windows.Forms.GroupBox();
            this.tlpGames = new System.Windows.Forms.TableLayoutPanel();
            this.btnOwns = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.gbASF = new System.Windows.Forms.GroupBox();
            this.tlpASF = new System.Windows.Forms.TableLayoutPanel();
            this.btnASFHelp = new System.Windows.Forms.Button();
            this.btnASFUpdate = new System.Windows.Forms.Button();
            this.btnASFVersion = new System.Windows.Forms.Button();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslLastCommand = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCommandOutput = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbKeys.SuspendLayout();
            this.tlpKeys.SuspendLayout();
            this.gb2FA.SuspendLayout();
            this.tlp2FA.SuspendLayout();
            this.gbCards.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.gbBots.SuspendLayout();
            this.tlpBots.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.gbChat.SuspendLayout();
            this.tlpChat.SuspendLayout();
            this.gbGames.SuspendLayout();
            this.tlpGames.SuspendLayout();
            this.gbASF.SuspendLayout();
            this.tlpASF.SuspendLayout();
            this.cmsTrayIcon.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbOutput.Enabled = false;
            this.rtbOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.ForeColor = System.Drawing.Color.Black;
            this.rtbOutput.Location = new System.Drawing.Point(12, 332);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(670, 100);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.WorkerReportsProgress = true;
            this.BackgroundWorker.WorkerSupportsCancellation = true;
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            // 
            // ASFProcess
            // 
            this.ASFProcess.StartInfo.Arguments = "--server";
            this.ASFProcess.StartInfo.CreateNoWindow = true;
            this.ASFProcess.StartInfo.Domain = "";
            this.ASFProcess.StartInfo.FileName = "ASF.exe";
            this.ASFProcess.StartInfo.LoadUserProfile = false;
            this.ASFProcess.StartInfo.Password = null;
            this.ASFProcess.StartInfo.RedirectStandardError = true;
            this.ASFProcess.StartInfo.RedirectStandardInput = true;
            this.ASFProcess.StartInfo.RedirectStandardOutput = true;
            this.ASFProcess.StartInfo.StandardErrorEncoding = null;
            this.ASFProcess.StartInfo.StandardOutputEncoding = null;
            this.ASFProcess.StartInfo.UserName = "";
            this.ASFProcess.StartInfo.UseShellExecute = false;
            this.ASFProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            this.ASFProcess.SynchronizingObject = this;
            this.ASFProcess.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(this.ProcesoASF_OutputDataReceived);
            this.ASFProcess.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(this.ASFProcess_ErrorDataReceived);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(526, 438);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(445, 438);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(607, 438);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear Log";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // cbBotList
            // 
            this.cbBotList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBotList.Enabled = false;
            this.cbBotList.FormattingEnabled = true;
            this.cbBotList.Location = new System.Drawing.Point(81, 438);
            this.cbBotList.Name = "cbBotList";
            this.cbBotList.Size = new System.Drawing.Size(121, 21);
            this.cbBotList.TabIndex = 4;
            // 
            // lbCurrentBot
            // 
            this.lbCurrentBot.AutoSize = true;
            this.lbCurrentBot.Location = new System.Drawing.Point(12, 443);
            this.lbCurrentBot.Name = "lbCurrentBot";
            this.lbCurrentBot.Size = new System.Drawing.Size(63, 13);
            this.lbCurrentBot.TabIndex = 6;
            this.lbCurrentBot.Text = "Current Bot:";
            // 
            // btnReloadBots
            // 
            this.btnReloadBots.Enabled = false;
            this.btnReloadBots.Location = new System.Drawing.Point(208, 437);
            this.btnReloadBots.Name = "btnReloadBots";
            this.btnReloadBots.Size = new System.Drawing.Size(23, 23);
            this.btnReloadBots.TabIndex = 7;
            this.btnReloadBots.Text = "🔃";
            this.btnReloadBots.UseVisualStyleBackColor = true;
            this.btnReloadBots.Click += new System.EventHandler(this.btnReloadBots_Click);
            // 
            // gbKeys
            // 
            this.gbKeys.Controls.Add(this.tlpKeys);
            this.gbKeys.Location = new System.Drawing.Point(476, 12);
            this.gbKeys.Name = "gbKeys";
            this.gbKeys.Size = new System.Drawing.Size(206, 58);
            this.gbKeys.TabIndex = 27;
            this.gbKeys.TabStop = false;
            this.gbKeys.Text = "Keys";
            // 
            // tlpKeys
            // 
            this.tlpKeys.ColumnCount = 2;
            this.tlpKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpKeys.Controls.Add(this.btnRedeem, 0, 0);
            this.tlpKeys.Controls.Add(this.btnAddLicense, 1, 0);
            this.tlpKeys.Location = new System.Drawing.Point(6, 19);
            this.tlpKeys.Name = "tlpKeys";
            this.tlpKeys.RowCount = 1;
            this.tlpKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpKeys.Size = new System.Drawing.Size(194, 33);
            this.tlpKeys.TabIndex = 1;
            // 
            // btnRedeem
            // 
            this.btnRedeem.Enabled = false;
            this.btnRedeem.Location = new System.Drawing.Point(3, 3);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(91, 27);
            this.btnRedeem.TabIndex = 0;
            this.btnRedeem.Text = "Redeem Key";
            this.btnRedeem.UseVisualStyleBackColor = true;
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // btnAddLicense
            // 
            this.btnAddLicense.Enabled = false;
            this.btnAddLicense.Location = new System.Drawing.Point(100, 3);
            this.btnAddLicense.Name = "btnAddLicense";
            this.btnAddLicense.Size = new System.Drawing.Size(91, 27);
            this.btnAddLicense.TabIndex = 1;
            this.btnAddLicense.Text = "Add License";
            this.btnAddLicense.UseVisualStyleBackColor = true;
            this.btnAddLicense.Click += new System.EventHandler(this.btnAddLicense_Click);
            // 
            // gb2FA
            // 
            this.gb2FA.Controls.Add(this.tlp2FA);
            this.gb2FA.Location = new System.Drawing.Point(12, 268);
            this.gb2FA.Name = "gb2FA";
            this.gb2FA.Size = new System.Drawing.Size(670, 58);
            this.gb2FA.TabIndex = 26;
            this.gb2FA.TabStop = false;
            this.gb2FA.Text = "2FA";
            // 
            // tlp2FA
            // 
            this.tlp2FA.ColumnCount = 4;
            this.tlp2FA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp2FA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp2FA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp2FA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp2FA.Controls.Add(this.btn2FA, 0, 0);
            this.tlp2FA.Controls.Add(this.btn2FAOk, 2, 0);
            this.tlp2FA.Controls.Add(this.btn2FANo, 3, 0);
            this.tlp2FA.Controls.Add(this.btn2FAOff, 1, 0);
            this.tlp2FA.Location = new System.Drawing.Point(6, 19);
            this.tlp2FA.Name = "tlp2FA";
            this.tlp2FA.RowCount = 1;
            this.tlp2FA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp2FA.Size = new System.Drawing.Size(658, 31);
            this.tlp2FA.TabIndex = 1;
            // 
            // btn2FA
            // 
            this.btn2FA.Enabled = false;
            this.btn2FA.Location = new System.Drawing.Point(3, 3);
            this.btn2FA.Name = "btn2FA";
            this.btn2FA.Size = new System.Drawing.Size(158, 25);
            this.btn2FA.TabIndex = 0;
            this.btn2FA.Text = "Generate Token";
            this.btn2FA.UseVisualStyleBackColor = true;
            this.btn2FA.Click += new System.EventHandler(this.btn2FA_Click);
            // 
            // btn2FAOk
            // 
            this.btn2FAOk.Enabled = false;
            this.btn2FAOk.Location = new System.Drawing.Point(331, 3);
            this.btn2FAOk.Name = "btn2FAOk";
            this.btn2FAOk.Size = new System.Drawing.Size(158, 25);
            this.btn2FAOk.TabIndex = 2;
            this.btn2FAOk.Text = "Accept Pending Confirmations";
            this.btn2FAOk.UseVisualStyleBackColor = true;
            this.btn2FAOk.Click += new System.EventHandler(this.btn2FAOk_Click);
            // 
            // btn2FANo
            // 
            this.btn2FANo.Enabled = false;
            this.btn2FANo.Location = new System.Drawing.Point(495, 3);
            this.btn2FANo.Name = "btn2FANo";
            this.btn2FANo.Size = new System.Drawing.Size(160, 25);
            this.btn2FANo.TabIndex = 3;
            this.btn2FANo.Text = "Deny Pending Confirmations";
            this.btn2FANo.UseVisualStyleBackColor = true;
            this.btn2FANo.Click += new System.EventHandler(this.btn2FANo_Click);
            // 
            // btn2FAOff
            // 
            this.btn2FAOff.Enabled = false;
            this.btn2FAOff.Location = new System.Drawing.Point(167, 3);
            this.btn2FAOff.Name = "btn2FAOff";
            this.btn2FAOff.Size = new System.Drawing.Size(158, 25);
            this.btn2FAOff.TabIndex = 1;
            this.btn2FAOff.Text = "Deactivate 2FA";
            this.btn2FAOff.UseVisualStyleBackColor = true;
            this.btn2FAOff.Click += new System.EventHandler(this.btn2FAOff_Click);
            // 
            // gbCards
            // 
            this.gbCards.Controls.Add(this.tlpCards);
            this.gbCards.Location = new System.Drawing.Point(264, 12);
            this.gbCards.Name = "gbCards";
            this.gbCards.Size = new System.Drawing.Size(206, 58);
            this.gbCards.TabIndex = 24;
            this.gbCards.TabStop = false;
            this.gbCards.Text = "Cards";
            // 
            // tlpCards
            // 
            this.tlpCards.ColumnCount = 2;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCards.Controls.Add(this.btnFarm, 0, 0);
            this.tlpCards.Controls.Add(this.btnLoot, 1, 0);
            this.tlpCards.Location = new System.Drawing.Point(6, 19);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCards.Size = new System.Drawing.Size(194, 33);
            this.tlpCards.TabIndex = 0;
            // 
            // btnFarm
            // 
            this.btnFarm.Enabled = false;
            this.btnFarm.Location = new System.Drawing.Point(3, 3);
            this.btnFarm.Name = "btnFarm";
            this.btnFarm.Size = new System.Drawing.Size(91, 27);
            this.btnFarm.TabIndex = 0;
            this.btnFarm.Text = "Farm";
            this.btnFarm.UseVisualStyleBackColor = true;
            this.btnFarm.Click += new System.EventHandler(this.btnFarm_Click);
            // 
            // btnLoot
            // 
            this.btnLoot.Enabled = false;
            this.btnLoot.Location = new System.Drawing.Point(100, 3);
            this.btnLoot.Name = "btnLoot";
            this.btnLoot.Size = new System.Drawing.Size(91, 27);
            this.btnLoot.TabIndex = 1;
            this.btnLoot.Text = "Loot";
            this.btnLoot.UseVisualStyleBackColor = true;
            this.btnLoot.Click += new System.EventHandler(this.btnLoot_Click);
            // 
            // gbBots
            // 
            this.gbBots.Controls.Add(this.tlpBots);
            this.gbBots.Location = new System.Drawing.Point(264, 140);
            this.gbBots.Name = "gbBots";
            this.gbBots.Size = new System.Drawing.Size(418, 58);
            this.gbBots.TabIndex = 23;
            this.gbBots.TabStop = false;
            this.gbBots.Text = "Manage bots";
            // 
            // tlpBots
            // 
            this.tlpBots.ColumnCount = 5;
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBots.Controls.Add(this.btnStartBot, 0, 0);
            this.tlpBots.Controls.Add(this.btnStopBot, 1, 0);
            this.tlpBots.Controls.Add(this.btnStatusAll, 4, 0);
            this.tlpBots.Controls.Add(this.btnStatusBot, 3, 0);
            this.tlpBots.Controls.Add(this.btnPauseBot, 2, 0);
            this.tlpBots.Location = new System.Drawing.Point(6, 19);
            this.tlpBots.Name = "tlpBots";
            this.tlpBots.RowCount = 1;
            this.tlpBots.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBots.Size = new System.Drawing.Size(406, 31);
            this.tlpBots.TabIndex = 0;
            // 
            // btnStartBot
            // 
            this.btnStartBot.Enabled = false;
            this.btnStartBot.Location = new System.Drawing.Point(3, 3);
            this.btnStartBot.Name = "btnStartBot";
            this.btnStartBot.Size = new System.Drawing.Size(75, 25);
            this.btnStartBot.TabIndex = 0;
            this.btnStartBot.Text = "Start";
            this.btnStartBot.UseVisualStyleBackColor = true;
            this.btnStartBot.Click += new System.EventHandler(this.btnStartBot_Click);
            // 
            // btnStopBot
            // 
            this.btnStopBot.Enabled = false;
            this.btnStopBot.Location = new System.Drawing.Point(84, 3);
            this.btnStopBot.Name = "btnStopBot";
            this.btnStopBot.Size = new System.Drawing.Size(75, 25);
            this.btnStopBot.TabIndex = 1;
            this.btnStopBot.Text = "Stop";
            this.btnStopBot.UseVisualStyleBackColor = true;
            this.btnStopBot.Click += new System.EventHandler(this.btnStopBot_Click);
            // 
            // btnStatusAll
            // 
            this.btnStatusAll.Enabled = false;
            this.btnStatusAll.Location = new System.Drawing.Point(327, 3);
            this.btnStatusAll.Name = "btnStatusAll";
            this.btnStatusAll.Size = new System.Drawing.Size(76, 25);
            this.btnStatusAll.TabIndex = 3;
            this.btnStatusAll.Text = "Status All";
            this.btnStatusAll.UseVisualStyleBackColor = true;
            this.btnStatusAll.Click += new System.EventHandler(this.btnStatusAll_Click);
            // 
            // btnStatusBot
            // 
            this.btnStatusBot.Enabled = false;
            this.btnStatusBot.Location = new System.Drawing.Point(246, 3);
            this.btnStatusBot.Name = "btnStatusBot";
            this.btnStatusBot.Size = new System.Drawing.Size(75, 25);
            this.btnStatusBot.TabIndex = 2;
            this.btnStatusBot.Text = "Status";
            this.btnStatusBot.UseVisualStyleBackColor = true;
            this.btnStatusBot.Click += new System.EventHandler(this.btnStatusBot_Click);
            // 
            // btnPauseBot
            // 
            this.btnPauseBot.Enabled = false;
            this.btnPauseBot.Location = new System.Drawing.Point(165, 3);
            this.btnPauseBot.Name = "btnPauseBot";
            this.btnPauseBot.Size = new System.Drawing.Size(75, 25);
            this.btnPauseBot.TabIndex = 4;
            this.btnPauseBot.Text = "Pause";
            this.btnPauseBot.UseVisualStyleBackColor = true;
            this.btnPauseBot.Click += new System.EventHandler(this.btnPauseBot_Click);
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.tbInput);
            this.gbInput.Location = new System.Drawing.Point(12, 12);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(246, 250);
            this.gbInput.TabIndex = 22;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Input";
            // 
            // tbInput
            // 
            this.tbInput.Enabled = false;
            this.tbInput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(6, 19);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(234, 222);
            this.tbInput.TabIndex = 6;
            // 
            // gbChat
            // 
            this.gbChat.Controls.Add(this.tlpChat);
            this.gbChat.Location = new System.Drawing.Point(476, 76);
            this.gbChat.Name = "gbChat";
            this.gbChat.Size = new System.Drawing.Size(206, 58);
            this.gbChat.TabIndex = 29;
            this.gbChat.TabStop = false;
            this.gbChat.Text = "Chat";
            // 
            // tlpChat
            // 
            this.tlpChat.ColumnCount = 2;
            this.tlpChat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChat.Controls.Add(this.btnLeave, 0, 0);
            this.tlpChat.Controls.Add(this.btnRejoin, 1, 0);
            this.tlpChat.Location = new System.Drawing.Point(6, 19);
            this.tlpChat.Name = "tlpChat";
            this.tlpChat.RowCount = 1;
            this.tlpChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChat.Size = new System.Drawing.Size(194, 33);
            this.tlpChat.TabIndex = 1;
            // 
            // btnLeave
            // 
            this.btnLeave.Enabled = false;
            this.btnLeave.Location = new System.Drawing.Point(3, 3);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(91, 27);
            this.btnLeave.TabIndex = 0;
            this.btnLeave.Text = "Leave Chat";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // btnRejoin
            // 
            this.btnRejoin.Enabled = false;
            this.btnRejoin.Location = new System.Drawing.Point(100, 3);
            this.btnRejoin.Name = "btnRejoin";
            this.btnRejoin.Size = new System.Drawing.Size(91, 27);
            this.btnRejoin.TabIndex = 1;
            this.btnRejoin.Text = "Rejoin Chat";
            this.btnRejoin.UseVisualStyleBackColor = true;
            this.btnRejoin.Click += new System.EventHandler(this.btnRejoin_Click);
            // 
            // gbGames
            // 
            this.gbGames.Controls.Add(this.tlpGames);
            this.gbGames.Location = new System.Drawing.Point(264, 76);
            this.gbGames.Name = "gbGames";
            this.gbGames.Size = new System.Drawing.Size(206, 58);
            this.gbGames.TabIndex = 28;
            this.gbGames.TabStop = false;
            this.gbGames.Text = "Games";
            // 
            // tlpGames
            // 
            this.tlpGames.ColumnCount = 2;
            this.tlpGames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGames.Controls.Add(this.btnOwns, 0, 0);
            this.tlpGames.Controls.Add(this.btnPlay, 1, 0);
            this.tlpGames.Location = new System.Drawing.Point(6, 19);
            this.tlpGames.Name = "tlpGames";
            this.tlpGames.RowCount = 1;
            this.tlpGames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGames.Size = new System.Drawing.Size(194, 33);
            this.tlpGames.TabIndex = 0;
            // 
            // btnOwns
            // 
            this.btnOwns.Enabled = false;
            this.btnOwns.Location = new System.Drawing.Point(3, 3);
            this.btnOwns.Name = "btnOwns";
            this.btnOwns.Size = new System.Drawing.Size(91, 27);
            this.btnOwns.TabIndex = 0;
            this.btnOwns.Text = "Own";
            this.btnOwns.UseVisualStyleBackColor = true;
            this.btnOwns.Click += new System.EventHandler(this.btnOwns_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(100, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(91, 27);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // gbASF
            // 
            this.gbASF.Controls.Add(this.tlpASF);
            this.gbASF.Location = new System.Drawing.Point(264, 204);
            this.gbASF.Name = "gbASF";
            this.gbASF.Size = new System.Drawing.Size(418, 58);
            this.gbASF.TabIndex = 30;
            this.gbASF.TabStop = false;
            this.gbASF.Text = "ArchiSteamFarm";
            // 
            // tlpASF
            // 
            this.tlpASF.ColumnCount = 3;
            this.tlpASF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpASF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpASF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpASF.Controls.Add(this.btnASFHelp, 0, 0);
            this.tlpASF.Controls.Add(this.btnASFUpdate, 1, 0);
            this.tlpASF.Controls.Add(this.btnASFVersion, 2, 0);
            this.tlpASF.Location = new System.Drawing.Point(6, 19);
            this.tlpASF.Name = "tlpASF";
            this.tlpASF.RowCount = 1;
            this.tlpASF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpASF.Size = new System.Drawing.Size(406, 33);
            this.tlpASF.TabIndex = 0;
            // 
            // btnASFHelp
            // 
            this.btnASFHelp.Enabled = false;
            this.btnASFHelp.Location = new System.Drawing.Point(3, 3);
            this.btnASFHelp.Name = "btnASFHelp";
            this.btnASFHelp.Size = new System.Drawing.Size(129, 27);
            this.btnASFHelp.TabIndex = 0;
            this.btnASFHelp.Text = "Help";
            this.btnASFHelp.UseVisualStyleBackColor = true;
            this.btnASFHelp.Click += new System.EventHandler(this.btnASFHelp_Click);
            // 
            // btnASFUpdate
            // 
            this.btnASFUpdate.Enabled = false;
            this.btnASFUpdate.Location = new System.Drawing.Point(138, 3);
            this.btnASFUpdate.Name = "btnASFUpdate";
            this.btnASFUpdate.Size = new System.Drawing.Size(129, 27);
            this.btnASFUpdate.TabIndex = 1;
            this.btnASFUpdate.Text = "Update";
            this.btnASFUpdate.UseVisualStyleBackColor = true;
            this.btnASFUpdate.Click += new System.EventHandler(this.btnASFUpdate_Click);
            // 
            // btnASFVersion
            // 
            this.btnASFVersion.Enabled = false;
            this.btnASFVersion.Location = new System.Drawing.Point(273, 3);
            this.btnASFVersion.Name = "btnASFVersion";
            this.btnASFVersion.Size = new System.Drawing.Size(130, 27);
            this.btnASFVersion.TabIndex = 2;
            this.btnASFVersion.Text = "Version";
            this.btnASFVersion.UseVisualStyleBackColor = true;
            this.btnASFVersion.Click += new System.EventHandler(this.btnASFVersion_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.cmsTrayIcon;
            this.TrayIcon.Icon = global::ASFui.Properties.Resources.ASFui;
            this.TrayIcon.Text = "ASFui";
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // cmsTrayIcon
            // 
            this.cmsTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiClose});
            this.cmsTrayIcon.Name = "cmsTrayIcon";
            this.cmsTrayIcon.Size = new System.Drawing.Size(104, 48);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(103, 22);
            this.tsmiClose.Text = "Close";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslLastCommand,
            this.tsslCommandOutput});
            this.StatusStrip.Location = new System.Drawing.Point(0, 464);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(694, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 31;
            // 
            // tsslLastCommand
            // 
            this.tsslLastCommand.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslLastCommand.Name = "tsslLastCommand";
            this.tsslLastCommand.Size = new System.Drawing.Size(98, 17);
            this.tsslLastCommand.Text = "Last Command:";
            // 
            // tsslCommandOutput
            // 
            this.tsslCommandOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslCommandOutput.Name = "tsslCommandOutput";
            this.tsslCommandOutput.Size = new System.Drawing.Size(42, 17);
            this.tsslCommandOutput.Text = "None.";
            // 
            // ASFui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 486);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.gbASF);
            this.Controls.Add(this.gbChat);
            this.Controls.Add(this.gbKeys);
            this.Controls.Add(this.gbGames);
            this.Controls.Add(this.gb2FA);
            this.Controls.Add(this.gbCards);
            this.Controls.Add(this.gbBots);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.btnReloadBots);
            this.Controls.Add(this.lbCurrentBot);
            this.Controls.Add(this.cbBotList);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.rtbOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::ASFui.Properties.Resources.ASFui;
            this.MaximizeBox = false;
            this.Name = "ASFui";
            this.Text = "ASFui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ASFui_FormClosing);
            this.Resize += new System.EventHandler(this.ASFui_Resize);
            this.gbKeys.ResumeLayout(false);
            this.tlpKeys.ResumeLayout(false);
            this.gb2FA.ResumeLayout(false);
            this.tlp2FA.ResumeLayout(false);
            this.gbCards.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.gbBots.ResumeLayout(false);
            this.tlpBots.ResumeLayout(false);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbChat.ResumeLayout(false);
            this.tlpChat.ResumeLayout(false);
            this.gbGames.ResumeLayout(false);
            this.tlpGames.ResumeLayout(false);
            this.gbASF.ResumeLayout(false);
            this.tlpASF.ResumeLayout(false);
            this.cmsTrayIcon.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Diagnostics.Process ASFProcess;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbCurrentBot;
        protected System.Windows.Forms.ComboBox cbBotList;
        public System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnReloadBots;
        private System.Windows.Forms.GroupBox gbKeys;
        private System.Windows.Forms.TableLayoutPanel tlpKeys;
        private System.Windows.Forms.GroupBox gb2FA;
        private System.Windows.Forms.GroupBox gbCards;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private System.Windows.Forms.Button btnFarm;
        private System.Windows.Forms.Button btnLoot;
        private System.Windows.Forms.GroupBox gbBots;
        private System.Windows.Forms.TableLayoutPanel tlpBots;
        private System.Windows.Forms.Button btnStartBot;
        private System.Windows.Forms.Button btnStatusBot;
        private System.Windows.Forms.Button btnStatusAll;
        private System.Windows.Forms.Button btnStopBot;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnRedeem;
        private System.Windows.Forms.Button btnAddLicense;
        private System.Windows.Forms.TableLayoutPanel tlp2FA;
        private System.Windows.Forms.Button btn2FA;
        private System.Windows.Forms.Button btn2FAOk;
        private System.Windows.Forms.Button btn2FANo;
        private System.Windows.Forms.Button btn2FAOff;
        private System.Windows.Forms.GroupBox gbChat;
        private System.Windows.Forms.TableLayoutPanel tlpChat;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Button btnRejoin;
        private System.Windows.Forms.GroupBox gbGames;
        private System.Windows.Forms.TableLayoutPanel tlpGames;
        private System.Windows.Forms.Button btnOwns;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPauseBot;
        private System.Windows.Forms.GroupBox gbASF;
        private System.Windows.Forms.TableLayoutPanel tlpASF;
        private System.Windows.Forms.Button btnASFHelp;
        private System.Windows.Forms.Button btnASFUpdate;
        private System.Windows.Forms.Button btnASFVersion;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip cmsTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslLastCommand;
        private System.Windows.Forms.ToolStripStatusLabel tsslCommandOutput;
    }
}


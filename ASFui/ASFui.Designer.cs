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
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbBotList = new System.Windows.Forms.ComboBox();
            this.lbCurrentBot = new System.Windows.Forms.Label();
            this.btnReloadBots = new System.Windows.Forms.Button();
            this.gbKeys = new System.Windows.Forms.GroupBox();
            this.tlpKeys = new System.Windows.Forms.TableLayoutPanel();
            this.btnRedeemMenu = new CustomDropdownButton();
            this.cmsRedeem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRedeem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRedeemNF = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRedeemFF = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddLicense = new System.Windows.Forms.Button();
            this.gb2FA = new System.Windows.Forms.GroupBox();
            this.tlp2FA = new System.Windows.Forms.TableLayoutPanel();
            this.btn2FA = new System.Windows.Forms.Button();
            this.btn2FAOk = new System.Windows.Forms.Button();
            this.btn2FANo = new System.Windows.Forms.Button();
            this.gbCards = new System.Windows.Forms.GroupBox();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.btnFarm = new System.Windows.Forms.Button();
            this.btnLoot = new System.Windows.Forms.Button();
            this.btnLootAll = new System.Windows.Forms.Button();
            this.gbBots = new System.Windows.Forms.GroupBox();
            this.tlpBots = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartBot = new System.Windows.Forms.Button();
            this.btnStopBot = new System.Windows.Forms.Button();
            this.btnPauseBot = new System.Windows.Forms.Button();
            this.btnStatusAll = new System.Windows.Forms.Button();
            this.btnStatusBot = new System.Windows.Forms.Button();
            this.btnPasswordBot = new System.Windows.Forms.Button();
            this.btnResumeBot = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
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
            this.btnOwnAll = new System.Windows.Forms.Button();
            this.gbASF = new System.Windows.Forms.GroupBox();
            this.tlpASF = new System.Windows.Forms.TableLayoutPanel();
            this.btnASFHelp = new System.Windows.Forms.Button();
            this.btnASFUpdate = new System.Windows.Forms.Button();
            this.btnASFVersion = new System.Windows.Forms.Button();
            this.btnAPI = new System.Windows.Forms.Button();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnASFuiSettings = new System.Windows.Forms.Button();
            this.btnASFuiHelp = new System.Windows.Forms.Button();
            this.tlpMainContent = new System.Windows.Forms.TableLayoutPanel();
            this.ttDesc = new System.Windows.Forms.ToolTip(this.components);
            this.gbKeys.SuspendLayout();
            this.tlpKeys.SuspendLayout();
            this.cmsRedeem.SuspendLayout();
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
            this.tlpMainContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbOutput.Enabled = false;
            this.rtbOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.ForeColor = System.Drawing.Color.Black;
            this.rtbOutput.Location = new System.Drawing.Point(13, 362);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(730, 113);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            this.rtbOutput.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbOutput_LinkClicked);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(586, 481);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.ttDesc.SetToolTip(this.btnStop, "Stop ASF process.");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(505, 481);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.ttDesc.SetToolTip(this.btnStart, "Start ASFui and ASF process.");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(667, 481);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear Log";
            this.ttDesc.SetToolTip(this.btnClear, "Clear output log.");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // cbBotList
            // 
            this.cbBotList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbBotList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBotList.Enabled = false;
            this.cbBotList.FormattingEnabled = true;
            this.cbBotList.Location = new System.Drawing.Point(81, 481);
            this.cbBotList.Name = "cbBotList";
            this.cbBotList.Size = new System.Drawing.Size(121, 21);
            this.cbBotList.TabIndex = 5;
            this.ttDesc.SetToolTip(this.cbBotList, "Current bot.");
            // 
            // lbCurrentBot
            // 
            this.lbCurrentBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCurrentBot.AutoSize = true;
            this.lbCurrentBot.Location = new System.Drawing.Point(12, 486);
            this.lbCurrentBot.Name = "lbCurrentBot";
            this.lbCurrentBot.Size = new System.Drawing.Size(63, 13);
            this.lbCurrentBot.TabIndex = 6;
            this.lbCurrentBot.Text = "Current Bot:";
            // 
            // btnReloadBots
            // 
            this.btnReloadBots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReloadBots.BackgroundImage = global::ASFui.Properties.Resources.refresh;
            this.btnReloadBots.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReloadBots.Enabled = false;
            this.btnReloadBots.Location = new System.Drawing.Point(208, 480);
            this.btnReloadBots.Name = "btnReloadBots";
            this.btnReloadBots.Size = new System.Drawing.Size(23, 23);
            this.btnReloadBots.TabIndex = 6;
            this.ttDesc.SetToolTip(this.btnReloadBots, "Reload bot list.");
            this.btnReloadBots.UseVisualStyleBackColor = true;
            this.btnReloadBots.Click += new System.EventHandler(this.btnReloadBots_Click);
            // 
            // gbKeys
            // 
            this.gbKeys.Controls.Add(this.tlpKeys);
            this.gbKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbKeys.Location = new System.Drawing.Point(242, 3);
            this.gbKeys.Name = "gbKeys";
            this.gbKeys.Size = new System.Drawing.Size(234, 55);
            this.gbKeys.TabIndex = 27;
            this.gbKeys.TabStop = false;
            this.gbKeys.Text = "Keys";
            // 
            // tlpKeys
            // 
            this.tlpKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpKeys.ColumnCount = 2;
            this.tlpKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpKeys.Controls.Add(this.btnRedeemMenu, 0, 0);
            this.tlpKeys.Controls.Add(this.btnAddLicense, 1, 0);
            this.tlpKeys.Location = new System.Drawing.Point(6, 19);
            this.tlpKeys.Name = "tlpKeys";
            this.tlpKeys.RowCount = 1;
            this.tlpKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKeys.Size = new System.Drawing.Size(222, 33);
            this.tlpKeys.TabIndex = 1;
            // 
            // btnRedeemMenu
            // 
            this.btnRedeemMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRedeemMenu.Enabled = false;
            this.btnRedeemMenu.Location = new System.Drawing.Point(3, 3);
            this.btnRedeemMenu.Menu = this.cmsRedeem;
            this.btnRedeemMenu.Name = "btnRedeemMenu";
            this.btnRedeemMenu.Size = new System.Drawing.Size(105, 27);
            this.btnRedeemMenu.TabIndex = 35;
            this.btnRedeemMenu.Text = "Redeem";
            this.ttDesc.SetToolTip(this.btnRedeemMenu, "Open the redeem menu.");
            this.btnRedeemMenu.UseVisualStyleBackColor = true;
            // 
            // cmsRedeem
            // 
            this.cmsRedeem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRedeem,
            this.btnRedeemNF,
            this.btnRedeemFF});
            this.cmsRedeem.Name = "contextMenuStrip1";
            this.cmsRedeem.Size = new System.Drawing.Size(165, 70);
            // 
            // btnRedeem
            // 
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(164, 22);
            this.btnRedeem.Text = "Normal";
            this.btnRedeem.ToolTipText = "Redeems given cd-keys on given bot instance.";
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // btnRedeemNF
            // 
            this.btnRedeemNF.Name = "btnRedeemNF";
            this.btnRedeemNF.Size = new System.Drawing.Size(164, 22);
            this.btnRedeemNF.Text = "No forwarding";
            this.btnRedeemNF.ToolTipText = "Redeems given cd-keys on given bot instance,\r\nnever forwards keys to other bots.";
            this.btnRedeemNF.Click += new System.EventHandler(this.btnRedeemNF_Click);
            // 
            // btnRedeemFF
            // 
            this.btnRedeemFF.Name = "btnRedeemFF";
            this.btnRedeemFF.Size = new System.Drawing.Size(164, 22);
            this.btnRedeemFF.Text = "Force forwarding";
            this.btnRedeemFF.ToolTipText = "Redeems given cd-keys on any bot instance apart from given one.\r\nForce forwarding" +
    ".";
            this.btnRedeemFF.Click += new System.EventHandler(this.btnRedeemFF_Click);
            // 
            // btnAddLicense
            // 
            this.btnAddLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddLicense.Enabled = false;
            this.btnAddLicense.Location = new System.Drawing.Point(114, 3);
            this.btnAddLicense.Name = "btnAddLicense";
            this.btnAddLicense.Size = new System.Drawing.Size(105, 27);
            this.btnAddLicense.TabIndex = 1;
            this.btnAddLicense.Text = "License";
            this.ttDesc.SetToolTip(this.btnAddLicense, "Activates given appIDs on given bot instance (free games only).");
            this.btnAddLicense.UseVisualStyleBackColor = true;
            this.btnAddLicense.Click += new System.EventHandler(this.btnAddLicense_Click);
            // 
            // gb2FA
            // 
            this.gb2FA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb2FA.Controls.Add(this.tlp2FA);
            this.gb2FA.Location = new System.Drawing.Point(13, 298);
            this.gb2FA.Name = "gb2FA";
            this.gb2FA.Size = new System.Drawing.Size(730, 58);
            this.gb2FA.TabIndex = 26;
            this.gb2FA.TabStop = false;
            this.gb2FA.Text = "2FA";
            // 
            // tlp2FA
            // 
            this.tlp2FA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp2FA.ColumnCount = 3;
            this.tlp2FA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp2FA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp2FA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp2FA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp2FA.Controls.Add(this.btn2FA, 0, 0);
            this.tlp2FA.Controls.Add(this.btn2FAOk, 1, 0);
            this.tlp2FA.Controls.Add(this.btn2FANo, 2, 0);
            this.tlp2FA.Location = new System.Drawing.Point(6, 19);
            this.tlp2FA.Name = "tlp2FA";
            this.tlp2FA.RowCount = 1;
            this.tlp2FA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp2FA.Size = new System.Drawing.Size(718, 31);
            this.tlp2FA.TabIndex = 1;
            // 
            // btn2FA
            // 
            this.btn2FA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2FA.Enabled = false;
            this.btn2FA.Location = new System.Drawing.Point(3, 3);
            this.btn2FA.Name = "btn2FA";
            this.btn2FA.Size = new System.Drawing.Size(233, 25);
            this.btn2FA.TabIndex = 0;
            this.btn2FA.Text = "Generate Token";
            this.ttDesc.SetToolTip(this.btn2FA, "Generates temporary 2FA token for given bot instance.");
            this.btn2FA.UseVisualStyleBackColor = true;
            this.btn2FA.Click += new System.EventHandler(this.btn2FA_Click);
            // 
            // btn2FAOk
            // 
            this.btn2FAOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2FAOk.Enabled = false;
            this.btn2FAOk.Location = new System.Drawing.Point(242, 3);
            this.btn2FAOk.Name = "btn2FAOk";
            this.btn2FAOk.Size = new System.Drawing.Size(233, 25);
            this.btn2FAOk.TabIndex = 1;
            this.btn2FAOk.Text = "Accept Pending Confirmations";
            this.ttDesc.SetToolTip(this.btn2FAOk, "Accepts all pending 2FA confirmations for given bot instance.");
            this.btn2FAOk.UseVisualStyleBackColor = true;
            this.btn2FAOk.Click += new System.EventHandler(this.btn2FAOk_Click);
            // 
            // btn2FANo
            // 
            this.btn2FANo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2FANo.Enabled = false;
            this.btn2FANo.Location = new System.Drawing.Point(481, 3);
            this.btn2FANo.Name = "btn2FANo";
            this.btn2FANo.Size = new System.Drawing.Size(234, 25);
            this.btn2FANo.TabIndex = 2;
            this.btn2FANo.Text = "Deny Pending Confirmations";
            this.ttDesc.SetToolTip(this.btn2FANo, "Denies all pending 2FA confirmations for given bot instance.");
            this.btn2FANo.UseVisualStyleBackColor = true;
            this.btn2FANo.Click += new System.EventHandler(this.btn2FANo_Click);
            // 
            // gbCards
            // 
            this.gbCards.Controls.Add(this.tlpCards);
            this.gbCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCards.Location = new System.Drawing.Point(3, 3);
            this.gbCards.Name = "gbCards";
            this.gbCards.Size = new System.Drawing.Size(233, 55);
            this.gbCards.TabIndex = 24;
            this.gbCards.TabStop = false;
            this.gbCards.Text = "Cards";
            // 
            // tlpCards
            // 
            this.tlpCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCards.ColumnCount = 3;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.31332F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34334F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34334F));
            this.tlpCards.Controls.Add(this.btnFarm, 0, 0);
            this.tlpCards.Controls.Add(this.btnLoot, 1, 0);
            this.tlpCards.Controls.Add(this.btnLootAll, 2, 0);
            this.tlpCards.Location = new System.Drawing.Point(6, 19);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(221, 33);
            this.tlpCards.TabIndex = 0;
            // 
            // btnFarm
            // 
            this.btnFarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFarm.Enabled = false;
            this.btnFarm.Location = new System.Drawing.Point(3, 3);
            this.btnFarm.Name = "btnFarm";
            this.btnFarm.Size = new System.Drawing.Size(67, 27);
            this.btnFarm.TabIndex = 0;
            this.btnFarm.Text = "Farm";
            this.ttDesc.SetToolTip(this.btnFarm, "Restarts cards farming module for given bot instance.");
            this.btnFarm.UseVisualStyleBackColor = true;
            this.btnFarm.Click += new System.EventHandler(this.btnFarm_Click);
            // 
            // btnLoot
            // 
            this.btnLoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoot.Enabled = false;
            this.btnLoot.Location = new System.Drawing.Point(76, 3);
            this.btnLoot.Name = "btnLoot";
            this.btnLoot.Size = new System.Drawing.Size(67, 27);
            this.btnLoot.TabIndex = 1;
            this.btnLoot.Text = "Loot";
            this.ttDesc.SetToolTip(this.btnLoot, "Sends all booster packs and Steam trading cards\r\n(including foils if IsBotAccount" +
        ") of given\r\nbot instance to SteamMasterID.");
            this.btnLoot.UseVisualStyleBackColor = true;
            this.btnLoot.Click += new System.EventHandler(this.btnLoot_Click);
            // 
            // btnLootAll
            // 
            this.btnLootAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLootAll.Enabled = false;
            this.btnLootAll.Location = new System.Drawing.Point(149, 3);
            this.btnLootAll.Name = "btnLootAll";
            this.btnLootAll.Size = new System.Drawing.Size(69, 27);
            this.btnLootAll.TabIndex = 2;
            this.btnLootAll.Text = "Loot All";
            this.ttDesc.SetToolTip(this.btnLootAll, "Issues !loot on all currently enabled ASF bots.");
            this.btnLootAll.UseVisualStyleBackColor = true;
            this.btnLootAll.Click += new System.EventHandler(this.btnLootAll_Click);
            // 
            // gbBots
            // 
            this.gbBots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBots.Controls.Add(this.tlpBots);
            this.gbBots.Location = new System.Drawing.Point(264, 140);
            this.gbBots.Name = "gbBots";
            this.gbBots.Size = new System.Drawing.Size(478, 88);
            this.gbBots.TabIndex = 23;
            this.gbBots.TabStop = false;
            this.gbBots.Text = "Manage bots";
            // 
            // tlpBots
            // 
            this.tlpBots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpBots.ColumnCount = 4;
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBots.Controls.Add(this.btnStartBot, 0, 0);
            this.tlpBots.Controls.Add(this.btnStopBot, 1, 0);
            this.tlpBots.Controls.Add(this.btnPauseBot, 2, 0);
            this.tlpBots.Controls.Add(this.btnStatusAll, 3, 1);
            this.tlpBots.Controls.Add(this.btnStatusBot, 2, 1);
            this.tlpBots.Controls.Add(this.btnPasswordBot, 1, 1);
            this.tlpBots.Controls.Add(this.btnResumeBot, 3, 0);
            this.tlpBots.Controls.Add(this.btnStartAll, 0, 1);
            this.tlpBots.Location = new System.Drawing.Point(6, 19);
            this.tlpBots.Name = "tlpBots";
            this.tlpBots.RowCount = 2;
            this.tlpBots.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBots.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBots.Size = new System.Drawing.Size(466, 63);
            this.tlpBots.TabIndex = 0;
            // 
            // btnStartBot
            // 
            this.btnStartBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartBot.Enabled = false;
            this.btnStartBot.Location = new System.Drawing.Point(3, 3);
            this.btnStartBot.Name = "btnStartBot";
            this.btnStartBot.Size = new System.Drawing.Size(110, 25);
            this.btnStartBot.TabIndex = 0;
            this.btnStartBot.Text = "Start";
            this.ttDesc.SetToolTip(this.btnStartBot, "Starts given bot instance.");
            this.btnStartBot.UseVisualStyleBackColor = true;
            this.btnStartBot.Click += new System.EventHandler(this.btnStartBot_Click);
            // 
            // btnStopBot
            // 
            this.btnStopBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopBot.Enabled = false;
            this.btnStopBot.Location = new System.Drawing.Point(119, 3);
            this.btnStopBot.Name = "btnStopBot";
            this.btnStopBot.Size = new System.Drawing.Size(110, 25);
            this.btnStopBot.TabIndex = 1;
            this.btnStopBot.Text = "Stop";
            this.ttDesc.SetToolTip(this.btnStopBot, "Stops given bot instance.");
            this.btnStopBot.UseVisualStyleBackColor = true;
            this.btnStopBot.Click += new System.EventHandler(this.btnStopBot_Click);
            // 
            // btnPauseBot
            // 
            this.btnPauseBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPauseBot.Enabled = false;
            this.btnPauseBot.Location = new System.Drawing.Point(235, 3);
            this.btnPauseBot.Name = "btnPauseBot";
            this.btnPauseBot.Size = new System.Drawing.Size(110, 25);
            this.btnPauseBot.TabIndex = 2;
            this.btnPauseBot.Text = "Pause";
            this.ttDesc.SetToolTip(this.btnPauseBot, "Pauses automatic farming of given bot instance.");
            this.btnPauseBot.UseVisualStyleBackColor = true;
            this.btnPauseBot.Click += new System.EventHandler(this.btnPauseBot_Click);
            // 
            // btnStatusAll
            // 
            this.btnStatusAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatusAll.Enabled = false;
            this.btnStatusAll.Location = new System.Drawing.Point(351, 34);
            this.btnStatusAll.Name = "btnStatusAll";
            this.btnStatusAll.Size = new System.Drawing.Size(112, 26);
            this.btnStatusAll.TabIndex = 7;
            this.btnStatusAll.Text = "Status All";
            this.ttDesc.SetToolTip(this.btnStatusAll, "Prints status of all bot instances and ASF itself.");
            this.btnStatusAll.UseVisualStyleBackColor = true;
            this.btnStatusAll.Click += new System.EventHandler(this.btnStatusAll_Click);
            // 
            // btnStatusBot
            // 
            this.btnStatusBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatusBot.Enabled = false;
            this.btnStatusBot.Location = new System.Drawing.Point(235, 34);
            this.btnStatusBot.Name = "btnStatusBot";
            this.btnStatusBot.Size = new System.Drawing.Size(110, 26);
            this.btnStatusBot.TabIndex = 6;
            this.btnStatusBot.Text = "Status";
            this.ttDesc.SetToolTip(this.btnStatusBot, "Prints status of given bot instance.");
            this.btnStatusBot.UseVisualStyleBackColor = true;
            this.btnStatusBot.Click += new System.EventHandler(this.btnStatusBot_Click);
            // 
            // btnPasswordBot
            // 
            this.btnPasswordBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPasswordBot.Enabled = false;
            this.btnPasswordBot.Location = new System.Drawing.Point(119, 34);
            this.btnPasswordBot.Name = "btnPasswordBot";
            this.btnPasswordBot.Size = new System.Drawing.Size(110, 26);
            this.btnPasswordBot.TabIndex = 5;
            this.btnPasswordBot.Text = "Password";
            this.ttDesc.SetToolTip(this.btnPasswordBot, "Prints encrypted password of given\r\nbot instance (in use with PasswordFormat).");
            this.btnPasswordBot.UseVisualStyleBackColor = true;
            this.btnPasswordBot.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // btnResumeBot
            // 
            this.btnResumeBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResumeBot.Enabled = false;
            this.btnResumeBot.Location = new System.Drawing.Point(351, 3);
            this.btnResumeBot.Name = "btnResumeBot";
            this.btnResumeBot.Size = new System.Drawing.Size(112, 25);
            this.btnResumeBot.TabIndex = 3;
            this.btnResumeBot.Text = "Resume";
            this.ttDesc.SetToolTip(this.btnResumeBot, "Resumes automatic farming of given bot instance.");
            this.btnResumeBot.UseVisualStyleBackColor = true;
            this.btnResumeBot.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartAll.Enabled = false;
            this.btnStartAll.Location = new System.Drawing.Point(3, 34);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(110, 26);
            this.btnStartAll.TabIndex = 4;
            this.btnStartAll.Text = "Start All";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.tbInput);
            this.gbInput.Location = new System.Drawing.Point(12, 12);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(246, 280);
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
            this.tbInput.Size = new System.Drawing.Size(234, 252);
            this.tbInput.TabIndex = 6;
            // 
            // gbChat
            // 
            this.gbChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChat.Controls.Add(this.tlpChat);
            this.gbChat.Location = new System.Drawing.Point(242, 64);
            this.gbChat.Name = "gbChat";
            this.gbChat.Size = new System.Drawing.Size(234, 55);
            this.gbChat.TabIndex = 29;
            this.gbChat.TabStop = false;
            this.gbChat.Text = "Chat";
            // 
            // tlpChat
            // 
            this.tlpChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpChat.ColumnCount = 2;
            this.tlpChat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChat.Controls.Add(this.btnLeave, 0, 0);
            this.tlpChat.Controls.Add(this.btnRejoin, 1, 0);
            this.tlpChat.Location = new System.Drawing.Point(6, 19);
            this.tlpChat.Name = "tlpChat";
            this.tlpChat.RowCount = 1;
            this.tlpChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChat.Size = new System.Drawing.Size(222, 33);
            this.tlpChat.TabIndex = 1;
            // 
            // btnLeave
            // 
            this.btnLeave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeave.Enabled = false;
            this.btnLeave.Location = new System.Drawing.Point(3, 3);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(105, 27);
            this.btnLeave.TabIndex = 0;
            this.btnLeave.Text = "Leave Chat";
            this.ttDesc.SetToolTip(this.btnLeave, "Makes bot leave the current group chat.\r\nFor obvious reasons, this command works " +
        "only in group chats.");
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // btnRejoin
            // 
            this.btnRejoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRejoin.Enabled = false;
            this.btnRejoin.Location = new System.Drawing.Point(114, 3);
            this.btnRejoin.Name = "btnRejoin";
            this.btnRejoin.Size = new System.Drawing.Size(105, 27);
            this.btnRejoin.TabIndex = 1;
            this.btnRejoin.Text = "Rejoin Chat";
            this.ttDesc.SetToolTip(this.btnRejoin, "Forces all bots with unlimited accounts to rejoin the groupchat.");
            this.btnRejoin.UseVisualStyleBackColor = true;
            this.btnRejoin.Click += new System.EventHandler(this.btnRejoin_Click);
            // 
            // gbGames
            // 
            this.gbGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGames.Controls.Add(this.tlpGames);
            this.gbGames.Location = new System.Drawing.Point(3, 64);
            this.gbGames.Name = "gbGames";
            this.gbGames.Size = new System.Drawing.Size(233, 55);
            this.gbGames.TabIndex = 28;
            this.gbGames.TabStop = false;
            this.gbGames.Text = "Games";
            // 
            // tlpGames
            // 
            this.tlpGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGames.ColumnCount = 3;
            this.tlpGames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpGames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpGames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpGames.Controls.Add(this.btnOwns, 0, 0);
            this.tlpGames.Controls.Add(this.btnPlay, 2, 0);
            this.tlpGames.Controls.Add(this.btnOwnAll, 1, 0);
            this.tlpGames.Location = new System.Drawing.Point(6, 19);
            this.tlpGames.Name = "tlpGames";
            this.tlpGames.RowCount = 1;
            this.tlpGames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGames.Size = new System.Drawing.Size(224, 33);
            this.tlpGames.TabIndex = 0;
            // 
            // btnOwns
            // 
            this.btnOwns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOwns.Enabled = false;
            this.btnOwns.Location = new System.Drawing.Point(3, 3);
            this.btnOwns.Name = "btnOwns";
            this.btnOwns.Size = new System.Drawing.Size(68, 27);
            this.btnOwns.TabIndex = 0;
            this.btnOwns.Text = "Own";
            this.ttDesc.SetToolTip(this.btnOwns, "Checks if given bot instance already owns given appIDs\r\nand/or gameNames (can be " +
        "part of the game\'s name).");
            this.btnOwns.UseVisualStyleBackColor = true;
            this.btnOwns.Click += new System.EventHandler(this.btnOwns_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(151, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(70, 27);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.ttDesc.SetToolTip(this.btnPlay, "Switches to manual farming - launches given\r\nappIDs on given bot instance. Use !r" +
        "esume\r\nfor returning to automatic farming.");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnOwnAll
            // 
            this.btnOwnAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOwnAll.Enabled = false;
            this.btnOwnAll.Location = new System.Drawing.Point(77, 3);
            this.btnOwnAll.Name = "btnOwnAll";
            this.btnOwnAll.Size = new System.Drawing.Size(68, 27);
            this.btnOwnAll.TabIndex = 1;
            this.btnOwnAll.Text = "Own All";
            this.ttDesc.SetToolTip(this.btnOwnAll, "Checks all currently enabled ASF bots for owning given\r\nappIDs and/or gameNames (" +
        "can be part of the game\'s name).");
            this.btnOwnAll.UseVisualStyleBackColor = true;
            this.btnOwnAll.Click += new System.EventHandler(this.btnOwnAll_Click);
            // 
            // gbASF
            // 
            this.gbASF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbASF.Controls.Add(this.tlpASF);
            this.gbASF.Location = new System.Drawing.Point(264, 234);
            this.gbASF.Name = "gbASF";
            this.gbASF.Size = new System.Drawing.Size(478, 58);
            this.gbASF.TabIndex = 30;
            this.gbASF.TabStop = false;
            this.gbASF.Text = "ArchiSteamFarm";
            // 
            // tlpASF
            // 
            this.tlpASF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpASF.ColumnCount = 4;
            this.tlpASF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpASF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpASF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpASF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpASF.Controls.Add(this.btnASFHelp, 0, 0);
            this.tlpASF.Controls.Add(this.btnASFUpdate, 1, 0);
            this.tlpASF.Controls.Add(this.btnASFVersion, 2, 0);
            this.tlpASF.Controls.Add(this.btnAPI, 3, 0);
            this.tlpASF.Location = new System.Drawing.Point(6, 19);
            this.tlpASF.Name = "tlpASF";
            this.tlpASF.RowCount = 1;
            this.tlpASF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpASF.Size = new System.Drawing.Size(466, 33);
            this.tlpASF.TabIndex = 0;
            // 
            // btnASFHelp
            // 
            this.btnASFHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnASFHelp.Enabled = false;
            this.btnASFHelp.Location = new System.Drawing.Point(3, 3);
            this.btnASFHelp.Name = "btnASFHelp";
            this.btnASFHelp.Size = new System.Drawing.Size(110, 27);
            this.btnASFHelp.TabIndex = 0;
            this.btnASFHelp.Text = "Help";
            this.ttDesc.SetToolTip(this.btnASFHelp, "Shows help.");
            this.btnASFHelp.UseVisualStyleBackColor = true;
            this.btnASFHelp.Click += new System.EventHandler(this.btnASFHelp_Click);
            // 
            // btnASFUpdate
            // 
            this.btnASFUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnASFUpdate.Enabled = false;
            this.btnASFUpdate.Location = new System.Drawing.Point(119, 3);
            this.btnASFUpdate.Name = "btnASFUpdate";
            this.btnASFUpdate.Size = new System.Drawing.Size(110, 27);
            this.btnASFUpdate.TabIndex = 1;
            this.btnASFUpdate.Text = "Update";
            this.ttDesc.SetToolTip(this.btnASFUpdate, "Checks GitHub for ASF updates\r\n(this is done automatically every 24 hours if Auto" +
        "Updates).");
            this.btnASFUpdate.UseVisualStyleBackColor = true;
            this.btnASFUpdate.Click += new System.EventHandler(this.btnASFUpdate_Click);
            // 
            // btnASFVersion
            // 
            this.btnASFVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnASFVersion.Enabled = false;
            this.btnASFVersion.Location = new System.Drawing.Point(235, 3);
            this.btnASFVersion.Name = "btnASFVersion";
            this.btnASFVersion.Size = new System.Drawing.Size(110, 27);
            this.btnASFVersion.TabIndex = 2;
            this.btnASFVersion.Text = "Version";
            this.ttDesc.SetToolTip(this.btnASFVersion, "Prints version of ASF.");
            this.btnASFVersion.UseVisualStyleBackColor = true;
            this.btnASFVersion.Click += new System.EventHandler(this.btnASFVersion_Click);
            // 
            // btnAPI
            // 
            this.btnAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAPI.Enabled = false;
            this.btnAPI.Location = new System.Drawing.Point(351, 3);
            this.btnAPI.Name = "btnAPI";
            this.btnAPI.Size = new System.Drawing.Size(112, 27);
            this.btnAPI.TabIndex = 3;
            this.btnAPI.Text = "API";
            this.ttDesc.SetToolTip(this.btnAPI, "Returns ASF process status in JSON.");
            this.btnAPI.UseVisualStyleBackColor = true;
            this.btnAPI.Click += new System.EventHandler(this.btnAPI_Click);
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
            this.tsmiClose});
            this.cmsTrayIcon.Name = "cmsTrayIcon";
            this.cmsTrayIcon.Size = new System.Drawing.Size(104, 26);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(103, 22);
            this.tsmiClose.Text = "Close";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // btnASFuiSettings
            // 
            this.btnASFuiSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnASFuiSettings.BackgroundImage = global::ASFui.Properties.Resources.settings;
            this.btnASFuiSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnASFuiSettings.Location = new System.Drawing.Point(476, 481);
            this.btnASFuiSettings.Name = "btnASFuiSettings";
            this.btnASFuiSettings.Size = new System.Drawing.Size(23, 23);
            this.btnASFuiSettings.TabIndex = 3;
            this.ttDesc.SetToolTip(this.btnASFuiSettings, "ASFui settings.");
            this.btnASFuiSettings.UseVisualStyleBackColor = true;
            this.btnASFuiSettings.Click += new System.EventHandler(this.btnASFuiSettings_Click);
            // 
            // btnASFuiHelp
            // 
            this.btnASFuiHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnASFuiHelp.BackgroundImage = global::ASFui.Properties.Resources.help;
            this.btnASFuiHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnASFuiHelp.Location = new System.Drawing.Point(447, 481);
            this.btnASFuiHelp.Name = "btnASFuiHelp";
            this.btnASFuiHelp.Size = new System.Drawing.Size(23, 23);
            this.btnASFuiHelp.TabIndex = 4;
            this.ttDesc.SetToolTip(this.btnASFuiHelp, "Open ASFui wiki.");
            this.btnASFuiHelp.UseVisualStyleBackColor = true;
            this.btnASFuiHelp.Click += new System.EventHandler(this.btnASFuiHelp_Click);
            // 
            // tlpMainContent
            // 
            this.tlpMainContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMainContent.ColumnCount = 2;
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainContent.Controls.Add(this.gbChat, 1, 1);
            this.tlpMainContent.Controls.Add(this.gbCards, 0, 0);
            this.tlpMainContent.Controls.Add(this.gbGames, 0, 1);
            this.tlpMainContent.Controls.Add(this.gbKeys, 1, 0);
            this.tlpMainContent.Location = new System.Drawing.Point(264, 12);
            this.tlpMainContent.Name = "tlpMainContent";
            this.tlpMainContent.RowCount = 2;
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainContent.Size = new System.Drawing.Size(479, 122);
            this.tlpMainContent.TabIndex = 34;
            // 
            // ASFui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 516);
            this.Controls.Add(this.tlpMainContent);
            this.Controls.Add(this.btnASFuiHelp);
            this.Controls.Add(this.btnASFuiSettings);
            this.Controls.Add(this.gbASF);
            this.Controls.Add(this.gb2FA);
            this.Controls.Add(this.gbBots);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.btnReloadBots);
            this.Controls.Add(this.lbCurrentBot);
            this.Controls.Add(this.cbBotList);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.rtbOutput);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ASFui.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = global::ASFui.Properties.Resources.ASFui;
            this.Location = global::ASFui.Properties.Settings.Default.Location;
            this.MinimumSize = new System.Drawing.Size(770, 555);
            this.Name = "ASFui";
            this.Text = "ASFui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ASFui_FormClosing);
            this.Load += new System.EventHandler(this.ASFui_Load);
            this.Resize += new System.EventHandler(this.ASFui_Resize);
            this.gbKeys.ResumeLayout(false);
            this.tlpKeys.ResumeLayout(false);
            this.cmsRedeem.ResumeLayout(false);
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
            this.tlpMainContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbCurrentBot;
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
        private System.Windows.Forms.Button btnStopBot;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.TableLayoutPanel tlp2FA;
        private System.Windows.Forms.Button btn2FA;
        private System.Windows.Forms.Button btn2FAOk;
        private System.Windows.Forms.Button btn2FANo;
        private System.Windows.Forms.GroupBox gbChat;
        private System.Windows.Forms.TableLayoutPanel tlpChat;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Button btnRejoin;
        private System.Windows.Forms.GroupBox gbGames;
        private System.Windows.Forms.TableLayoutPanel tlpGames;
        private System.Windows.Forms.Button btnOwns;
        private System.Windows.Forms.GroupBox gbASF;
        private System.Windows.Forms.TableLayoutPanel tlpASF;
        private System.Windows.Forms.Button btnASFHelp;
        private System.Windows.Forms.Button btnASFUpdate;
        private System.Windows.Forms.Button btnASFVersion;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip cmsTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.Button btnASFuiSettings;
        private System.Windows.Forms.Button btnAPI;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ComboBox cbBotList;
        private System.Windows.Forms.Button btnLootAll;
        private System.Windows.Forms.Button btnPasswordBot;
        private System.Windows.Forms.Button btnASFuiHelp;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TableLayoutPanel tlpMainContent;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnOwnAll;
        public System.Windows.Forms.TextBox tbInput;
        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolTip ttDesc;
        private System.Windows.Forms.Button btnPauseBot;
        private System.Windows.Forms.Button btnStatusAll;
        private System.Windows.Forms.Button btnStatusBot;
        private System.Windows.Forms.Button btnResumeBot;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnAddLicense;
        private System.Windows.Forms.ContextMenuStrip cmsRedeem;
        private System.Windows.Forms.ToolStripMenuItem btnRedeem;
        private System.Windows.Forms.ToolStripMenuItem btnRedeemNF;
        private System.Windows.Forms.ToolStripMenuItem btnRedeemFF;
        private CustomDropdownButton btnRedeemMenu;
    }
}


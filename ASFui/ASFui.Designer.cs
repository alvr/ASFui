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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASFui));
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ASFProcess = new System.Diagnostics.Process();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.CbBotList = new System.Windows.Forms.ComboBox();
            this.lbCurrentBot = new System.Windows.Forms.Label();
            this.btnReloadBots = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.ForeColor = System.Drawing.Color.Black;
            this.rtbOutput.Location = new System.Drawing.Point(12, 278);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(660, 100);
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
            this.btnStop.Location = new System.Drawing.Point(516, 384);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(435, 384);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(597, 384);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear Log...";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // CbBotList
            // 
            this.CbBotList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbBotList.FormattingEnabled = true;
            this.CbBotList.Location = new System.Drawing.Point(81, 384);
            this.CbBotList.Name = "CbBotList";
            this.CbBotList.Size = new System.Drawing.Size(121, 21);
            this.CbBotList.TabIndex = 4;
            // 
            // lbCurrentBot
            // 
            this.lbCurrentBot.AutoSize = true;
            this.lbCurrentBot.Location = new System.Drawing.Point(12, 389);
            this.lbCurrentBot.Name = "lbCurrentBot";
            this.lbCurrentBot.Size = new System.Drawing.Size(63, 13);
            this.lbCurrentBot.TabIndex = 6;
            this.lbCurrentBot.Text = "Current Bot:";
            // 
            // btnReloadBots
            // 
            this.btnReloadBots.Location = new System.Drawing.Point(208, 383);
            this.btnReloadBots.Name = "btnReloadBots";
            this.btnReloadBots.Size = new System.Drawing.Size(23, 23);
            this.btnReloadBots.TabIndex = 7;
            this.btnReloadBots.Text = "🔃";
            this.btnReloadBots.UseVisualStyleBackColor = true;
            this.btnReloadBots.Click += new System.EventHandler(this.btnReloadBots_Click);
            // 
            // ASFui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 419);
            this.Controls.Add(this.btnReloadBots);
            this.Controls.Add(this.lbCurrentBot);
            this.Controls.Add(this.CbBotList);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.rtbOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ASFui";
            this.Text = "ASFui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ASFui_FormClosing);
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
        protected System.Windows.Forms.ComboBox CbBotList;
        public System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnReloadBots;
    }
}


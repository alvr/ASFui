using System.IO;
using System.Windows.Forms;

namespace ASFui
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdBinarySearch = new System.Windows.Forms.OpenFileDialog();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbBinaryPath = new System.Windows.Forms.GroupBox();
            this.lbPath = new System.Windows.Forms.Label();
            this.gbLocalRemote = new System.Windows.Forms.GroupBox();
            this.tbRemoteURL = new System.Windows.Forms.TextBox();
            this.rbRemote = new System.Windows.Forms.RadioButton();
            this.rbLocal = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbSaved = new System.Windows.Forms.Label();
            this.gbBinaryPath.SuspendLayout();
            this.gbLocalRemote.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdBinarySearch
            // 
            this.ofdBinarySearch.DefaultExt = "exe";
            this.ofdBinarySearch.Filter = "Executable|*.exe";
            this.ofdBinarySearch.Title = "Search for ASF binary";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(350, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbBinaryPath
            // 
            this.gbBinaryPath.Controls.Add(this.lbPath);
            this.gbBinaryPath.Controls.Add(this.btnSearch);
            this.gbBinaryPath.Location = new System.Drawing.Point(12, 12);
            this.gbBinaryPath.Name = "gbBinaryPath";
            this.gbBinaryPath.Size = new System.Drawing.Size(431, 48);
            this.gbBinaryPath.TabIndex = 2;
            this.gbBinaryPath.TabStop = false;
            this.gbBinaryPath.Text = "ASF binary";
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(6, 24);
            this.lbPath.MaximumSize = new System.Drawing.Size(335, 0);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(114, 13);
            this.lbPath.TabIndex = 0;
            this.lbPath.Text = "Setting not configured.";
            // 
            // gbLocalRemote
            // 
            this.gbLocalRemote.Controls.Add(this.tbRemoteURL);
            this.gbLocalRemote.Controls.Add(this.rbRemote);
            this.gbLocalRemote.Controls.Add(this.rbLocal);
            this.gbLocalRemote.Location = new System.Drawing.Point(12, 66);
            this.gbLocalRemote.Name = "gbLocalRemote";
            this.gbLocalRemote.Size = new System.Drawing.Size(431, 48);
            this.gbLocalRemote.TabIndex = 3;
            this.gbLocalRemote.TabStop = false;
            this.gbLocalRemote.Text = "Local or Remote";
            // 
            // tbRemoteURL
            // 
            this.tbRemoteURL.Enabled = false;
            this.tbRemoteURL.Location = new System.Drawing.Point(135, 19);
            this.tbRemoteURL.Name = "tbRemoteURL";
            this.tbRemoteURL.Size = new System.Drawing.Size(290, 20);
            this.tbRemoteURL.TabIndex = 2;
            // 
            // rbRemote
            // 
            this.rbRemote.AutoSize = true;
            this.rbRemote.Location = new System.Drawing.Point(66, 20);
            this.rbRemote.Name = "rbRemote";
            this.rbRemote.Size = new System.Drawing.Size(62, 17);
            this.rbRemote.TabIndex = 1;
            this.rbRemote.Text = "Remote";
            this.rbRemote.UseVisualStyleBackColor = true;
            this.rbRemote.CheckedChanged += new System.EventHandler(this.rbRemote_CheckedChanged);
            // 
            // rbLocal
            // 
            this.rbLocal.AutoSize = true;
            this.rbLocal.Checked = true;
            this.rbLocal.Location = new System.Drawing.Point(9, 20);
            this.rbLocal.Name = "rbLocal";
            this.rbLocal.Size = new System.Drawing.Size(51, 17);
            this.rbLocal.TabIndex = 0;
            this.rbLocal.TabStop = true;
            this.rbLocal.Text = "Local";
            this.rbLocal.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(368, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbSaved
            // 
            this.lbSaved.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSaved.Location = new System.Drawing.Point(262, 120);
            this.lbSaved.Name = "lbSaved";
            this.lbSaved.Size = new System.Drawing.Size(100, 23);
            this.lbSaved.TabIndex = 5;
            this.lbSaved.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 155);
            this.Controls.Add(this.lbSaved);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbLocalRemote);
            this.Controls.Add(this.gbBinaryPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::ASFui.Properties.Resources.ASFui;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "ASFui - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.gbBinaryPath.ResumeLayout(false);
            this.gbBinaryPath.PerformLayout();
            this.gbLocalRemote.ResumeLayout(false);
            this.gbLocalRemote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdBinarySearch;
        private System.Windows.Forms.Button btnSearch;
        private GroupBox gbBinaryPath;
        private Label lbPath;
        private GroupBox gbLocalRemote;
        private RadioButton rbRemote;
        private RadioButton rbLocal;
        private Button btnSave;
        private TextBox tbRemoteURL;
        private Label lbSaved;
    }
}
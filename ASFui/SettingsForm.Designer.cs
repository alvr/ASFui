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
            this.gbBinaryPath.SuspendLayout();
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
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(114, 13);
            this.lbPath.TabIndex = 0;
            this.lbPath.Text = "Setting not configured.";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 77);
            this.Controls.Add(this.gbBinaryPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::ASFui.Properties.Resources.ASFui;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "ASFui - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.gbBinaryPath.ResumeLayout(false);
            this.gbBinaryPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdBinarySearch;
        private System.Windows.Forms.Button btnSearch;
        private GroupBox gbBinaryPath;
        private Label lbPath;
    }
}
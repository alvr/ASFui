using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace ASFui
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ASFProcess
    {
        private readonly ASFui _asf;
        private Process ASF;
        private readonly RichTextBox output;
        private string key;
        private bool ASF_ended;
 
        public ASFProcess(ASFui asf, RichTextBox rtb)
        {
            _asf = asf;
            ASF = new Process();
            output = rtb;

            init();
        }

        private void init() {
            var ASFInfo = new ProcessStartInfo() {
                Arguments = "--server",
                CreateNoWindow = true,
                Domain = "",
                FileName = Properties.Settings.Default.ASFBinary,
                LoadUserProfile = false,
                Password = null,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            ASF.StartInfo = ASFInfo;
            ASF.OutputDataReceived += OutputHandler;

            ASF.EnableRaisingEvents = true;

            ASF.Exited += new EventHandler(ASFExit);
        }

        private void ASFExit(object sender, System.EventArgs e) {
            if (ASF_ended) {
                return;
            }
            ASF_ended = true;
            output.Invoke(new MethodInvoker(() => {
                output.Clear();
                output.AppendText("Restarted." + Environment.NewLine);
            }));
            ASF = new Process();
            init();
            Start();
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (ASF_ended || e== null || sender ==null || e.Data ==null) {
                return;
            }
            if (e.Data.EndsWith("\"android:\"):") || e.Data.EndsWith("login:") ||
                e.Data.EndsWith("+1234567890):") || e.Data.EndsWith("mobile:") ||
                e.Data.EndsWith("email:") || e.Data.EndsWith("PIN:") ||
                e.Data.EndsWith("app:") || e.Data.EndsWith("hostname:"))
            {
                var result = Interaction.InputBox(e.Data, @"Enter necessary input");
                ASF.StandardInput.WriteLine(result);
                ASF.StandardInput.Flush();
            }

            if ((!e.Data.StartsWith("[AES]") ^ e.Data.StartsWith("[ProtectedDataForCurrentUser]")) && e.Data.EndsWith("password:"))
            {
                var Password = new Password(ASF, e.Data);
                Password.ShowDialog();
            }

            if (key != string.Empty)
            {
                if (e.Data.Contains("OK") && Properties.Settings.Default.ClearOk)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }

                else if (e.Data.Contains("DuplicatedKey") && Properties.Settings.Default.ClearDuplicated)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }

                else if (e.Data.Contains("InvalidKey") && Properties.Settings.Default.ClearInvalid)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }

                else if (e.Data.Contains("AlreadyOwned") && Properties.Settings.Default.ClearOwned)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }

                else if (e.Data.Contains("OnCooldown") && Properties.Settings.Default.ClearCooldown)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }
            }

            output.Invoke(new MethodInvoker(() =>
            {
                key = Regex.Match(e.Data.ToString(), @"[0-9A-Z]{5}-[0-9A-Z]{5}-[0-9A-Z]{5}", RegexOptions.IgnoreCase).Value;
                output.AppendText(e.Data + Environment.NewLine);
                output.ScrollToCaret();
            }));
        }

        public void Start()
        {
            ASF_ended = false;
            ASF.Start();
            ASF.BeginOutputReadLine();
        }

        public void Stop()
        {
            ASF_ended = true;
            if (ASF == null)
            {
                return;
            }
            if (ASF.HasExited)
            {
                ASF.Close();
            }
            else
            {
                ASF.Kill();
            }

            ASF = null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ASFui
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ASFProcess
    {
        private readonly ASFui _asf;
        private Process ASF;
        private readonly RichTextBox output;
        private string key;
 
        public ASFProcess(ASFui asf, RichTextBox rtb)
        {
            _asf = asf;
            ASF = new Process();
            output = rtb;

            var ASFInfo = new ProcessStartInfo()
            {
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
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
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

            if (e.Data.Contains("Update process finished!"))
            {
                _asf.btnStop.Invoke(new MethodInvoker(() => _asf.btnStop.PerformClick()));
                Task.Delay(1500).ContinueWith(t => _asf.btnStart.Invoke(new MethodInvoker(() => _asf.btnStart.PerformClick())));
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

            if (e.Data.Contains("Init() Success!"))
            {
                _asf.GetBotList();
            }

            if (e.Data.Contains("OnDisconnected() Disconnected from Steam!"))
            {
                _asf.GetBotList();
            }

            output.Invoke(new MethodInvoker(() =>
            {
                output.AppendText(e.Data + Environment.NewLine);
                output.ScrollToCaret();
            }));
        }

        public void Start()
        {
            ASF.Start();
            ASF.BeginOutputReadLine();
        }

        public void Stop()
        {
            ASF.CancelOutputRead();

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

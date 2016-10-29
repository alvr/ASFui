using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        private Thread outputThread;
        private readonly StringBuilder sb = new StringBuilder();
        private bool loaded;
        private string key;
        private volatile bool closeOutput;

        public ASFProcess(ASFui asf, RichTextBox rtb)
        {
            _asf = asf;
            ASF = new Process();
            output = rtb;
            closeOutput = false;

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
        }

        private void PrintOutput()
        {
            try
            {
                int s;
                while ((s = ASF.StandardOutput.Read()) != 0 || !closeOutput || ASF != null)
                {
                    MethodInvoker mi = delegate
                    {
                        key = Regex.Match(sb.ToString(), @"[0-9A-Z]{5}-[0-9A-Z]{5}-[0-9A-Z]{5}", RegexOptions.IgnoreCase).Value;
                        output.AppendText(sb.ToString());
                        Check();
                        output.SelectionStart = output.Text.Length;
                        output.ScrollToCaret();
                        sb.Clear();
                    };

                    try
                    {
                        sb.Append(Convert.ToChar(s));
                    }
                    catch (OverflowException e)
                    {
                        Logging.Exception(e, "Output too long.");
                        sb.Clear();
                    }

                    if (s == '\n')
                    {
                        output.Invoke(mi);
                    }

                    if (sb.ToString().EndsWith("\"android:\"):") || sb.ToString().EndsWith("login:") ||
                        sb.ToString().EndsWith("+1234567890):") || sb.ToString().EndsWith("mobile:") ||
                        sb.ToString().EndsWith("email:") || sb.ToString().EndsWith("PIN:") ||
                        sb.ToString().EndsWith("app:") || sb.ToString().EndsWith("hostname:"))
                    {
                        output.AppendText(sb + " ");
                        var result = Interaction.InputBox(sb.ToString(), @"Enter necessary input");
                        ASF.StandardInput.WriteLine(result);
                        ASF.StandardInput.Flush();
                        output.AppendText(result + Environment.NewLine + sb);
                        sb.Clear();
                    }

                    else if ((!sb.ToString().StartsWith("[AES]") ^ sb.ToString().StartsWith("[ProtectedDataForCurrentUser]"))
                        && sb.ToString().EndsWith("password:"))
                    {
                        var Password = new Password(ASF, sb.ToString());
                        Password.ShowDialog();
                    }

                    else if (sb.ToString().EndsWith("running, exiting"))
                    {
                        sb.Clear();
                        _asf.btnStop.Invoke(new MethodInvoker(delegate { _asf.btnStop.PerformClick(); }));
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Logging.Exception(e, "Error reading ASF output.");
                sb.Clear();
                _asf.btnStop.Invoke(new MethodInvoker(delegate { _asf.btnStop.PerformClick(); }));
            }
        }

        private void Check()
        {
            if (sb.ToString().Contains("Update process finished!"))
            {
                _asf.btnStop.PerformClick();
                Task.Delay(1500).ContinueWith(t => _asf.btnStart.PerformClick());
            }

            if (key != "")
            {
                if (sb.ToString().Contains("OK") && Properties.Settings.Default.ClearOk)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }

                else if (sb.ToString().Contains("DuplicatedKey") && Properties.Settings.Default.ClearDuplicated)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }

                else if (sb.ToString().Contains("InvalidKey") && Properties.Settings.Default.ClearInvalid)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }

                else if (sb.ToString().Contains("AlreadyOwned") && Properties.Settings.Default.ClearOwned)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }

                else if (sb.ToString().Contains("OnCooldown") && Properties.Settings.Default.ClearCooldown)
                {
                    _asf.tbInput.Lines = _asf.tbInput.Lines.ToList().Except(new List<string> { key }).ToArray();
                }
            }

            if (!sb.ToString().Contains("Init() Success!") || loaded) return;
            _asf.GetBotList();
            loaded = true;
        }

        public void Start()
        {
            ASF.Start();
            outputThread = new Thread(PrintOutput);
            outputThread.Start();
        }

        public void Stop()
        {
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

            closeOutput = true;
            ASF = null;
        }

    }
}

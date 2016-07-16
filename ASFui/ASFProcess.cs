using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ASFui
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ASFProcess
    {
        private Process ASF;
        private readonly RichTextBox output;
        private Thread outputThread;

        public ASFProcess(RichTextBox rtb)
        {
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
        }

        private void PrintOutput()
        {
            var sb = new StringBuilder();
            int s;
            while ((s = ASF.StandardOutput.Read()) != 0)
            {
                MethodInvoker mi1 = delegate 
                {
                    output.AppendText(sb.ToString());
                    output.SelectionStart = output.Text.Length;
                    output.ScrollToCaret();
                    sb.Clear();
                };

                sb.Append(Convert.ToChar(s));
                if(s == '\n')
                {
                    output.Invoke(mi1);
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
                    output.AppendText(result + Environment.NewLine);
                    sb.Clear();
                }
                else if(sb.ToString().EndsWith("password:"))
                {
                    var Password = new Password(ASF, sb.ToString());
                    Password.ShowDialog();
                    sb.Clear();
                }
            }
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

            outputThread.Abort();
            ASF = null;
        }
    }
}

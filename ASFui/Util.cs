using System;
using ASFui.Properties;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Windows.Forms;

namespace ASFui
{
    internal static class Util
    {
        public static bool CheckBinary()
        {
            return File.Exists(Settings.Default.ASFBinary) || !Settings.Default.IsLocal;
        }

        public static string SendCommand(string command)
        {
            var binding = new BasicHttpBinding {SendTimeout = new TimeSpan(0, 30, 0)};
            var asfClient = new Client(binding, new EndpointAddress(GetEndpointAddress()));

            return asfClient.HandleCommand(command);
        }

        public static string GenerateCommand(string command, string user, string args = "")
        {
            return command + " " + user + " " + args;
        }

        public static string MultiToOne(string[] text)
        {
            string command = null;
            text = text.Where(x => !string.IsNullOrEmpty(x) && !string.IsNullOrWhiteSpace(x)).ToArray();
            command += string.Join(",", text);

            return command;
        }

        private static string GetEndpointAddress()
        {
            if (!Settings.Default.IsLocal) return Settings.Default.RemoteURL;
            var json =
                JObject.Parse(
                    File.ReadAllText(Path.GetDirectoryName(Settings.Default.ASFBinary) + @"/config/ASF.json"));
            var hostname = json["WCFHostname"].ToString();
            var port = json["WCFPort"].ToString();

            return "http://" + hostname + ":" + port + "/ASF";
        }

        public static bool CheckIfAsfIsRunning()
        {
            return Process.GetProcessesByName("ASF").Length > 0 ||
                   Process.GetProcessesByName("ArchiSteamFarm").Length > 0 ||
                   Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Settings.Default.ASFBinary)).Length > 0;
        }

        public static void CheckVersion()
        {
            string currentVersion;
            using (var web = new WebClient())
            {
                currentVersion =
                    web.DownloadString("https://raw.githubusercontent.com/alvr/ASFui/master/version.txt");
            }

            if (new Version(Application.ProductVersion).CompareTo(new Version(currentVersion)) >= 0) return;
            var option = MessageBox.Show(@"A new version (" + currentVersion + @") is available, download now?",
                @"New version", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (option == DialogResult.Yes)
            {
                Process.Start("https://github.com/alvr/ASFui/releases/latest");
            }
        }

    }
}
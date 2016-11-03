using System;
using ASFui.Properties;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace ASFui
{
    internal static class Util
    {
        private static readonly BasicHttpBinding Binding = new BasicHttpBinding {SendTimeout = new TimeSpan(0, 30, 0)};

        public static bool CheckBinary()
        {
            return File.Exists(Settings.Default.ASFBinary) || !Settings.Default.IsLocal;
        }

        public static string SendCommand(string command)
        {
            using (var asfClient = new Client(Binding, new EndpointAddress(GetEndpointAddress())))
            {
                return asfClient.HandleCommand(command);
            }
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
		
		public static void UpgradeSettings()
		{
            if (!Settings.Default.UpdateSettings) return;
            Settings.Default.Upgrade();
            Settings.Default.UpdateSettings = false;
            Settings.Default.Save();
            Logging.Info("ASFui updated to " + new Version(Application.ProductVersion));
        }

        public static bool IsOnScreen(Rectangle rec, double minPercentOnScreen = 0.2)
        {
            var pixelsVisible = Screen.AllScreens.Select(scrn => Rectangle.Intersect(rec, scrn.WorkingArea))
                .Where(r => r.Width != 0 & r.Height != 0)
                .Aggregate<Rectangle, double>(0, (current, r) => current + (r.Width*r.Height));

            return pixelsVisible >= (rec.Width * rec.Height) * minPercentOnScreen;
        }

        public static bool CheckUrl(string url)
        {
            try
            {
                var client = new MetadataExchangeClient(new Uri(url), MetadataExchangeClientMode.HttpGet);
                client.GetMetadata();
                return true;
            }
            catch (Exception ex)
            {
                Logging.Exception(ex, "Invalid remote URL.");
                return false;
            }
        }
    }
}
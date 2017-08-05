using System;
using ASFui.Properties;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace ASFui
{
    internal static class Util
    {
        public static bool CheckBinary()
        {
            return File.Exists(Settings.Default.ASFBinary) || !Settings.Default.IsLocal;
        }

        public static string After(this string source, string find, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var index = source.IndexOf(find, comparisonType);
            if (index < 0 || index + find.Length >= source.Length)
                return String.Empty;

            return source.Substring(index + find.Length);
        }


        public static string BeforeLast(this string source, string find, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var index = source.LastIndexOf(find, comparisonType);
            if (index >= 0)
                return source.Substring(0, index);

            return String.Empty;
        }


        public static string SendCommand(string command)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(GetEndpointAddress() + command).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            // This is still wrapped in html.
            return result.After("</head><body><p>", StringComparison.OrdinalIgnoreCase).BeforeLast("</p></body></html>", StringComparison.OrdinalIgnoreCase).Trim();
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

        public static string GetEndpointAddress()
        {
            if (!Settings.Default.IsLocal) return Settings.Default.RemoteURL;
            var json =
                JObject.Parse(
                    File.ReadAllText(Path.GetDirectoryName(Settings.Default.ASFBinary) + @"/config/ASF.json"));

            var hostname= "127.0.0.1";
            var port = "1242";
            try
            {
                hostname = json["IPCHost"].ToString();
            }
            catch
            {
                /* Ignore */
            }
            try {
                port = json["IPCPort"].ToString();
            } catch { /* Ignore */ }

            return "http://" + hostname + ":" + port + "/IPC?command=";
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

            return url.ToLower().StartsWith("http://");
        }
    }
}
using System;
using ASFui.Properties;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace ASFui
{
    internal static class Util
    {
        public static bool CheckBinary()
        {
            return File.Exists(Settings.Default.ASFBinary);
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
            var json = JObject.Parse(File.ReadAllText(Path.GetDirectoryName(Settings.Default.ASFBinary) + @"/config/ASF.json"));
            var hostname = json["WCFHostname"].ToString();
            var port = json["WCFPort"].ToString();

            return "http://" + hostname + ":" + port + "/ASF";
        }

        public static bool CheckIfAsfIsRunning()
        {
            return Process.GetProcessesByName("ASF").Length > 0 ||
                   Process.GetProcessesByName("ArchiSteamFarm").Length > 0 ||
                   Process.GetProcessesByName(Settings.Default.ASFBinary).Length > 0;
        }
    }
}
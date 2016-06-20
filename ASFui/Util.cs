using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace ASFui
{
    class Util
    {
        private static Client ASFClient;

        public static bool CheckBinary()
        {
            return File.Exists(Properties.Settings.Default.ASFBinary);
        }

        public static string SendCommand(string Command)
        {
            if (ASFClient == null)
            {
                ASFClient = new Client(new BasicHttpBinding(), new EndpointAddress(GetEndpointAddress()));
            }

            return ASFClient.HandleCommand(Command);
        }

        public static string GenerateCommand(string Command, string User, string Args = "")
        {
            return Command + " " + User + " " + Args;
        }

        public static string MultiToOne(string[] Text)
        {
            string Command = null;
            Text = Text.Where(x => !String.IsNullOrEmpty(x) && !String.IsNullOrWhiteSpace(x)).ToArray();
            Command += String.Join(",", Text);

            return Command;
        }

        private static string GetEndpointAddress()
        {
            JObject Json = JObject.Parse(File.ReadAllText(@"config/ASF.json"));
            string Hostname = Json["WCFHostname"].ToString();
            string Port = Json["WCFPort"].ToString();

            return "http://" + Hostname + ":" + Port + "/ASF";
        }

        public static bool CheckIfASFIsRunning()
        {
            return Process.GetProcessesByName("ASF").Length > 0 || Process.GetProcessesByName("ArchiSteamFarm").Length > 0;
        }
    }
}

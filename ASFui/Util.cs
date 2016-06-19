using System;
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
            return File.Exists("ASF.exe");
        }

        public static string SendCommand(string Command)
        {
            if (ASFClient == null)
            {
                ASFClient = new Client(new BasicHttpBinding(), new EndpointAddress("http://localhost:1242/ASF"));
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
    }
}

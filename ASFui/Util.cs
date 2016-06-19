using System.IO;
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
    }
}

using System;
using System.IO;
using NLog;

namespace ASFui
{
    internal class Logging
    {
        private static readonly Logger Logger = LogManager.GetLogger("ASFuiLog");
        private static readonly Logger LoggerEx = LogManager.GetLogger("ASFuiLogEx");

        public static void Error(string message)
        {
            Logger.Error(message);
        }

        public static void Exception(Exception e, string message)
        {
            LoggerEx.Error(e, message);
        }

        public static void Info(string message)
        {
            Logger.Info(message);
        }
    }
}

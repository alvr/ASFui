using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ASFui
{
    // Copied from:
    // https://github.com/JustArchi/ArchiSteamFarm/blob/master/ArchiSteamFarm/WCF.cs

    [ServiceContract]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal interface IWCF
    {
        [OperationContract]
        string HandleCommand(string input);
    }

    internal sealed class Client : ClientBase<IWCF>, IWCF
    {
        internal Client(Binding binding, EndpointAddress address) : base(binding, address) { }

        public string HandleCommand(string input)
        {
            try 
            {
                var info = Channel.HandleCommand(input);
                Logging.Info(input + ": " + info);
                return info;
            }
            catch(Exception e)
            {
                Logging.Exception(e, "Error sending command: " + input);
                return null;
            }
        }
    }
}

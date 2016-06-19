using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ASFui
{
    // Copied from:
    // https://github.com/JustArchi/ArchiSteamFarm/blob/master/ArchiSteamFarm/WCF.cs

    [ServiceContract]
    interface IWCF
    {
        [OperationContract]
        string HandleCommand(string input);
    }

    internal sealed class Client : ClientBase<IWCF>, IWCF
    {
        internal Client(Binding binding, EndpointAddress address) : base(binding, address) { }

        public string HandleCommand(string input)
        {
            return Channel.HandleCommand(input);
        }
    }
}

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ASFui
{
    [ServiceContract]
    internal interface IClient
    {
        [OperationContract]
        string HandleCommand(string input);
    }

    internal sealed class Client : ClientBase<IClient>, IClient
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

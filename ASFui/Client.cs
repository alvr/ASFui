using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ASFui
{
    [ServiceContract]
    interface IWCF
    {
        [OperationContract]
        string HandleCommand(string input);
    }
    class Client : ClientBase<IWCF>, IWCF
    {
        internal Client(Binding binding, EndpointAddress address) : base(binding, address) { }

        public string HandleCommand(string input)
        {
            try
            {
                return Channel.HandleCommand(input);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

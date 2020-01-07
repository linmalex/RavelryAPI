using System;

namespace RavelryAPI
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct) ]
    public class EndpointAttribute : Attribute
    {
        private string endpoint;
        public double version;

        public EndpointAttribute(string endpoint)
        {
            this.endpoint = endpoint;
        }
    }
}

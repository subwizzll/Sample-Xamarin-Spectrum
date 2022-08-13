using System.Net.Http;

namespace Sample.Core.Framework.Attributes.Http
{
    public class HttpAttributeInfo
    {
        public HttpAttributeInfo(string endpoint, HttpMethod method)
        {
            Endpoint = endpoint;
            Method = method;
        }
        
        public string Endpoint { get; set; }
        public HttpMethod Method { get; set; }
    }
}
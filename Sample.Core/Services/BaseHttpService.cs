using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sample.Core.Framework;
using Sample.Core.Framework.Attributes.Http;

namespace Sample.Core.Services
{
    public class BaseHttpService
    {
        public HttpClient Client { get; set; }
        protected (string name, string value) AuthorizationHeader { get; set; }
        protected string ContentType { get; set; }
        
        protected async Task<HttpRequestMessage> CreateRequestMessage([CallerMemberName] string callerMemberName = "", params object[] args)
        {
            var method = GetType().GetMethod(callerMemberName);
            var methodParameters = method.GetParameters();
            var attributeInfo = method.GetHttpAttributeInfo();
            var requestParameters = await SetRequestParameters(attributeInfo.Endpoint, methodParameters, args);
            var requestUri = $"{Client.BaseAddress}{requestParameters.endpoint}";
            var request = new HttpRequestMessage(attributeInfo.Method, requestUri);
            
            if(!string.IsNullOrWhiteSpace(requestParameters.requestContent))
                request.Content = new StringContent(requestParameters.requestContent, System.Text.Encoding.UTF8, ContentType);
            
            request.AddHeader(AuthorizationHeader);
            
            return request;
        }
        
        async Task<(string endpoint, string requestContent)> SetRequestParameters(string oldEndpoint, ParameterInfo[] parameterInfo, params object[] args)
        {
            var newEndpoint = oldEndpoint;
            var content = string.Empty;
            for (var i = 0; i < args.Length; i++)
            {
                var parameterName = $"{{{parameterInfo[i].Name}}}";
                if (oldEndpoint.Contains(parameterName))
                    newEndpoint = oldEndpoint.Replace(parameterName, args[i].ToString());
                var parameterHasBodyAttribute = parameterInfo[i].CustomAttributes.Any(x => x.AttributeType == typeof(BodyAttribute));
                if (parameterHasBodyAttribute)
                    content = JsonConvert.SerializeObject(args[i]);
            }

            return (newEndpoint, content);
        }
    }
}
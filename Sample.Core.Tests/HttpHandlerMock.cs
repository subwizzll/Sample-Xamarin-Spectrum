using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Tests
{
    public class HttpHandlerMock : HttpMessageHandler
    {
        public HttpStatusCode StatusCode { get; set; }
        public StringContent Content { get; set; }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var result = new HttpResponseMessage
            {
                Content = Content,
                StatusCode = StatusCode
            };

            return result;
        }
    }
}
using System.Net.Http;

namespace Sample.Core.Framework
{
    public static partial class Extensions
    {
        public static void AddHeader(this HttpRequestMessage instance, (string, string) headerKeyValuePair)
            => instance.Headers.Add(headerKeyValuePair.Item1, headerKeyValuePair.Item2);
    }
}
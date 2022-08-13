using Newtonsoft.Json;

namespace Sample.Core.Models.TaxJar.Orders
{
    public class NexusAddress
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("zip")]
        public string Zip { get; set; }
    }
}
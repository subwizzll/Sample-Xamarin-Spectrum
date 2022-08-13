using Newtonsoft.Json;

namespace Sample.Core.Models.TaxJar.Orders
{
    public class Order
    {
        [JsonProperty("to_city")]
        public string ToCity { get; set; }
        [JsonProperty("to_state")]
        public string ToState { get; set; }
        [JsonProperty("to_zip")]
        public string ToZip { get; set; }
        [JsonProperty("to_country")]
        public string ToCountry { get; set; }
        [JsonProperty("from_city")]
        public string FromCity { get; set; }
        [JsonProperty("from_state")]
        public string FromState { get; set; }
        [JsonProperty("from_zip")]
        public string FromZip { get; set; }
        [JsonProperty("from_country")]
        public string FromCountry { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("shipping")]
        public double Shipping { get; set; }
        [JsonProperty("line_items")]
        public LineItem[] LineItems { get; set; }
        [JsonProperty("nexus_addresses")]
        public NexusAddress[] NexusAddresses { get; set; }
    }
}
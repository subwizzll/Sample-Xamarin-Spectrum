using Newtonsoft.Json;

namespace Sample.Core.Models.TaxJar.Taxes
{
    public class Jurisdictions
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
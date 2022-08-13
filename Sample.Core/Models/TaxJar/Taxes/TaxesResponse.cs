// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using Newtonsoft.Json;

namespace Sample.Core.Models.TaxJar.Taxes
{

    public class TaxesResponse
    {
        [JsonProperty("tax")]
        public Tax Tax { get; set; }
    }
}
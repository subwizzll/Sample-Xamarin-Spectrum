using Newtonsoft.Json;

namespace Sample.Core.Models.TaxJar.Taxes
{
    public class Tax
    {
        [JsonProperty("amount_to_collect")]
        public double AmountToCollect { get; set; }
        [JsonProperty("breakdown")]
        public Breakdown Breakdown { get; set; }
        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }
        [JsonProperty("has_nexus")]
        public bool HasNexus { get; set; }
        [JsonProperty("jurisdictions")]
        public Jurisdictions Jurisdictions { get; set; }
        [JsonProperty("order_total_amount")]
        public double OrderTotalAmount { get; set; }
        [JsonProperty("rate")]
        public double Rate { get; set; }
        [JsonProperty("shipping")]
        public double Shipping { get; set; }
        [JsonProperty("tax_source")]
        public string TaxSource { get; set; }
        [JsonProperty("taxable_amount")]
        public double TaxableAmount { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sample.Core.Models.TaxJar.Taxes
{
    public class Breakdown
    {
        [JsonProperty("city_tax_collectable")]
        public double CityTaxCollectable { get; set; }
        [JsonProperty("city_tax_rate")]
        public double CityTaxRate { get; set; }
        [JsonProperty("city_taxable_amount")]
        public double CityTaxableAmount { get; set; }
        [JsonProperty("combined_tax_rate")]
        public double CombinedTaxRate { get; set; }
        [JsonProperty("county_tax_collectable")]
        public double CountyTaxCollectable { get; set; }
        [JsonProperty("county_tax_rate")]
        public double CountyTaxRate { get; set; }
        [JsonProperty("county_taxable_amount")]
        public double CountyTaxableAmount { get; set; }
        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }
        [JsonProperty("special_district_tax_collectable")]
        public double SpecialDistrictTaxCollectable { get; set; }
        [JsonProperty("special_district_taxable_amount")]
        public double SpecialDistrictTaxableAmount { get; set; }
        [JsonProperty("special_tax_rate")]
        public double SpecialTaxRate { get; set; }
        [JsonProperty("state_tax_collectable")]
        public double StateTaxCollectable { get; set; }
        [JsonProperty("state_tax_rate")]
        public double StateTaxRate { get; set; }
        [JsonProperty("state_taxable_amount")]
        public double StateTaxableAmount { get; set; }
        [JsonProperty("tax_collectable")]
        public double TaxCollectable { get; set; }
        [JsonProperty("taxable_amount")]
        public double TaxableAmount { get; set; }
    }
}
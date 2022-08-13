using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sample.Core.Data;
using Sample.Core.Framework.Attributes;
using Sample.Core.Framework.Attributes.Http;
using Sample.Core.Models.TaxJar.Orders;
using Sample.Core.Models.TaxJar.Rates;
using Sample.Core.Models.TaxJar.Taxes;

namespace Sample.Core.Services
{
    public interface ITaxService
    {
        public Task<RatesResponse> GetTaxRate(string zip);
        public Task<TaxesResponse> CalculateTaxes(Order order);
    }
    
    public class TaxService : BaseHttpService, ITaxService
    {
        public TaxService()
        {
            Client = new HttpClient();
            ContentType = "application/json";
            Client.BaseAddress = Constants.TaxRateApi.BaseAddress;
            AuthorizationHeader = ("Authorization", $"Token token=\"{Constants.TaxRateApi.PublicKey}\"");
        }
        
        [Get("v2/rates/{zip}")]
        public async Task<RatesResponse> GetTaxRate(string zip)
        {
            var request = await CreateRequestMessage(args: zip);
            var response = await Client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
                return null;
    
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RatesResponse>(jsonContent);
            return result;
        }

        [Post("v2/taxes")]
        public async Task<TaxesResponse> CalculateTaxes([Body] Order order)
        {
            var request = await CreateRequestMessage(args: order);
            var response = await Client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
                return null;
    
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TaxesResponse>(jsonContent);
            return result;
        }
    }
}
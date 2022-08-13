using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sample.Core.Data;
using Sample.Core.Models.TaxJar.Orders;
using Sample.Core.Models.TaxJar.Rates;
using Sample.Core.Models.TaxJar.Taxes;
using Sample.Core.Services;
using Xunit;

namespace Sample.Core.Tests.Services
{
    public class TaxServiceTests
    {
        readonly HttpHandlerMock _httpHandlerMock = new();
        readonly HttpClient _httpClientMock;
        readonly TaxService _taxService;

        public TaxServiceTests()
        {
            _httpClientMock = new(_httpHandlerMock) { BaseAddress = Constants.TaxRateApi.BaseAddress };
            _taxService = new() { Client = _httpClientMock };
        }
        
        [Fact]
        public async Task GetTaxRate_ShouldReturnTaxesResponse_WhenStatusCode_Is_200()
        {
            // Arrange
            var testZip = "55555";
            var expectedResult = new RatesResponse();
            _httpHandlerMock.StatusCode = (HttpStatusCode)200;
            _httpHandlerMock.Content = new StringContent(JsonConvert.SerializeObject(new TaxesResponse()));

            // Act
            var testResult = await _taxService.GetTaxRate(testZip);
            
            // Assert
            Assert.NotNull(testResult);
            Assert.Equal(testResult.Rate, expectedResult.Rate);
            Assert.IsType<RatesResponse>(testResult);
        }
        
        [Fact]
        public async Task GetTaxRate_ShouldReturnNull_WhenStatusCode_Is_400()
        {
            // Arrange
            var testZip = "55555";
            _httpHandlerMock.StatusCode = (HttpStatusCode)400;
            _httpHandlerMock.Content = new StringContent(JsonConvert.SerializeObject(new TaxesResponse()));

            // Act
            var testResult = await _taxService.GetTaxRate(testZip);
            
            // Assert
            Assert.Null(testResult);
        }
        
        [Fact]
        public async Task CalculateTaxes_ShouldReturnTaxesResponse_WhenStatusCode_Is_200()
        {
            // Arrange
            var testOrder = new Order();
            var expectedResult = new TaxesResponse();
            _httpHandlerMock.StatusCode = (HttpStatusCode)200;
            _httpHandlerMock.Content = new StringContent(JsonConvert.SerializeObject(new TaxesResponse()));

            // Act
            var testResult = await _taxService.CalculateTaxes(testOrder);
            
            // Assert
            Assert.NotNull(testResult);
            Assert.Equal(testResult.Tax, expectedResult.Tax);
            Assert.IsType<TaxesResponse>(testResult);
        }
        
        [Fact]
        public async Task CalculateTaxes_ShouldReturnNull_WhenStatusCode_Is_400()
        {
            // Arrange
            var testOrder = new Order();
            _httpHandlerMock.StatusCode = (HttpStatusCode)400;
            _httpHandlerMock.Content = new StringContent(JsonConvert.SerializeObject(new TaxesResponse()));

            // Act
            var testResult = await _taxService.CalculateTaxes(testOrder);
            
            // Assert
            Assert.Null(testResult);
        }
    }
}
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AssistAPurchase.AssistAPurchase.DataBase;
using AssistAPurchase.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace AssistAPurchase.Integration.Tests
{
    public class ProductConfigureControllerIntegrationTest
    {
        private readonly TestContext _sut;
        private static string url = "https://localhost:5001/api/ProductConfigure";
        public ProductConfigureControllerIntegrationTest()
        {
            _sut = new TestContext();
        }
       readonly MonitoringProductsGetter _productsDatabase = new MonitoringProductsGetter();

        [Fact]
        public async Task WhenViewProductsByThenCheckDatabaseCountWithRenderedProductsCount()
        {
            var response = await _sut.Client.GetAsync(url + "/getAllProducts");
            response.EnsureSuccessStatusCode();
            Assert.Equal(17, _productsDatabase.Products.Count);
        }



        [Fact]
        public async Task WhenValidProductNumberIsGivenThenCheckTheProductName()
        {
            var response = await _sut.Client.GetAsync(url + "/X3");
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("IntelliVue", responseString);
        }


        [Fact]
        public async Task WhenInValidProductNumberIsGivenThenCheckTheResponseNotFound()
        {
            var response = await _sut.Client.GetAsync(url + "/X999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task WhenDataBodyIsPostedEmptyThenCheckResponseBadRequest()
        {
            var response = await _sut.Client.PostAsync(url + "/X3",
                    new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            
        }

        [Fact]
        public async Task WhenDeleteRequestIsSentThenResponseOk()
        {
            var response = await _sut.Client.DeleteAsync(url + "/X3");
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task WhenDeleteRequestIsSentToDifferentUrlThenResponseOk()
        {
            var response = await _sut.Client.DeleteAsync(url + "/X99");
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task WhenDeleteRequestIsSentThenResponseNotFound()
        {
            var response = await _sut.Client.DeleteAsync(url + "/X900");
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task WhenNewDataIsUpdatedThenCheckTheResponseNoContent()
        {

            var updateProducts = new MonitoringItems()
            {
                ProductName = "InelVue",
                ProductNumber = "MX40"

            };
            var response = await _sut.Client.PutAsync(url + "/MX40",
                new StringContent(JsonConvert.SerializeObject(updateProducts), Encoding.UTF8, "application/json"));
            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task WhenNewDataIsUpdatedWithADifferentNumberThenCheckTheResponseBadRequest()
        {

            var products = new MonitoringItems()
            {
                ProductName = "InelVue",
                ProductNumber = "MX480"

            };
            var response = await _sut.Client.PutAsync(url + "/MX40",
                   new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json"));
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task WhenDataContainsEmptyBodyThenCheckTheResponseBadRequest()
        {
            var response = await _sut.Client.PutAsync(url + "/MX40",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task WhenExpectedDataIsNotPresentThenCheckTheResponseNotFound()
        {
            var modifyProducts = new MonitoringItems()
            {
                ProductName = "Inetkhvg",
                ProductNumber = "MX480"

            };
            var response = await _sut.Client.PutAsync(url + "/MX480",
                   new StringContent(JsonConvert.SerializeObject(modifyProducts), Encoding.UTF8, "application/json"));
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task WhenNewDataToBeCreatedThenCheckResponse()
        {
            var createProduct = new MonitoringItems()
            {
                ProductNumber = "X3",
                ProductName = "IntelliVue",
                Description = "The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive SmartPhone-style operation and offering a scalable set of clinical measurements.",
                ProductSpecficTraining = "NO",
                Price = "14500",
                Wearable = "NO",
                SoftwareUpdateSupport = "YES",
                Portability = "YES",
                Compact = "YES",
                BatterySupport = "NO",
                ThirdPartyDeviceSupport = "YES",
                SafeToFlyCertification = "NO",
                TouchScreenSupport = "YES",
                ScreenSize = "6.1",
                MultiPatientSupport = "NO",
                CyberSecurity = "NO"
            };
            var response = await _sut.Client.PostAsync(url + "/X5",
                new StringContent(JsonConvert.SerializeObject(createProduct), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }
    }

}


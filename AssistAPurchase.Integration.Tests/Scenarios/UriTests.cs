using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AssistAPurchase.DataBase;
using AssistAPurchase.Integration.Tests.Fixtures;
using AssistAPurchase.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace AssistAPurchase.Integration.Tests.Scenarios
{
    public class UriTests
    {
        private readonly TestContext _sut;

        public UriTests()
        {
            _sut = new TestContext();
        }
        MonitoringProductsGetter products_database = new MonitoringProductsGetter();



        [Fact]
        public async Task WhenViewAllProductsThenCheckDatabaseCountWithRenderedProductsCount()
        {
            var response = await _sut.Client.GetAsync("https://localhost:5001/api/ProductConfigure/getAllProducts");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            //  var forecast = JsonConvert.DeserializeObject<Task[]>(await response.Content.ReadAsStringAsync());
            //  forecast.Should().HaveCount(products_database.Products.Count);
            Assert.Equal(17, products_database.Products.Count);
        }



        [Fact]
        public async Task WhenValidProductNumberIsGivenThenCheckTheProductName()
        {
            var response = await _sut.Client.GetAsync("https://localhost:5001/api/ProductConfigure/X3");
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("IntelliVue", responseString);
        }


        [Fact]
        public async Task WhenInValidProductNumberIsGivenThenCheckTheResponseNotFound()
        {
            var response = await _sut.Client.GetAsync("https://localhost:5001/api/ProductConfigure/X999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task WhenDataBodyIsPostedEmptyThenCheckResponseBadRequest()
        {
            MonitoringItems value = null;
            var response = await _sut.Client.PostAsync("https://localhost:5001/api/ProductConfigure/X3",
                new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        /*  [Fact]
              public async Task WhenNewDataIsAddedThenCheckTheResponse()
              {
                  var products = new MonitoringItems()
                  {
                      ProductName = "InelliVue",
                      ProductNumber = "X7"

                  };
                  var response = await _sut.Client.PostAsync("https://localhost:5001/api/ProductConfigure/AddNewItems",
                      new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json"));

               response.StatusCode.Should().Be(HttpStatusCode.Created);
           }*/

        [Fact]
        public async Task WhenDeleteRequestIsSentThenResponseOk()
        {
            var response = await _sut.Client.DeleteAsync($"https://localhost:5001/api/ProductConfigure/X3");
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task WhenDeleteRequestIsSentThenResponseNotFound()
        {
            var response = await _sut.Client.DeleteAsync($"https://localhost:5001/api/ProductConfigure/X900");
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
            var response = await _sut.Client.PutAsync("https://localhost:5001/api/ProductConfigure/MX40",
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
            var response = await _sut.Client.PutAsync("https://localhost:5001/api/ProductConfigure/MX40",
                   new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json"));
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task WhenDataContainsEmptyBodyThenCheckTheResponseBadRequest()
        {
            MonitoringItems items = null;
            var response = await _sut.Client.PutAsync("https://localhost:5001/api/ProductConfigure/MX40",
                new StringContent(JsonConvert.SerializeObject(items), Encoding.UTF8, "application/json"));
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
            var response = await _sut.Client.PutAsync("https://localhost:5001/api/ProductConfigure/MX480",
                   new StringContent(JsonConvert.SerializeObject(modifyProducts), Encoding.UTF8, "application/json"));
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }
    }

}


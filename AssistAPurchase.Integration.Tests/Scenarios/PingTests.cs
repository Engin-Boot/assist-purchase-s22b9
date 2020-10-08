using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AssistAPurchase.DataBase;
using AssistAPurchase.Integration.Tests.Fixtures;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace AssistAPurchase.Integration.Tests.Scenarios
{
    public class PingTests
    {
        private readonly TestContext _sut;

        public PingTests()
        {
            _sut = new TestContext();
        }

        [Fact]
        public async Task WhenUserNavigatesThroughAllProductsURIThenCheckDatabaseCountWithRenderedProductsCount()
        {
            var response = await _sut.Client.GetAsync("https://localhost:5001/api/ProductConfigure/getAllProducts");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var products_database = new MonitoringProductsGetter();
            var forecast = JsonConvert.DeserializeObject<Task[]>(await response.Content.ReadAsStringAsync());
            forecast.Should().HaveCount(products_database.Products.Count);
        }

        [Fact]
        public async Task WhenValidProductNumberIsGivenThenCheckTheProductName()
        {
            var response = await _sut.Client.GetAsync("https://localhost:5001/api/ProductConfigure/X3");
            //    response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            //  var products_database = new MonitoringProductsGetter();
            Assert.Contains("IntelliVue", responseString);
        }


        //  [Fact]
        /*   public async Task WhenInValidProductNumberIsGivenThenCheckTheResponse()
           {
               var response = await _sut.Client.GetAsync("https://localhost:5001/api/ProductConfigure/X999");
               //    response.EnsureSuccessStatusCode();
   
               response.EnsureSuccessStatusCode();
   
               response.StatusCode.Should().Be(HttpStatusCode.NotFound);
               //  var products_database = new MonitoringProductsGetter();
   
           }
        
          [Fact]
           public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
           {
               var postRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/api/ProductConfigure/X999");
               var formModel = new Dictionary<string, string>
               {
                   { "ProductNumber","X999" },
                   { "ProductName", "X9" }
               };
               postRequest.Content = new FormUrlEncodedContent(formModel);
               var response = await _sut.Client.SendAsync(postRequest);
               response.EnsureSuccessStatusCode();
               response.StatusCode.Should().Be(HttpStatusCode.OK);
               /*   var responseString = await response.Content.ReadAsStringAsync();
                  Assert.Contains("Account number is required", responseString);
    }
    */

}

    }


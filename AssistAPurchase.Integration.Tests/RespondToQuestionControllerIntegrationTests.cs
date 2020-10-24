using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AssistAPurchase.AssistAPurchase.DataBase;
using AssistAPurchase.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace AssistAPurchase.Integration.Tests
{
  public  class RespondToQuestionControllerIntegrationTests
    {
        private readonly TestContext _sut;
        static string _url = "https://localhost:5001/api/RespondToQuestions/MonitoringProductHomePage";
        
        public RespondToQuestionControllerIntegrationTests()
        {
            _sut = new TestContext();
        }
        readonly MonitoringProductsGetter _productsDatabase = new MonitoringProductsGetter();

        [Fact]
        public async Task WhenUsersFilterByCategory()
        {
            var url = "http://localhost:5001/api/RespondToQuestions/MonitoringProduct";
            var product = new MonitoringItems
            {
                ProductSpecficTraining = "NO",
                Price = "16900",
                Wearable = "NO",
                SoftwareUpdateSupport = "YES",
                Portability = "YES",
                Compact = "YES",
                BatterySupport = "NO",
                ThirdPartyDeviceSupport = "YES",
                SafeToFlyCertification = "NO",
                TouchScreenSupport = "YES",
                ScreenSize = "6",
                MultiPatientSupport = "NO",
                CyberSecurity = "NO"
            };
            var response = await _sut.Client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task WhenUsersFilterByOneCategory()
        {
            var url = "http://localhost:5001/api/RespondToQuestions/MonitoringProduct";
            var productList = new List<MonitoringItems>
            {
                new MonitoringItems { ProductSpecficTraining = "NO" },
                new MonitoringItems { Wearable = "NO" },
                new MonitoringItems { SoftwareUpdateSupport = "NO" },
                new MonitoringItems { Portability = "NO" },
                new MonitoringItems { Compact = "NO" },
                new MonitoringItems { BatterySupport = "NO" },
                new MonitoringItems { ThirdPartyDeviceSupport = "NO" },
                new MonitoringItems { SafeToFlyCertification = "NO" },
                new MonitoringItems { TouchScreenSupport = "NO" },
                new MonitoringItems { MultiPatientSupport = "NO" },
                new MonitoringItems { CyberSecurity = "NO" },
                new MonitoringItems { Price = "10000" },
                new MonitoringItems { ScreenSize = "5" },
                new MonitoringItems { ProductName = "IntelliVue" }
            };
            foreach (var product in productList)
            {
                var response = await _sut.Client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task WhenUsersViewAllProductsThenCheckDatabaseCountWithRenderedProductsCount()
        {
            var response = await _sut.Client.GetAsync(_url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(17, _productsDatabase.Products.Count);
        }

        [Fact]
        public async Task WhenUsersNeedDescriptionThenCheckDescriptionOfProductRendered()
        {
            var response = await _sut.Client.GetAsync(_url + "/Description/X3");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive smartphone-style operation and offering a scalable set of clinical measurements.",
                responseString);
        }

        [Theory] 
        [InlineData("/Compact/YES", 12)]
        [InlineData("/Compact/NO", 5)]
        [InlineData("/ProductSpecificTraining/YES", 9)]
        [InlineData("/ProductSpecificTraining/NO", 8)]
        [InlineData("/Price/1000/ABOVE", 17)]
        [InlineData("/Price/1000/BELOW", 0)]
        [InlineData("/Price/70000/ABOVE", 0)]
        [InlineData("/Price/35000/BELOW", 6)]
        [InlineData("/Wearable/YES",4)]
        [InlineData("/Wearable/NO",13)]
        [InlineData("/SoftwareUpdateSupport/YES", 8)]
        [InlineData("/SoftwareUpdateSupport/NO", 9)]
        [InlineData("/Portability/YES", 12)]
        [InlineData("/Portability/NO", 5)]
        [InlineData("/BatterySupport/YES",5)]
        [InlineData("/BatterySupport/NO",12)]
        [InlineData("/ThirdPartyDeviceSupport/YES", 9)]
        [InlineData("/ThirdPartyDeviceSupport/NO", 8)]
        [InlineData("/SafeToFlyCertification/YES", 4)]
        [InlineData("/SafeToFlyCertification/NO", 13)]
        [InlineData("/TouchScreenSupport/YES", 17)]
        [InlineData("/TouchScreenSupport/NO", 0)]
        [InlineData("/ScreenSize/10/ABOVE",8)]
        [InlineData("/ScreenSize/20/ABOVE",0)]
        [InlineData("/ScreenSize/3/BELOW",1)]
        [InlineData("/MultiPatientSupport/YES",4)]
        [InlineData("/MultiPatientSupport/NO",13)]
        [InlineData("/CyberSecurity/YES",1)]
        [InlineData("/CyberSecurity/NO",16)]

        public async Task WhenUsersViewProductsWithCategoryThenCheckDatabaseCountWithRenderedProductsCount(string value1, int expected)
        {
            var response = await _sut.Client.GetAsync(_url + value1);
            response.EnsureSuccessStatusCode();
            var forecast = JsonConvert.DeserializeObject<Task[]>(await response.Content.ReadAsStringAsync());
            forecast.Should().HaveCount(expected);
        }

        [Fact]
        public async Task WhenUsersViewAllProductsThenCheckConnectionIsOk()
        {
            var response = await _sut.Client.GetAsync(_url);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task WhenProductNumberIsNullThenCheckDescriptionNotDisplayed()
        {
            var response = await _sut.Client.GetAsync(_url + "/Description/null");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}

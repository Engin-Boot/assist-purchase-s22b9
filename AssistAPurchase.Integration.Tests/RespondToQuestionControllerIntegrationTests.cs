using System.Net;
using System.Threading.Tasks;
using AssistAPurchase.DataBase;
using AssistAPurchase.Integration.Tests.Fixtures;
using AssistAPurchase.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace AssistAPurchase.Integration.Tests.Scenarios
{
  public  class RespondToQuestionControllerIntegrationTests
    {
        private readonly TestContext _sut;
        static string url = "https://localhost:5001/api/RespondToQuestions/MonitoringProductHomePage";
        
        public RespondToQuestionControllerIntegrationTests()
        {
            _sut = new TestContext();
        }
        MonitoringProductsGetter products_database = new MonitoringProductsGetter();
        private MonitoringItems monitoring = new MonitoringItems();

        [Fact]
        public async Task WhenUsersViewAllProductsThenCheckDatabaseCountWithRenderedProductsCount()
        {
            var response = await _sut.Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(17, products_database.Products.Count);
        }

        [Fact]
        public async Task WhenUsersNeedDescriptionThenCheckDescriptionOfProductRendered()
        {
            var response = await _sut.Client.GetAsync(url + "/Description/X3");
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
            var response = await _sut.Client.GetAsync(url + value1);
            response.EnsureSuccessStatusCode();
            var forecast = JsonConvert.DeserializeObject<Task[]>(await response.Content.ReadAsStringAsync());
            forecast.Should().HaveCount(expected);
        }

        [Fact]
        public async Task WhenUsersViewAllProductsThenCheckConnectionIsOk()
        {
            var response = await _sut.Client.GetAsync(url);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}

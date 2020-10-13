using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AssistAPurchase.Integration.Tests.Fixtures;
using AssistAPurchase.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace AssistAPurchase.Integration.Tests.Scenarios
{
   public class AlertControllerIntegrationTests
    {
        private readonly TestContext _sut;
        static string url = "https://localhost:5001/api/Alert";

        public AlertControllerIntegrationTests()
        {
            _sut = new TestContext();
        }

        [Fact]
        public async Task WhenItemIsBookedThenSendConfirmationAlert()
        {
            // AlertModel value = null;
            var info = new AlertModel()
            {
                CustomerName ="YYYYY",
                CustonmerMailId = "1234",
                ItemPurchased = "1",
                CustomerphoneNumber  ="9023489095",
                Question = "",
                Answer = ""

            };
            var response = await _sut.Client.PostAsync(url + "/ConfirmationAlert",
                new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task WhenConversationBetweenCustomerAndPersonnelThenCheckItsReliable()
        {
            // AlertModel value = null;
            var info = new AlertModel()
            {
                CustomerName = "XXXXX",
                CustonmerMailId = "1234",
                ItemPurchased = "1",
                CustomerphoneNumber = "9023489095",
                Question = "Which Product is better?",
                Answer = ""

            };
            var response = await _sut.Client.PostAsync(url + "/Query",
                new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var reply = await _sut.Client.PostAsync(url + "/Query/XXXXX",
                new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json"));
            reply.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Query")]
        [InlineData("/Query/XXXXX")]
        public async Task WhenBodyIsSentNullThenCheckStatusCodeBadRequest(string value)
        {
            AlertModel info = null;
            var response = await _sut.Client.PostAsync(url + value,
                new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}

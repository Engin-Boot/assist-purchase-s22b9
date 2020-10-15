using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AssistAPurchase.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace AssistAPurchase.Integration.Tests
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
            var info = new AlertModel()
            {
                CustomerName ="YYYY",
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
            var answer = new AlertModel()
            {
                Answer = "MX40 is better"
            };
            var reply = await _sut.Client.PostAsync(url + "/Query/XXXXX",
                new StringContent(JsonConvert.SerializeObject(answer), Encoding.UTF8, "application/json"));
            reply.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Query")]
        [InlineData("/Query/XXXXX")]
        public async Task WhenBodyIsSentNullThenCheckStatusCodeBadRequest(string value)
        {
            var response = await _sut.Client.PostAsync(url + value,
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task WhenBodyIsSentNullThenCheckStatusBadRequest()
        {
            var response = await _sut.Client.PostAsync(url + "/ConfirmationAlert",null);
          response.StatusCode.Should().Be(HttpStatusCode.UnsupportedMediaType);
        }

    }
}

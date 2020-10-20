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
    public class UserControllerIntegrationTest
    {
        private readonly TestContext _sut;
        static string url = "https://localhost:5001/api/User";

        public UserControllerIntegrationTest()
        {
            _sut = new TestContext();
        }
        [Fact]
        public async Task TestLoginSuccessful()
        {
            var info = new UserModel()
            {
                Email = "gagan@gmail.com",
                Password = "gagan"

            };
            var response = await _sut.Client.PostAsync(url + "/login",
                new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task TestLoginUnSuccessful()
        {
            var info = new UserModel()
            {
                Email = "test@gmail.com",
                Password = "test"

            };
            var response = await _sut.Client.PostAsync(url + "/login",
                new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task TestSignUpNotSuccessful()
        {
            var info = new UserModel()
            {
                Email = "gagan@gmail.com",
                Password = "gagan",
                UserName = "gagan"

            };
            var response = await _sut.Client.PostAsync(url + "/signup",
                new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task TestSignUpSuccessful()
        {
            var info = new UserModel()
            {
                Email = "test@gmail.com",
                Password = "test"

            };
            var response = await _sut.Client.PostAsync(url + "/signup",
                new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

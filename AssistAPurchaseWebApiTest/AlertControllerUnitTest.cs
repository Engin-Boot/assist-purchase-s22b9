using AssistAPurchase.Repository;
using AssistAPurchase.Controllers;
using AssistAPurchase.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Abstractions;


namespace AssistAPurchaseWebApiTest
{
    public class AlertControllerUnitTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        readonly AlertController _controller;

        readonly AlertModel _alert = new AlertModel()
        {
            CustomerName = "Jerry",
            CustonmerMailId = "jerry123@gmail.com",
            ItemPurchased = "Item1 Item2 Item3",
            CustomerphoneNumber = "098765432",
            Question = "Which is the best according to budget?",
            Answer = ""
        };
        public AlertControllerUnitTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            IAlertRepository service = new AlertRepository();
            _controller = new AlertController(service);
        }
        [Fact]
        public void SendAlertWhenCustomerPurchedItemReturnOk()
        {
            // Arrange
            AlertModel curerentAlertBody = new AlertModel()
            {
              CustomerName ="Tom",
              ItemPurchased= "Item1 Item2 Item3",
            };
            // Act
            var createdResponse = _controller.SendAlert(curerentAlertBody);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void SendAlertWhenCustomerPurchedItemWithInvalidBodyReturnNotFound()
        {
           
            // Act
            var createdResponse = _controller.SendAlert(null);
            // Assert
            Assert.IsType<BadRequestObjectResult>(createdResponse);
        }
        [Fact]
        public void SendAQueryToCustomerWhenQueryCalledAndReturnOk() {

            // Arrange
            AlertModel curerentAlertBody = new AlertModel()
            {
               CustomerName="Jerry",
               CustonmerMailId= "jerry123@gmail.com",
               ItemPurchased= "Item1 Item2 Item3",
               CustomerphoneNumber ="098765432",
               Question= "Which is the best according to budget?",
               Answer= ""
         };
            // Act
            var createdResponse = _controller.QueryFromCustomer(curerentAlertBody);
            _testOutputHelper.WriteLine(curerentAlertBody.CustomerphoneNumber);
            _testOutputHelper.WriteLine(curerentAlertBody.CustonmerMailId);
            // Assert
            Assert.Equal("",curerentAlertBody.Answer);
            Assert.IsType<OkObjectResult>(createdResponse);

        }
        [Fact]
        public void SendAQueryToCustomerWhenQueryCalledWithInvalidBodyAndReturnbadRequest()
        {

            // Act
            var createdResponse = _controller.QueryFromCustomer(null);
            // Assert
            Assert.IsType<BadRequestObjectResult>(createdResponse);
        }
        [Fact]
        public void AnswerTheQueryAndReturnOk()
        {
            // Arrange
            _controller.QueryFromCustomer(_alert);
            //Act
            string validCustomerName = "Jerry";
            AlertModel answer = new AlertModel() { Answer = "Item3" };
            var createdResponse = _controller.AnswerFromPhilipsPersonnel(validCustomerName, answer);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void AnswerTheQueryWithInvalidInoutAndReturnNotFound()
        {
            // Arrange
            _controller.QueryFromCustomer(_alert);
            //Act
            string invalidCustomerName = "Tom";
            AlertModel answer = new AlertModel() { Answer = "" };
            var createdResponse = _controller.AnswerFromPhilipsPersonnel(invalidCustomerName, answer);
            // Assert
            Assert.IsType<NotFoundObjectResult>(createdResponse);
        }
        [Fact]
        public void WhenCustomerMailIdIsInvalidThenReturnTrue()
        {
            var dummyMailData = new Mailer
            {
                CustomerEmailId = "test@test.com",
                ProductName = "MX450",
                CustomerName = "test"
            };
            var response = _controller.Post(dummyMailData);
            Assert.IsType<OkResult>(response);
            
        }
    }
}

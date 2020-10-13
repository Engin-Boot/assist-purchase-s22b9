using AssistAPurchase.Repository;
using AssistAPurchase.Controllers;
using AssistAPurchase.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AssistAPurchaseWebApiTest
{
    public class AlertControllerUnitTest
    {
        readonly AlertController controller;
        IAlertRepository service;
        public AlertControllerUnitTest()
        {
            service = new AlertRepository();
            controller = new AlertController(service);
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
            var createdResponse = controller.SendAlert(curerentAlertBody);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void SendAlertWhenCustomerPurchedItemWithInvalidBodyReturnNotFound()
        {
            // Arrange
            AlertModel curerentAlertBody = null;
            // Act
            var createdResponse = controller.SendAlert(curerentAlertBody);
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
            var createdResponse = controller.QueryFromCustomer(curerentAlertBody);
            // Assert
            Assert.Equal("",curerentAlertBody.Answer);
            Assert.IsType<OkObjectResult>(createdResponse);

        }

        [Fact]
        public void SendAQueryToCustomerWhenQueryCalledWithInvalidBodyAndReturnbadRequest()
        {

            // Arrange
            AlertModel curerentAlertBody = null;
            // Act
            var createdResponse = controller.QueryFromCustomer(curerentAlertBody);
            // Assert
            Assert.IsType<BadRequestObjectResult>(createdResponse);
        }


        [Fact]
        public void AnswerTheQueryAndReturnOk()
        {
            // Arrange
            AlertModel curerentAlertBody= new AlertModel()
            {
                CustomerName = "Jerry",
                CustonmerMailId = "jerry123@gmail.com",
                ItemPurchased = "Item1 Item2 Item3",
                CustomerphoneNumber = "098765432",
                Question = "Which is the best according to budget?",
                Answer = ""
            };
           
            controller.QueryFromCustomer(curerentAlertBody);

            //Act
            string validCustomerName = "Jerry";
            AlertModel answer = new AlertModel() { Answer = "Item3" };
            var createdResponse = controller.AnswerFromPhilipsPersonnel(validCustomerName, answer);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }


        [Fact]
        public void AnswerTheQueryWithInvalidInoutAndReturnNotFound()
        {
            // Arrange
            AlertModel curerentAlertBody = new AlertModel()
            {
                CustomerName = "Avenger",
                CustonmerMailId = "Avenger123@gmail.com",
                ItemPurchased = "Item1 Item2",
                CustomerphoneNumber = "098765432",
                Question = "Which is the best according to portability?",
                Answer = ""
            };
            controller.QueryFromCustomer(curerentAlertBody);

            //Act
            string invalidCustomerName = "Tom";
            AlertModel answer = new AlertModel() { Answer = "" };
            var createdResponse = controller.AnswerFromPhilipsPersonnel(invalidCustomerName, answer);
            // Assert
            Assert.IsType<NotFoundObjectResult>(createdResponse);
        }
    }
}

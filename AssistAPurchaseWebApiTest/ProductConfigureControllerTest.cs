using AssistAPurchase.Controllers;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace AssistAPurchaseWebApiTest
{
    public class ProductConfigureControllerTest
    {
        readonly ProductConfigureController controller;
        IMonitoringProductRepository service;

        public ProductConfigureControllerTest() {
            service = new MonitoringProductTestRepository();
            controller = new ProductConfigureController(service);
        }

        //Tests for GET getAll()- GET api/ProductConfigure/getAllProducts
        [Fact]
        public void GetAllWhenCalledReturnsOkResult()
        {
            // Act
            var okResult = controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetAllWhenCalledReturnsAllItems()
        {
            // Act
            var okResult = controller.GetAll().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(6, items.Count);
        }

        // Test for GET Find()- GET api/ProductConfigure/{productNumber}
        [Fact]
        public void FindUnknownProductNumberPassedReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = controller.GetProductByProductNumber("XYZ");
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
        [Fact]
        public void FindExistingProductNumberPassedReturnsOkResult()
        {
            // Arrange
            var testProductNumber = "MP2";
            // Act
            var okResult = controller.GetProductByProductNumber(testProductNumber);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void FindExistingProductNumberPassedReturnsRightItem()
        {
            // Arrange
            var testProductNumber = "MX750";
            // Act
            var okResult = controller.GetProductByProductNumber(testProductNumber).Result as OkObjectResult;
            // Assert
            Assert.IsType<MonitoringItems>(okResult.Value);
            Assert.Equal(testProductNumber, (okResult.Value as MonitoringItems).ProductNumber);
        }


        //Testing for Add Method
        [Fact]
        public void AddInvalidObjectPassedReturnsBadRequest()
        {
            // Arrange
            MonitoringItems monitoringItem = null;
            var productNumber = "XXXX";
            controller.ModelState.AddModelError("ProductNumber", "Required");
            // Act
            var badResponse = controller.Create(productNumber,monitoringItem);
            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }
        [Fact]
        public void AddValidObjectPassedReturnsCreatedResponse()
        {
            // Arrange
            MonitoringItems testMonitoringItem = new MonitoringItems()
            {
                ProductNumber="QQQQ",
                ProductName="Printer"
            };
            var productNumber = "XXXX";
            // Act
            var createdResponse = controller.Create(productNumber,testMonitoringItem);
            // Assert
            Assert.IsType<CreatedAtRouteResult>(createdResponse);
        }
        // For remove method
        [Fact]
        public void RemoveNotExistingProductNumberPassedReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingProductNumber = "WWF";
            // Act
            var badResponse = controller.Delete(notExistingProductNumber);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void RemoveExistingProductNumberPassedReturnsOkResult()
        {
            // Arrange
            var existingProductNumber = "CM";
            // Act
            var okResponse = controller.Delete(existingProductNumber);
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void RemoveExistingProductNumberPassedRemovesOneItem()
        {
            // Arrange
            var existingProductNumber = "MP2";
            // Act
            var okResponse = controller.Delete(existingProductNumber);
            // Assert
            var okResult = controller.GetAll().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(5, items.Count);
            
        }

        //test for update
        [Fact]
        public void UpdateInvalidObjectPassedReturnsBadRequest()
        {
            // Arrange-when product object is invalid
            MonitoringItems item = null;
            var productNumber = "abcd";
            // Act
            var badResponse = controller.Update(productNumber,item);
            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }

        [Fact]
        public void UpdateMisMatchProductNumberPassedReturnsBadRequest()
        {
            // Arrange-when product object is invalid
            MonitoringItems misMatchProductNumberItem = new MonitoringItems(){
                ProductNumber = "XYZ",
                ProductName = "Speaker"
            };
            var productNumber = "XYZA";
            // Act
            var badResponse = controller.Update(productNumber, misMatchProductNumberItem);
            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }

        [Fact]
        public void UpdateNotExistingProductNumberPassedReturnsNotFound()
        {
            // Arrange-when product object is invalid
            MonitoringItems misMatchProductNumberItem = new MonitoringItems()
            {
                ProductNumber = "M1M2",
                ProductName = "LCD"
            };
            var productNumber = "M1M2";
            // Act
            var notFoundResponse = controller.Update(productNumber, misMatchProductNumberItem);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResponse);
        }

        [Fact]
        public void UpdateValidObjectPassedReturnsNoContentResult()
        {
            // Arrange-when product object is invalid
            MonitoringItems validMonitoringItem = new MonitoringItems { ProductNumber = "MP2", ProductName = "IntelliVue" };
            var validProductNumber = "MP2";
            // Act
            var noContentResultResponse = controller.Update(validProductNumber,validMonitoringItem);
            // Assert
            Assert.IsType<NoContentResult>(noContentResultResponse);
        }
    }
}

using AssistAPurchase.Controllers;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace AssistAPurchaseWebApiTest
{
    public class ProductConfigureControllerUnitTests
    {
        readonly ProductConfigureController _controller;

        public ProductConfigureControllerUnitTests()
        {
            IMonitoringProductRepository service = new MonitoringProductRepository();
            _controller = new ProductConfigureController(service);
        }

        //Tests for GET getAll()- GET api/ProductConfigure/getAllProducts
        [Fact]
        public void GetAllWhenCalledReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetAllWhenCalledReturnsAllItems()
        {
            // Act
            // Assert
            if (_controller.GetAll().Result is OkObjectResult okResult)
            {
                var items = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(17, items.Count);
            }
        }

        // Test for GET Find()- GET api/ProductConfigure/{productNumber}
        [Fact]
        public void FindUnknownProductNumberPassedReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetProductByProductNumber("XYZ");
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
        [Fact]
        public void FindExistingProductNumberPassedReturnsOkResult()
        {
            // Arrange
            var testProductNumber = "MP2";
            // Act
            var okResult = _controller.GetProductByProductNumber(testProductNumber).Result as OkObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
            string expectedProductName = "IntelliVue";
            Assert.Equal(expectedProductName, (okResult.Value as MonitoringItems)?.ProductName);
        }
        [Fact]
        public void FindExistingProductNumberPassedReturnsRightItem()
        {
            // Arrange
            var testProductNumber = "MX750";
            // Act
            // Assert
            if (_controller.GetProductByProductNumber(testProductNumber).Result is OkObjectResult okResult)
            {
                Assert.IsType<MonitoringItems>(okResult.Value);
                Assert.Equal(testProductNumber, (okResult.Value as MonitoringItems)?.ProductNumber);
            }
        }


        //Testing for Add Method
        [Fact]
        public void AddInvalidObjectPassedReturnsBadRequest()
        {
            // Arrange
            var productNumber = "XXXX";
            _controller.ModelState.AddModelError("ProductNumber", "Required");
            // Act
            var badResponse = _controller.Create(productNumber,null);
            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }
        [Fact]
        public void AddValidObjectPassedReturnsCreatedResponse()
        {
            // Arrange
            MonitoringItems testMonitoringItem = new MonitoringItems()
            {
                ProductNumber="XXXX",
                ProductName="Printer"
            };
            var productNumber = "XXXX";
            // Act
            var createdResponse = _controller.Create(productNumber,testMonitoringItem);
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
            var badResponse = _controller.Delete(notExistingProductNumber);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void RemoveExistingProductNumberPassedReturnsOkResult()
        {
            // Arrange
            var existingProductNumber = "CM";
            // Act
            var okResponse = _controller.Delete(existingProductNumber);
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void RemoveExistingProductNumberPassedRemovesOneItem()
        {
            // Arrange
            var existingProductNumber = "MP2";
            // Act
            _controller.Delete(existingProductNumber);
            // Assert
            // Assert
            if (_controller.GetAll().Result is OkObjectResult okResult)
            {
                var items = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(16, items.Count);
            }
        }

        //test for update
        [Fact]
        public void UpdateInvalidObjectPassedReturnsBadRequest()
        {
            
            var productNumber = "abcd";
            // Act
            var badResponse = _controller.Update(productNumber,null);
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
            var badResponse = _controller.Update(productNumber, misMatchProductNumberItem);
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
            var notFoundResponse = _controller.Update(productNumber, misMatchProductNumberItem);
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
            var noContentResultResponse = _controller.Update(validProductNumber,validMonitoringItem);
            // Assert
            Assert.IsType<NoContentResult>(noContentResultResponse);
        }
    }
}

using AssistAPurchase.Controllers;
using AssistAPurchase.DataBase;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;


namespace AssistAPurchaseWebApiTest
{
    public class RespondToQuestionsControllerUnitTests
    {
        readonly RespondToQuestionsController controller;
        IRespondToQuestionRepository service;
        public RespondToQuestionsControllerUnitTests()
        {
            service = new RespondToQuestionRepository();
            controller = new RespondToQuestionsController(service);
        }

        [Fact]
        public void GetAllWhenCalledReturnsOkResult()
        {
            // Act
            var okResult = controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetAllWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetAll().Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(17, products.Count);
        }

        [Fact]
        public void GetProductWithCompactCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResultWithYes = controller.GetValueByCompactCategory("YES").Result as OkObjectResult;
            var okResultWithNo = controller.GetValueByCompactCategory("NO").Result as OkObjectResult;
            var okResult = controller.GetValueByCompactCategory("BOTH").Result as OkObjectResult;
            // Assert
            var productsWithYes = Assert.IsType<List<MonitoringItems>>(okResultWithYes.Value);
            Assert.Equal(12, productsWithYes.Count);
            var productsWithNo = Assert.IsType<List<MonitoringItems>>(okResultWithNo.Value);
            Assert.Equal(5, productsWithNo.Count);
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Empty(products);
        }

        [Fact]
        public void GetProductWithProductSpecificTrainingCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByCompactCategory("YES").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(12, products.Count);
        }

        [Fact]
        public void GetProductWithPriceCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetProductByPrice("1000","BELOW").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Empty(products);
        }

        [Fact]
        public void GetProductWithWearableCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByWearableCategory("YES").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(4, products.Count);
        }

        [Fact]
        public void GetProductWithSoftwareUpdateSupportCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueBySoftwareUpdateSupportCategory("YES").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(8, products.Count);
        }

        [Fact]
        public void GetProductWithPortabilityCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByPortabilityCategory("NO").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(5, products.Count);
        }

        [Fact]
        public void GetProductWithBatterySupportWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByBatterySupportCategory("NO").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(12, products.Count);
        }

        [Fact]
        public void GetProductWithThirdPartyDevicetCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByThirdPartyDeviceSupportCategory("YES").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(9, products.Count);
        }

        [Fact]
        public void GetProductWithSafeToFlyCertificationCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueBySafeToFlyCertificationCategory("NO").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(13, products.Count);
        }

        [Fact]
        public void GetProductWithTouchScreenSupportCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByTouchScreenSupportCategory("YES").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(17, products.Count);
        }

        [Fact]
        public void GetProductWithScreenSizeCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByScreenSizeCategory("10","BELOW").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(9, products.Count);
        }

        [Fact]
        public void GetProductWithCyberSecirityCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByCyberSecurityCategory("YES").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Single(products);
        }






    }
}

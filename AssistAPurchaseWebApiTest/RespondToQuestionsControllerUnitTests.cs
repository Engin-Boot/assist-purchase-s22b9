using AssistAPurchase.Controllers;
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
            var okResult = controller.GetValueByProductSpecificTrainingCategory("YES").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(9, products.Count);
        }

        [Fact]
        public void GetProductWithPriceCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetProductByPrice("1000","BELOW").Result as OkObjectResult;
            var okResult2 = controller.GetProductByPrice("50000", "ABOVE").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Empty(products);
            var products2 = Assert.IsType<List<MonitoringItems>>(okResult2.Value);
            Assert.Equal(1,products2.Count);
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
            var okResult2 = controller.GetValueByScreenSizeCategory("10", "ABOVE").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(9, products.Count);
            var products2 = Assert.IsType<List<MonitoringItems>>(okResult2.Value);
            Assert.Equal(8, products2.Count);

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

        [Fact]
        public void GetProductMultiPatientCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = controller.GetValueByMultiPatientSupportCategory("YES").Result as OkObjectResult;
            // Assert
            var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
            Assert.Equal(4,products.Count);
        }

        [Fact]
        public void GetDescriptionWhenCalledReturnsOk()
        {
            // Act
            var okResult = controller.GetDescription("X3") as OkObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetdescriptionCalledReturnDescription() {
            var expectedDescription = "The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.";
            // Act
            var okResult = controller.GetDescription("MX40") as OkObjectResult;
            // Assert
            Assert.IsType<string>(okResult.Value);
            Assert.Equal(expectedDescription, (okResult.Value));
        }

        [Fact]
        public void GetDescriptionWhenCalledReturnsNotFound()
        {
            // Act
            var result = controller.GetDescription("XXX");
            // Assert
            Assert.IsType<NotFoundResult>(result);

        }




    }
}

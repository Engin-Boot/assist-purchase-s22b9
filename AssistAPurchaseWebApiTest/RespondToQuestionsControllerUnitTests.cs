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
        readonly RespondToQuestionsController _controller;

        public RespondToQuestionsControllerUnitTests()
        {
            IRespondToQuestionRepository service = new RespondToQuestionRepository();
            _controller = new RespondToQuestionsController(service);

        }

        
        [Fact]
        public void GetFilterResultReturnOkResult()
        {
            var product = new MonitoringItems
            {
                ProductSpecficTraining = "NO",
                Price = "16900",
                Wearable = "NO",
                SoftwareUpdateSupport = "YES",
                Portability= "YES",
                Compact= "YES",
                BatterySupport= "NO",
                ThirdPartyDeviceSupport= "YES",
                SafeToFlyCertification = "NO",
                TouchScreenSupport = "YES",
                ScreenSize = "6.0",
                MultiPatientSupport = "NO",
                CyberSecurity = "NO"
            };
            // Act
            var okResult = _controller.GetValueByCategory(product);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetAllWhenCalledReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetAllWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetAll().Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(17, products.Count);
            }
        }

        [Fact]
        public void GetProductWithCompactCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResultWithYes = _controller.GetValueByCompactCategory("YES").Result as OkObjectResult;
            var okResultWithNo = _controller.GetValueByCompactCategory("NO").Result as OkObjectResult;
            // Assert
            if (okResultWithYes != null)
            {
                var productsWithYes = Assert.IsType<List<MonitoringItems>>(okResultWithYes.Value);
                Assert.Equal(12, productsWithYes.Count);
            }

            if (okResultWithNo != null)
            {
                var productsWithNo = Assert.IsType<List<MonitoringItems>>(okResultWithNo.Value);
                Assert.Equal(5, productsWithNo.Count);
            }
        }

        [Fact]
        public void GetProductWithProductSpecificTrainingCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueByProductSpecificTrainingCategory("YES").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(9, products.Count);
            }
        }

        [Fact]
        public void GetProductWithPriceCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = _controller.GetProductByPrice("1000","BELOW").Result as OkObjectResult;
            var okResult2 = _controller.GetProductByPrice("50000", "ABOVE").Result as OkObjectResult;
            // Assert
            if (okResult != null)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Empty(products);
            }

            if (okResult2 != null)
            {
                var products2 = Assert.IsType<List<MonitoringItems>>(okResult2.Value);
                Assert.Single(products2);
            }
        }

        [Fact]
        public void GetProductWithWearableCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueByWearableCategory("YES").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(4, products.Count);
            }
        }

        [Fact]
        public void GetProductWithSoftwareUpdateSupportCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueBySoftwareUpdateSupportCategory("YES").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(8, products.Count);
            }
        }

        [Fact]
        public void GetProductWithPortabilityCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueByPortabilityCategory("NO").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(5, products.Count);
            }
        }

        [Fact]
        public void GetProductWithBatterySupportWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueByBatterySupportCategory("NO").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(@object: okResult.Value);
                Assert.Equal(12, products.Count);
            }
        }

        [Fact]
        public void GetProductWithThirdPartyDevicetCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueByThirdPartyDeviceSupportCategory("YES").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(9, products.Count);
            }
        }

        [Fact]
        public void GetProductWithSafeToFlyCertificationCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueBySafeToFlyCertificationCategory("NO").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(13, products.Count);
            }
        }

        [Fact]
        public void GetProductWithTouchScreenSupportCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueByTouchScreenSupportCategory("YES").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(17, products.Count);
            }
        }

        [Fact]
        public void GetProductWithScreenSizeCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            var okResult = _controller.GetValueByScreenSizeCategory("10","BELOW").Result as OkObjectResult;
            var okResult2 = _controller.GetValueByScreenSizeCategory("10", "ABOVE").Result as OkObjectResult;
            // Assert
            if (okResult != null)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(9, products.Count);
            }

            if (okResult2 != null)
            {
                var products2 = Assert.IsType<List<MonitoringItems>>(okResult2.Value);
                Assert.Equal(8, products2.Count);
            }
        }

        [Fact]
        public void GetProductWithCyberSecirityCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueByCyberSecurityCategory("YES").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Single(products);
            }
        }

        [Fact]
        public void GetProductMultiPatientCategoryWhenCalledReturnsItemsCount()
        {
            // Act
            // Assert
            if (_controller.GetValueByMultiPatientSupportCategory("YES").Result is OkObjectResult okResult)
            {
                var products = Assert.IsType<List<MonitoringItems>>(okResult.Value);
                Assert.Equal(4,products.Count);
            }
        }

        [Fact]
        public void GetDescriptionWhenCalledReturnsOk()
        {
            // Act
            var okResult = _controller.GetDescription("X3") as OkObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetdescriptionCalledReturnDescription() {
            var expectedDescription = "The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.";
            // Act
            // Assert
            if (_controller.GetDescription("MX40") is OkObjectResult okResult)
            {
                Assert.IsType<string>(okResult.Value);
                Assert.Equal(expectedDescription, (okResult.Value));
            }
        }

        [Fact]
        public void GetDescriptionWhenCalledReturnsNotFound()
        {
            // Act
            var result = _controller.GetDescription("XXX");
            // Assert
            Assert.IsType<NotFoundResult>(result);

        }




    }
}

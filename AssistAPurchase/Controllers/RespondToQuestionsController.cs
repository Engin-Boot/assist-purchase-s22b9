using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;

namespace AssistAPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespondToQuestionsController : ControllerBase
    {
        public IRespondToQuestionRepository Products { get; set; } 
        public RespondToQuestionsController(IRespondToQuestionRepository prodcuts)
        {
            Products = prodcuts;
        }

        // GET https://localhost:5001/api/RespondToQuestions/MonitoringProductHomePage
        [HttpGet("MonitoringProductHomePage")]
        public ActionResult<IEnumerable<MonitoringItems>> GetAll()
        {
            var allproducts = Products.GetAllProduct();
            return Ok(allproducts);
        }

        [HttpGet("MonitoringProductHomePage/Compact/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>>  GetValueByCompactCategory(string value)
        {
                return Ok(Products.FindByCompactCategory(value));
        }

        [HttpGet("MonitoringProductHomePage/Description/{productNumber}")]
        public ActionResult GetDescription(string productNumber)
        {
            var description = Products.GetDescription(productNumber);

            if (description == null)
                return NotFound();

            return Ok(Products.GetDescription(productNumber));
        }
        
        [HttpGet("MonitoringProductHomePage/ProductSpecficTraining/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByProductSpecficTrainingCategory(string value)
        {
            return Ok(Products.FindByProductSpecificTrainingCategory(value));
        }

        [HttpGet("MonitoringProductHomePage/Price/{price}/{belowOrAbove}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetProductByPrice(string price,string belowOrAbove)
        {
            return Ok(Products.FindByPriceCategory(price,belowOrAbove));
        }

        [HttpGet("MonitoringProductHomePage/Wearable/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByWearableCategory(string value)
        {
            return Ok(Products.FindByWearableCategory(value));
        }


        [HttpGet("MonitoringProductHomePage/SoftwareUpdateSupport/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueBySoftwareUpdateSupportCategory(string value)
        {
            return Ok(Products.FindBySoftwareUpdateSupportCategory(value));
        }

        [HttpGet("MonitoringProductHomePage/Portability/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByPortabilityCategory(string value)
        {
            return Ok(Products.FindByPortabilityCategory(value));
        }

        [HttpGet("MonitoringProductHomePage/BatterySupport/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByBatterySupportCategory(string value)
        {
            return Ok(Products.FindByBatterySupportCategory(value));
        }

        [HttpGet("MonitoringProductHomePage/ThirdPartyDeviceSupport/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByThirdPartyDeviceSupportCategory(string value)
        {
            return Ok(Products.FindByThirdPartyDeviceSupportCategory(value));
        }
        [HttpGet("MonitoringProductHomePage/SafeToFlyCertification/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueBySafeToFlyCertificationCategory(string value)
        {
            return Ok(Products.FindBySafeToFlyCertificationCategory(value));
        }


        [HttpGet("MonitoringProductHomePage/TouchScreenSupport/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByTouchScreenSupportCategory(string value)
        {
            return Ok(Products.FindByTouchScreenSupportCategory(value));
        }

        [HttpGet("MonitoringProductHomePage/ScreenSize/{screenSize}/{belowOrAbove}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByScreenSizeCategory(string screenSize,string belowOrAbove)
        {
            return Ok(Products.FindByScreenSizeCategory(screenSize,belowOrAbove));
        }


        [HttpGet("MonitoringProductHomePage/MultiPatientSupport/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByMultiPatientSupportCategory(string value)
        {
            return Ok(Products.FindByMultiPatientSupportCategory(value));
        }

        [HttpGet("MonitoringProductHomePage/CyberSecurity/{value}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetValueByCyberSecurityCategory(string value)
        {
            return Ok(Products.FindByCyberSecuritytCategory(value));
        }

    }
}

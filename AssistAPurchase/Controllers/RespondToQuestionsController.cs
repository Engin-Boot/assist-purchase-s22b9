﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;
using AssistAPurchase.SupportingFunctions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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



    }
}

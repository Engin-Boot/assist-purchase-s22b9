using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;
using AssistAPurchase.SupportingFunctions;

namespace AssistAPurchase.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductConfigureController : ControllerBase
    {
        private IMonitoringProductRepository Products{ get;}
        public ProductConfigureController(IMonitoringProductRepository prodcuts)
        {
            Products = prodcuts;
        }

        // GET api/ProductConfigure/getAllProducts
        [HttpGet("getAllProducts")]
        public ActionResult<IEnumerable<MonitoringItems>> GetAll()
        {
            var allproducts = Products.GetAll();
            return Ok(allproducts);
        }

        // GET api/ProductConfigure/{productNumber}
        [HttpGet("{productNumber}")]
        public ActionResult<IEnumerable<MonitoringItems>> GetProductByProductNumber(string productNumber)
        {
            var product = Products.Find(productNumber);
            if (product == null)
            {
                return NotFound();
            }
            //return new ObjectResult(product);
            return Ok(product);
        }

        // POST api/ProductConfigure/{productNumber}
        [HttpPost("{productNumber}")]
        public IActionResult Create(string productNumber,[FromBody] MonitoringItems product)
        {
            if (ProductConfigureSupporterFunctions.CheckForNullOrMisMatchProductNumber(product, productNumber))
                return BadRequest();
            /*if (product == null)
            {
                return BadRequest();
            }*/
            Products.Add(product);
            return Ok();
        }

        // Put api/ProductConfigure/{productNumber}
        [HttpPut("{productNumber}")]
        public IActionResult Update(string productNumber, [FromBody] MonitoringItems product)
        {
            if (ProductConfigureSupporterFunctions.CheckForNullOrMisMatchProductNumber(product, productNumber))
                return BadRequest();
            var currentProduct = Products.Find(productNumber);
            
            if (currentProduct == null)
            {
                return NotFound();
            }
            string message = Products.Update(product);
            Console.WriteLine(message);
            return new NoContentResult();
        }


        // Delete api/ProductConfigure/{productNumber}
        [HttpDelete("{productNumber}")]
        public ActionResult Delete(string productNumber)
        {
            MonitoringItems itemToBeDeleted = Products.Remove(productNumber);
            if (itemToBeDeleted == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

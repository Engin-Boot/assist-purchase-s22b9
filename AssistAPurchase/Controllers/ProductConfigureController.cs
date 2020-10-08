using System;
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
    public class ProductConfigureController : ControllerBase
    {
        public IMonitoringProductRepository Products{ get; set; }
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
            if (product == null)
            {
                return BadRequest();
            }
            Products.Add(product);
            return CreatedAtRoute("GetMonitoringProduct", new { productNumber = product.ProductNumber }, product);
        }

        // Put api/ProductConfigure/{productNumber}
        [HttpPut("{productNumber}")]
        public IActionResult Update(string productNumber, [FromBody] MonitoringItems product)
        {
            if (ProductConfigureSupporterFunctions.CheckForNullOrMisMatchProductNumber(product, productNumber))
                return BadRequest();
            /*if (product == null || product.ProductNumber != productNumber)
            {
                return BadRequest();
            }*/
            var currentProduct = Products.Find(productNumber);
            if (currentProduct == null)
            {
                return NotFound();
            }
            Products.Update(product);
            return new NoContentResult();
        }


        // Delete api/ProductConfigure/{productNumber}
        [HttpDelete("{productNumber}")]
        public ActionResult Delete(string productNumber)
        {
            var currentProduct = Products.Find(productNumber);
            //Products.Remove(productNumber);
            if (currentProduct == null)
            {
                return NotFound();
            }
            Products.Remove(productNumber);
            return Ok();
        }
    }
}

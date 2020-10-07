using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;

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

        public IEnumerable<MonitoringItems> GetAll()
        {
            return Products.GetAll();
        }

        [HttpGet("{productNumber}")]
        public IActionResult GetProductByProductNumber(string productNumber)
        {
            var product = Products.Find(productNumber);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

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

        [HttpPut("{productNumber}")]
        public IActionResult Update(string productNumber, [FromBody] MonitoringItems product)
        {
            if (product == null || product.ProductNumber != productNumber)
            {
                return BadRequest();
            }

            var currentProduct = Products.Find(productNumber);
            if (currentProduct == null)
            {
                return NotFound();
            }

            Products.Update(product);
            return new NoContentResult();
        }

        [HttpDelete("{productNumber}")]
        public void Delete(string productNumber)
        {
            Products.Remove(productNumber);
        }
    }
}

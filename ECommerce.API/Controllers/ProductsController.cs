using ECommerce.API.Models;
using ECommerce.API.Persistence;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ECommerceDbContext _ecommerceDbContext;

        public ProductsController(ECommerceDbContext eCommerceDbContext)
        {
            _ecommerceDbContext = eCommerceDbContext;
        }

        // api/products
        [HttpGet]
        public IActionResult Get()
        {
            var products = _ecommerceDbContext.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductsInputModel productsInputModel)
        {
            if (productsInputModel == null)
            {
                return BadRequest();
            }

            var product = new ProductsModel(productsInputModel.Description, productsInputModel.Price);

            _ecommerceDbContext.Products.Add(product);
            _ecommerceDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProductsInputModel productsInputModel, int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            product.Description = productsInputModel.Description;
            product.Price = productsInputModel.Price;

            _ecommerceDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            _ecommerceDbContext.Products.Remove(product);

            _ecommerceDbContext.SaveChanges();

            return NoContent();
        }
    }
}

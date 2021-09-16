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

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}

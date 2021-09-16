using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Models
{
    public class ProductsModel
    {
        public ProductsModel(int id, string description, decimal price)
        {
            Id = id;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

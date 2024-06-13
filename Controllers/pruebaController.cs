using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", Price = 10.00m },
            new Product { Id = 2, Name = "Product2", Price = 20.00m },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = Products.Max(p => p.Id) + 1;
            Products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            Products.Remove(product);
            return NoContent();
        }
    }
}

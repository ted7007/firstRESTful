using FirstRESTful.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FirstRESTful.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductsContext context;

        public ProductsController(ProductsContext context)
        {
            this.context = context;
            if (!context.Products.Any())
            {
                context.Products.Add(new Product { Name = "Milk", Price = 82, Quanity = 10, QuanityOfBuys = 0 });
                context.Products.Add(new Product { Name = "Eggs", Price = 112, Quanity = 13, QuanityOfBuys = 0 });
                context.SaveChanges();
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return context.Products.ToArray();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();
            return new ObjectResult(product);
        }

        // POST api/users
        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            context.Products.Add(product);
            context.SaveChanges();
            return Ok(product);
        }

        // PUT api/users/
        [HttpPut]
        public ActionResult<Product> Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (!context.Products.Any(x => x.Id == product.Id))
            {
                return NotFound();
            }

            context.Update(product);
            context.SaveChanges();
            return Ok(product);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            Product product = context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return Ok(product);
        }
    }
}

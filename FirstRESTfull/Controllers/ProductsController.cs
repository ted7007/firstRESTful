using FirstRESTful.Models;
using FirstRESTful.Reposirory;
using FirstRESTful.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FirstRESTful.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsService db;

        public ProductsController(IProductsService db)
        {
            this.db = db;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            var products = db.GetProducts();
            return new ObjectResult(db.GetProducts());
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> Get(int id)
        {
            ProductDTO product = db.GetProduct(id);
            if (product == null)
                return NotFound();
            return new ObjectResult(product);
        }

        // POST api/users
        [HttpPost]
        public ActionResult<Product> Post(ProductDTO product)
        {
            if (product == null || product.Id != default(int))
            {
                return BadRequest();
            }

            db.AddProduct(product);
            return Ok(product);
        }

        // PUT api/users/
        [HttpPut]
        public ActionResult<ProductDTO> Put(ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (db.Any(x => x.Id == product.Id))
            {
                return NotFound();
            }

            db.UpdateProduct(product);
            return Ok(product);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ProductDTO product = db.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.DeleteProduct(id);
            return Ok();
        }
    }
}

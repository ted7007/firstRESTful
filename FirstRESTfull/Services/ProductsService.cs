using FirstRESTful.Models;
using FirstRESTful.Reposirory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRESTful.Services
{
    public class ProductsService : IProductsService
    {
        ProductsContext db;

        public ProductsService(ProductsContext context)
        {
            db = context;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = from p in db.Products
                           select new ProductDTO()
                           { Id = p.Id, 
                             Name = p.Name,
                             Price = p.Price,
                             Quanity = p.Quanity,
                             QuanityOfBuys = p.QuanityOfBuys 
                           };
            return products;
        }

        public ProductDTO GetProduct(int id)
        {
            var product = (from p in db.Products
                           where p.Id == id
                           select new ProductDTO()
                           {
                               Id = p.Id,
                               Price = p.Price,
                               Name = p.Name,
                               Quanity = p.Quanity,
                               QuanityOfBuys = p.QuanityOfBuys
                           }).FirstOrDefault();
            return product;
        }

        public void AddProduct(ProductDTO product)
        {
            var productToAdd = new Product()
            {
                //Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quanity = product.Quanity,
                QuanityOfBuys = product.QuanityOfBuys
            };
            db.Products.Add(productToAdd);
            db.SaveChanges();
        }

        public bool Any(Func<ProductDTO,bool> expression)
        {
            var productsDTO = from p in db.Products
                           select new ProductDTO()
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Price = p.Price,
                               Quanity = p.Quanity,
                               QuanityOfBuys = p.QuanityOfBuys
                           };
            return productsDTO.Any(expression);
        }

        public void UpdateProduct(ProductDTO product)
        {
            var productToChange = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quanity = product.Quanity,
                QuanityOfBuys = product.QuanityOfBuys
            };
            db.Update(productToChange);
            db.SaveChanges();

        }

        public void DeleteProduct(int id)
        {
            var product = FindProduct(id);

            db.Remove(product);
            db.SaveChanges();
        }

        public ProductDTO Find(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            var productToFind = new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quanity = product.Quanity,
                QuanityOfBuys = product.QuanityOfBuys
            };
            return productToFind;
        }

        private Product FindProduct(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

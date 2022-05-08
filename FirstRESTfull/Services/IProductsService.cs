using FirstRESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRESTful.Services
{
    public interface IProductsService : IDisposable
    {
        IEnumerable<ProductDTO> GetProducts();

        ProductDTO GetProduct(int id);

        void AddProduct(ProductDTO product);

        void UpdateProduct(ProductDTO product);

        bool Any(Func<ProductDTO, bool> func);

        ProductDTO Find(int id);

        void DeleteProduct(int id);
    }
}

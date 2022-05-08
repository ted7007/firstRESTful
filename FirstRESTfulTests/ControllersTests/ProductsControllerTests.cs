using FirstRESTful.Controllers;
using FirstRESTful.Models;
using FirstRESTful.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstRESTfulTests.ControllersTests
{
    [TestClass()]
    public class ProductsControllersTests
    {

        [TestMethod]
        public void GetProductsTest()
        {
            // Arrange
            Mock<IProductsService> mock = new Mock<IProductsService>();
            mock.Setup(rep => rep.GetProducts()).Returns(GetTestProducts());
            var controller = new ProductsController(mock.Object);

            // Act
            var result = ((controller.Get().Result as ObjectResult).Value as IEnumerable<ProductDTO>).Count();

            // Assert
            Assert.AreEqual(GetTestProducts().Count(), result);


        }

        [TestMethod]
        public void GetProduct_ByIdTest()
        {
            // Arrange
            Mock<IProductsService> mock = new Mock<IProductsService>();
            mock.Setup(rep => rep.GetProduct(1)).Returns(GetTestProducts().ToList()[0]);
            var controller = new ProductsController(mock.Object);

            // Act
            var result = ((controller.Get(1).Result as ObjectResult).Value as ProductDTO).Id;

            // Assert
            Assert.AreEqual(GetTestProducts().ToList()[0].Id, result);


        }

        private IEnumerable<ProductDTO> GetTestProducts()
        {
            var products = new List<ProductDTO>()
            {
                new ProductDTO(){ Id=1, Name="Eggs", Price=132, Quanity=4, QuanityOfBuys=5 },
                new ProductDTO(){ Id=1, Name="Milk", Price=108, Quanity=2, QuanityOfBuys=132 },
                new ProductDTO(){ Id=1, Name="Sosiges", Price=150, Quanity=8, QuanityOfBuys=5 }
            };
            return products;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRESTful.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quanity { get; set; }

        public int QuanityOfBuys { get; set; }
    }
    //Имеет id, name, price, quantity, quantityOfBuys(колво сколько раз купили, нужно на некст задание для статистики)
}

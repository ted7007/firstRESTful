using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRESTful.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quanity { get; set; }

        public int QuanityOfBuys { get; set; }
    }
}

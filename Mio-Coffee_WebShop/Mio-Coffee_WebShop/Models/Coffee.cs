using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mio_Coffee_WebShop.Models
{
    public class Coffee
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; }

        public string Type { get; set; }

        public string Origin { get; set; }

        public string  Composition { get; set; }

        public int Price { get; set; }

        public string ImageURL { get; set; }

    }
}
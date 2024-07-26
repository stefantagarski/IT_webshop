    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mio_Coffee_WebShop.Models
{
    public class Machines
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Usage { get; set; }
        public string ImageURL { get; set; }

        public int Price { get; set; }

    }
}
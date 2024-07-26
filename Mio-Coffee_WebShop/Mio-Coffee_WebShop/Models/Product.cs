using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mio_Coffee_WebShop.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public int coffeeID { get; set; }
        public List<Coffee> CoffeeProducts { get; set; }

        public int machineID { get; set; }
        public List<Machines> CoffeeMachines { get; set; }

        public Product()
        {
            CoffeeProducts = new List<Coffee>();
            CoffeeMachines = new List<Machines>();
        }
    }
}
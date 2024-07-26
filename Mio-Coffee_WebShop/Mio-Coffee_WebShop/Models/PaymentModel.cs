using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mio_Coffee_WebShop.Models
{
    public class PaymentModel
    {
        public string StripeEmail { get; set; }
        public string StripeToken { get; set; }
    }
}
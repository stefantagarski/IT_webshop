using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;

using Mio_Coffee_WebShop.Models;

public class PaymentController : Controller
{
    private readonly string stripeSecretKey = ConfigurationManager.AppSettings["StripeSecretKey"];
    private readonly string stripePublishableKey = ConfigurationManager.AppSettings["StripePublishableKey"];

    [HttpGet]
    public ActionResult Index()
    {
        ViewBag.StripePublishableKey = stripePublishableKey;
        return View();
    }

    [HttpPost]
    public ActionResult Charge(PaymentModel model)
    {
        //StripeConfiguration.ApiKey = stripeSecretKey;

        //var options = new ChargeCreateOptions
        //{
        //    Amount = 999, // Amount in cents
        //    Currency = "usd",
        //    Description = "Sample Charge",
        //    Source = model.StripeToken,
        //    ReceiptEmail = model.StripeEmail,
        //};

        //var service = new ChargeService();
        ////Charge charge = service.Create(options);

        //if (charge.Status == "succeeded")
        //{
        //    ViewBag.Message = "Payment Successful!";
        //}
        //else
        //{
        //    ViewBag.Message = "Payment Failed!";
        //}
        Session.Clear();
        Session.Abandon();
        return RedirectToAction("ThankYou", "Home");
    }
}

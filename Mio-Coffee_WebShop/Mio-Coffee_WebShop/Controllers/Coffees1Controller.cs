using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mio_Coffee_WebShop.Models;

namespace Mio_Coffee_WebShop.Controllers
{
    public class Coffees1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Coffees1
        //public ActionResult Index()
        //{
        //    return View(db.Coffees.ToList());
        //}

        public ActionResult Index(string name, string type, decimal? minPrice, decimal? maxPrice, string sortOrder)
        {
            // Fetch
            var coffees = db.Coffees.AsQueryable();
            var types = db.Coffees.Select(c => c.Type).Distinct().ToList();
            types.Insert(0, "All");
            ViewBag.Types = types;

            // Apply filters
            if (!string.IsNullOrEmpty(name))
            {
                coffees = coffees.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(type) && type != "All")
            {
                coffees = coffees.Where(c => c.Type == type);
            }

            if (minPrice.HasValue)
            {
                coffees = coffees.Where(c => c.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                coffees = coffees.Where(c => c.Price <= maxPrice.Value);
            }

            // Apply sorting
            ViewBag.CurrentSort = sortOrder;
            switch (sortOrder)
            {
                case "name_desc":
                    coffees = coffees.OrderByDescending(c => c.Name);
                    break;
                case "price_asc":
                    coffees = coffees.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    coffees = coffees.OrderByDescending(c => c.Price);
                    break;
                default:
                    coffees = coffees.OrderBy(c => c.Name);
                    break;
            }

            return View(coffees.ToList());
        }




        // GET: Coffees1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // GET: Coffees1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coffees1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Rating,Type,Origin,Composition,Price,ImageURL")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                db.Coffees.Add(coffee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffee);
        }

        // GET: Coffees1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: Coffees1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Rating,Type,Origin,Composition,Price,ImageURL")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffee);
        }

        // GET: Coffees1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: Coffees1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coffee coffee = db.Coffees.Find(id);
            db.Coffees.Remove(coffee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}

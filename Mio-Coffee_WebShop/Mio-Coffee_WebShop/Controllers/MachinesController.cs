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
    public class MachinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string name, string type, decimal? minPrice, decimal? maxPrice, string sortOrder)
        {
            // Fetch
            var machines = db.Machines.AsQueryable();
            var brands = db.Machines.Select(c => c.Brand).Distinct().ToList();
            brands.Insert(0, "All");
            ViewBag.Types = brands;

            // Apply filtriranje
            if (!string.IsNullOrEmpty(name))
            {
                machines = machines.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(type) && type != "All")
            {
                machines = machines.Where(c => c.Brand == type);
            }

            if (minPrice.HasValue)
            {
                machines = machines.Where(c => c.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                machines = machines.Where(c => c.Price <= maxPrice.Value);
            }

            // Apply sorting
            ViewBag.CurrentSort = sortOrder;
            switch (sortOrder)
            {
                case "name_desc":
                    machines = machines.OrderByDescending(c => c.Name);
                    break;
                case "price_asc":
                    machines = machines.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    machines = machines.OrderByDescending(c => c.Price);
                    break;
                default:
                    machines = machines.OrderBy(c => c.Name);
                    break;
            }

            return View(machines.ToList());
        }

        // GET: Machines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machines machines = db.Machines.Find(id);
            if (machines == null)
            {
                return HttpNotFound();
            }
            return View(machines);
        }

        // GET: Machines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Brand,Usage,ImageURL,Price")] Machines machines)
        {
            if (ModelState.IsValid)
            {
                db.Machines.Add(machines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(machines);
        }

        // GET: Machines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machines machines = db.Machines.Find(id);
            if (machines == null)
            {
                return HttpNotFound();
            }
            return View(machines);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Brand,Usage,ImageURL,Price")] Machines machines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machines);
        }

        // GET: Machines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machines machines = db.Machines.Find(id);
            if (machines == null)
            {
                return HttpNotFound();
            }
            return View(machines);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Machines machines = db.Machines.Find(id);
            db.Machines.Remove(machines);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SoccerLocker.Data;
using SoccerLocker.Models;
using SoccerLocker.ViewModels;

namespace SoccerLocker.Controllers
{
    public class CleatsController : Controller
    {
        private SoccerLockerContext db = new SoccerLockerContext();

        // GET: Cleats
        public ActionResult Index(string brand, string search, string sortBy, int? page)
        {
            CleatsIndexViewModel viewModel = new CleatsIndexViewModel();

            var cleats = db.Cleats.Include(c => c.Brand);

            if (!String.IsNullOrEmpty(search))
            {
                cleats = cleats.Where(c => c.cleatName.Contains(search) || c.color.Contains(search) || c.Brand.name.Contains(search));
                viewModel.Search = search;
            }
            //group search results into categories and count how many items in each category 
            viewModel.BrandWithCount = from matchingProducts in cleats
                                      where
                                     matchingProducts.BrandID != null
                                      group matchingProducts by
                                      matchingProducts.Brand.name into
                                      catGroup
                                      select new BrandWithCount()
                                      {
                                          BrandName = catGroup.Key,
                                          CleatCount = catGroup.Count()
                                      };

            var brands = cleats.OrderBy(c => c.Brand.name).Select(c => c.Brand.name).Distinct();
            if (!String.IsNullOrEmpty(brand))
            {
                cleats = cleats.Where(c => c.Brand.name == brand);
                viewModel.Brand = brand;
            }

            //sort by price
            switch (sortBy)
            {
                case "price_lowest":
                    cleats = cleats.OrderBy(c => c.price);
                    break;
                case "price_highest":
                    cleats = cleats.OrderByDescending(c => c.price);
                    break;
                default:
                    cleats = cleats.OrderBy(c => c.cleatName);
                    break;
            }

            const int PageItems = 10;
            int currentPage = (page ?? 1);
            viewModel.Cleats = cleats.ToPagedList(currentPage, PageItems);
            viewModel.SortBy = sortBy;

            //ViewBag.Brand = new SelectList(brands);
            viewModel.Sorts = new Dictionary<string, string>
            {
                {"Price low to high", "price_lowest" },
                {"Price high to low", "price_highest" }
            };
            return View(viewModel);
        }

        // GET: Cleats/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleats cleats = db.Cleats.Find(id);
            if (cleats == null)
            {
                return HttpNotFound();
            }
            return View(cleats);
        }

        // GET: Cleats/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "name");
            return View();
        }

        // POST: Cleats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,BrandID,cleatName,size,price,color")] Cleats cleats)
        {
            if (ModelState.IsValid)
            {
                db.Cleats.Add(cleats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "ID", "name", cleats.BrandID);
            return View(cleats);
        }

        // GET: Cleats/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleats cleats = db.Cleats.Find(id);
            if (cleats == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "name", cleats.BrandID);
            return View(cleats);
        }

        // POST: Cleats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,BrandID,cleatName,size,price,color")] Cleats cleats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cleats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "name", cleats.BrandID);
            return View(cleats);
        }

        // GET: Cleats/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleats cleats = db.Cleats.Find(id);
            if (cleats == null)
            {
                return HttpNotFound();
            }
            return View(cleats);
        }

        // POST: Cleats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Cleats cleats = db.Cleats.Find(id);
            db.Cleats.Remove(cleats);
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

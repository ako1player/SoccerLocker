using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoccerLocker.Data;
using SoccerLocker.Models;

namespace SoccerLocker.Controllers
{
    public class CleatsController : Controller
    {
        private SoccerLockerContext db = new SoccerLockerContext();

        // GET: Cleats
        public ActionResult Index()
        {
            return View(db.Cleats.ToList());
        }

        // GET: Cleats/Details/5
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cleats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,cleatBrand,cleatName,size,price,color")] Cleats cleats)
        {
            if (ModelState.IsValid)
            {
                db.Cleats.Add(cleats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cleats);
        }

        // GET: Cleats/Edit/5
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
            return View(cleats);
        }

        // POST: Cleats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cleatBrand,cleatName,size,price,color")] Cleats cleats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cleats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cleats);
        }

        // GET: Cleats/Delete/5
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

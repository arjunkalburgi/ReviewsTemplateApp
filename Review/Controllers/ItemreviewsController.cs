using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Review.DAL;
using Review.Models;

namespace Review.Controllers
{
    public class ItemreviewsController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Itemreviews
        public ActionResult Index()
        {
            var itemreviews = db.Itemreviews.Include(i => i.Item);
            return View(itemreviews.ToList());
        }

        // GET: Itemreviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Itemreview itemreview = db.Itemreviews.Find(id);
            if (itemreview == null)
            {
                return HttpNotFound();
            }
            return View(itemreview);
        }

        // GET: Itemreviews/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Title");
            return View();
        }

        // POST: Itemreviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemreviewID,ItemID,WrittenReview,Grade")] Itemreview itemreview)
        {
            if (ModelState.IsValid)
            {
                db.Itemreviews.Add(itemreview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ID", "Title", itemreview.ItemID);
            return View(itemreview);
        }

        // GET: Itemreviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Itemreview itemreview = db.Itemreviews.Find(id);
            if (itemreview == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Title", itemreview.ItemID);
            return View(itemreview);
        }

        // POST: Itemreviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemreviewID,ItemID,WrittenReview,Grade")] Itemreview itemreview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemreview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Title", itemreview.ItemID);
            return View(itemreview);
        }

        // GET: Itemreviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Itemreview itemreview = db.Itemreviews.Find(id);
            if (itemreview == null)
            {
                return HttpNotFound();
            }
            return View(itemreview);
        }

        // POST: Itemreviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Itemreview itemreview = db.Itemreviews.Find(id);
            db.Itemreviews.Remove(itemreview);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LHLK22CNT3Lesson11_2210900037.Models;

namespace LHLK22CNT3Lesson11_2210900037.Controllers
{
    public class LHLProductsController : Controller
    {
        private LhlK22CNT3_Lesson11Entities db = new LhlK22CNT3_Lesson11Entities();

        // GET: LHLProducts
        public ActionResult LhlIndex()
        {
            var lHLProducts = db.LHLProducts.Include(l => l.LHLCategory);
            return View(lHLProducts.ToList());
        }

        // GET: LHLProducts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLProduct lHLProduct = db.LHLProducts.Find(id);
            if (lHLProduct == null)
            {
                return HttpNotFound();
            }
            return View(lHLProduct);
        }

        // GET: LHLProducts/Create
        public ActionResult Create()
        {
            ViewBag.LhlCateId = new SelectList(db.LHLCategories, "LhlId", "LhlCateName");
            return View();
        }

        // POST: LHLProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LhlId2210900037,LhlProName,LhlQty,LhlPrice,LhlCateId,LhlActive")] LHLProduct lHLProduct)
        {
            if (ModelState.IsValid)
            {
                db.LHLProducts.Add(lHLProduct);
                db.SaveChanges();
                return RedirectToAction("LhlIndex");
            }

            ViewBag.LhlCateId = new SelectList(db.LHLCategories, "LhlId", "LhlCateName", lHLProduct.LhlCateId);
            return View(lHLProduct);
        }

        // GET: LHLProducts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLProduct lHLProduct = db.LHLProducts.Find(id);
            if (lHLProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.LhlCateId = new SelectList(db.LHLCategories, "LhlId", "LhlCateName", lHLProduct.LhlCateId);
            return View(lHLProduct);
        }

        // POST: LHLProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LhlId2210900037,LhlProName,LhlQty,LhlPrice,LhlCateId,LhlActive")] LHLProduct lHLProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lHLProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LhlIndex");
            }
            ViewBag.LhlCateId = new SelectList(db.LHLCategories, "LhlId", "LhlCateName", lHLProduct.LhlCateId);
            return View(lHLProduct);
        }

        // GET: LHLProducts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLProduct lHLProduct = db.LHLProducts.Find(id);
            if (lHLProduct == null)
            {
                return HttpNotFound();
            }
            return View(lHLProduct);
        }

        // POST: LHLProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LHLProduct lHLProduct = db.LHLProducts.Find(id);
            db.LHLProducts.Remove(lHLProduct);
            db.SaveChanges();
            return RedirectToAction("LhlIndex");
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

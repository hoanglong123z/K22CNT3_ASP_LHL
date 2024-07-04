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
    public class LHLCategoriesController : Controller
    {
        private LhlK22CNT3_Lesson11Entities db = new LhlK22CNT3_Lesson11Entities();

        // GET: LHLCategories
        public ActionResult LHLIndex()
        {
            return View(db.LHLCategories.ToList());
        }

        // GET: LHLCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLCategory lHLCategory = db.LHLCategories.Find(id);
            if (lHLCategory == null)
            {
                return HttpNotFound();
            }
            return View(lHLCategory);
        }

        // GET: LHLCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LHLCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LhlId,LhlCateName,LhlStatus")] LHLCategory lHLCategory)
        {
            if (ModelState.IsValid)
            {
                db.LHLCategories.Add(lHLCategory);
                db.SaveChanges();
                return RedirectToAction("LHLIndex");
            }

            return View(lHLCategory);
        }

        // GET: LHLCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLCategory lHLCategory = db.LHLCategories.Find(id);
            if (lHLCategory == null)
            {
                return HttpNotFound();
            }
            return View(lHLCategory);
        }

        // POST: LHLCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LhlId,LhlCateName,LhlStatus")] LHLCategory lHLCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lHLCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LHLIndex");
            }
            return View(lHLCategory);
        }

        // GET: LHLCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLCategory lHLCategory = db.LHLCategories.Find(id);
            if (lHLCategory == null)
            {
                return HttpNotFound();
            }
            return View(lHLCategory);
        }

        // POST: LHLCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LHLCategory lHLCategory = db.LHLCategories.Find(id);
            db.LHLCategories.Remove(lHLCategory);
            db.SaveChanges();
            return RedirectToAction("LHLIndex");
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

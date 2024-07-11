using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeHoangLong_2210900037.Models;

namespace LeHoangLong_2210900037.Controllers
{
    public class Lhl_TacGiaController : Controller
    {
        private LeHoangLong_2210900037Entities db = new LeHoangLong_2210900037Entities();

        // GET: Lhl_TacGia
        public ActionResult LHLIndex()
        {
            return View(db.Lhl_TacGia.ToList());
        }

        // GET: Lhl_TacGia/Details/5
        public ActionResult LHLDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lhl_TacGia lhl_TacGia = db.Lhl_TacGia.Find(id);
            if (lhl_TacGia == null)
            {
                return HttpNotFound();
            }
            return View(lhl_TacGia);
        }

        // GET: Lhl_TacGia/Create
        public ActionResult LHLCreate()
        {
            return View();
        }

        // POST: Lhl_TacGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LHLCreate([Bind(Include = "Lhl_MaTG,Lhl_TenTG")] Lhl_TacGia lhl_TacGia)
        {
            if (ModelState.IsValid)
            {
                db.Lhl_TacGia.Add(lhl_TacGia);
                db.SaveChanges();
                return RedirectToAction("LHLIndex");
            }

            return View(lhl_TacGia);
        }

        // GET: Lhl_TacGia/Edit/5
        public ActionResult LHLEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lhl_TacGia lhl_TacGia = db.Lhl_TacGia.Find(id);
            if (lhl_TacGia == null)
            {
                return HttpNotFound();
            }
            return View(lhl_TacGia);
        }

        // POST: Lhl_TacGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LHLEdit([Bind(Include = "Lhl_MaTG,Lhl_TenTG")] Lhl_TacGia lhl_TacGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lhl_TacGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LHLIndex");
            }
            return View(lhl_TacGia);
        }

        // GET: Lhl_TacGia/Delete/5
        public ActionResult LHLDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lhl_TacGia lhl_TacGia = db.Lhl_TacGia.Find(id);
            if (lhl_TacGia == null)
            {
                return HttpNotFound();
            }
            return View(lhl_TacGia);
        }

        // POST: Lhl_TacGia/Delete/5
        [HttpPost, ActionName("LHLDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LHLDeleteConfirmed(string id)
        {
            Lhl_TacGia lhl_TacGia = db.Lhl_TacGia.Find(id);
            db.Lhl_TacGia.Remove(lhl_TacGia);
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

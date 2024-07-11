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
    public class Lhl_SachController : Controller
    {
        private LeHoangLong_2210900037Entities db = new LeHoangLong_2210900037Entities();

        // GET: Lhl_Sach
        public ActionResult LHLIndex()
        {
            var lhl_Sach = db.Lhl_Sach.Include(l => l.Lhl_TacGia);
            return View(lhl_Sach.ToList());
        }

        // GET: Lhl_Sach/Details/5
        public ActionResult LHLDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lhl_Sach lhl_Sach = db.Lhl_Sach.Find(id);
            if (lhl_Sach == null)
            {
                return HttpNotFound();
            }
            return View(lhl_Sach);
        }

        // GET: Lhl_Sach/Create
        public ActionResult LHLCreate()
        {
            ViewBag.Lhl_MaTG = new SelectList(db.Lhl_TacGia, "Lhl_MaTG", "Lhl_TenTG");
            return View();
        }

        // POST: Lhl_Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LHLCreate([Bind(Include = "Lhl_MaSach,Lhl_TenSach,Lhl_SoTrang,Lhl_NamXB,Lhl_MaTG,Lhl_TrangThai")] Lhl_Sach lhl_Sach)
        {
            if (ModelState.IsValid)
            {
                db.Lhl_Sach.Add(lhl_Sach);
                db.SaveChanges();
                return RedirectToAction("LHLIndex");
            }

            ViewBag.Lhl_MaTG = new SelectList(db.Lhl_TacGia, "Lhl_MaTG", "Lhl_TenTG", lhl_Sach.Lhl_MaTG);
            return View(lhl_Sach);
        }

        // GET: Lhl_Sach/Edit/5
        public ActionResult LHLEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lhl_Sach lhl_Sach = db.Lhl_Sach.Find(id);
            if (lhl_Sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lhl_MaTG = new SelectList(db.Lhl_TacGia, "Lhl_MaTG", "Lhl_TenTG", lhl_Sach.Lhl_MaTG);
            return View(lhl_Sach);
        }

        // POST: Lhl_Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LHLEdit([Bind(Include = "Lhl_MaSach,Lhl_TenSach,Lhl_SoTrang,Lhl_NamXB,Lhl_MaTG,Lhl_TrangThai")] Lhl_Sach lhl_Sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lhl_Sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LHLIndex");
            }
            ViewBag.Lhl_MaTG = new SelectList(db.Lhl_TacGia, "Lhl_MaTG", "Lhl_TenTG", lhl_Sach.Lhl_MaTG);
            return View(lhl_Sach);
        }

        // GET: Lhl_Sach/Delete/5
        public ActionResult LHLDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lhl_Sach lhl_Sach = db.Lhl_Sach.Find(id);
            if (lhl_Sach == null)
            {
                return HttpNotFound();
            }
            return View(lhl_Sach);
        }

        // POST: Lhl_Sach/Delete/5
        [HttpPost, ActionName("LHLDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LHLDeleteConfirmed(string id)
        {
            Lhl_Sach lhl_Sach = db.Lhl_Sach.Find(id);
            db.Lhl_Sach.Remove(lhl_Sach);
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

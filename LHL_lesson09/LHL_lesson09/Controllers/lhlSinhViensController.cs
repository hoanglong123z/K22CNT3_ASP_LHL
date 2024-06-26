using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LHL_lesson09.Models;

namespace LHL_lesson09.Controllers
{
    public class lhlSinhViensController : Controller
    {
        private Lesson09Entities1 db = new Lesson09Entities1();

        // GET: lhlSinhViens
        public ActionResult LHLIndex()
        {
            var sinhViens = db.SinhViens.Include(s => s.Khoa);
            return View(sinhViens.ToList());
        }

        // GET: lhlSinhViens/Details/5
        public ActionResult LHLDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: lhlSinhViens/Create
        public ActionResult LHLCreate()
        {
            ViewBag.MaKH = new SelectList(db.Khoas, "MaKH", "TenKH");
            return View();
        }

        // POST: lhlSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LHLCreate([Bind(Include = "MaSV,HoSV,TenSV,Phai,NgaySinh,NoiSinh,MaKH,HocBong,DiemTrungBinh")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("LHLIndex");
            }

            ViewBag.MaKH = new SelectList(db.Khoas, "MaKH", "TenKH", sinhVien.MaKH);
            return View(sinhVien);
        }

        // GET: lhlSinhViens/Edit/5
        public ActionResult LHLEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.Khoas, "MaKH", "TenKH", sinhVien.MaKH);
            return View(sinhVien);
        }

        // POST: lhlSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LHLEdit([Bind(Include = "MaSV,HoSV,TenSV,Phai,NgaySinh,NoiSinh,MaKH,HocBong,DiemTrungBinh")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LHLIndex");
            }
            ViewBag.MaKH = new SelectList(db.Khoas, "MaKH", "TenKH", sinhVien.MaKH);
            return View(sinhVien);
        }

        // GET: lhlSinhViens/Delete/5
        public ActionResult LHLDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: lhlSinhViens/Delete/5
        [HttpPost, ActionName("LHLDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LHLDeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
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

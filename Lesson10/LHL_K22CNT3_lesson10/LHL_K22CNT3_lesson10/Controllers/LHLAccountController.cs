using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LHL_K22CNT3_lesson10.Models;

namespace LHL_K22CNT3_lesson10.Controllers
{
    public class LHLAccountController : Controller
    {
        private LHLK22CNT3_Ls10Entities1 db = new LHLK22CNT3_Ls10Entities1();

        // GET: LHLAccount
        public ActionResult Index()
        {
            return View(db.LhlAccounts.ToList());
        }

        // GET: LHLAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LhlAccount lhlAccount = db.LhlAccounts.Find(id);
            if (lhlAccount == null)
            {
                return HttpNotFound();
            }
            return View(lhlAccount);
        }

        // GET: LHLAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LHLAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LhlId,LhlUserName,LhlPassword,LhlFullName,LhlEmail,LhlPhone,LhlActive")] LhlAccount lhlAccount)
        {
            if (ModelState.IsValid)
            {
                db.LhlAccounts.Add(lhlAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lhlAccount);
        }

        // GET: LHLAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LhlAccount lhlAccount = db.LhlAccounts.Find(id);
            if (lhlAccount == null)
            {
                return HttpNotFound();
            }
            return View(lhlAccount);
        }

        // POST: LHLAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LhlId,LhlUserName,LhlPassword,LhlFullName,LhlEmail,LhlPhone,LhlActive")] LhlAccount lhlAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lhlAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lhlAccount);
        }

        // GET: LHLAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LhlAccount lhlAccount = db.LhlAccounts.Find(id);
            if (lhlAccount == null)
            {
                return HttpNotFound();
            }
            return View(lhlAccount);
        }

        // POST: LHLAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LhlAccount lhlAccount = db.LhlAccounts.Find(id);
            db.LhlAccounts.Remove(lhlAccount);
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

        public ActionResult LHLlogin()
        {
            var LHLModel = new LhlAccount();
            return View(LHLModel);
        }
        [HttpPost]
        public ActionResult LHLlogin(LhlAccount lhlAccount)
        {
            var lhlcheck = db.LhlAccounts.Where(x => x.LhlUserName.Equals(lhlAccount.LhlUserName) && x.LhlPassword.Equals(lhlAccount.LhlPassword)).FirstOrDefault();
            if (lhlcheck != null)
            {
                Session["LhlAccount"] = lhlcheck;
                return Redirect("/");
            }
            return View(lhlAccount);
        }
    }
}

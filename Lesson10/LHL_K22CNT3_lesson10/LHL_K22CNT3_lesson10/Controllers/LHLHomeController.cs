using LHL_K22CNT3_lesson10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LHL_K22CNT3_lesson10.Controllers
{
    public class LHLHomeController : Controller
    {
        public ActionResult LHLIndex()
        {
            if(Session["LhlAccount"] != null)
            {
                var lhlAccount = Session["LhlAccount"] as LhlAccount;
                ViewBag.FullName = lhlAccount.LhlFullName;
            }
            return View();
        }

        public ActionResult LHLAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LHLContact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LHLK22CNT3Lesson11_2210900037.Controllers
{
    public class LHLHomeController : Controller
    {
        public ActionResult LHLIndex()
        {
            return View();
        }

        public ActionResult LHLAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LHLContact()
        {
            ViewBag.msv = "2210900037";
            ViewBag.fullname = "Lê Hoàng Long";
            return View();
        }
    }
}
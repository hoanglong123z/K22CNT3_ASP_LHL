using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHoangLong_2210900037.Controllers
{
    public class LHLHomeController : Controller
    {
        public ActionResult LHLIndex()
        {
            return View();
        }

        public ActionResult LHLAbout()
        {
            ViewBag.Message = "Bài Làm Của Lê Hoàng Long";

            return View();
        }

        public ActionResult LHLContact()
        {
            ViewBag.Message = "Bài Làm Của Lê Hoàng Long";

            return View();
        }
    }
}
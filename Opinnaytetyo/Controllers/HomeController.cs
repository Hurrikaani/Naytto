using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Opinnaytetyo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string date = String.Format("{0:D}", DateTime.Now);
            ViewBag.Date = date;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Youtube()
        {
            return View();
        }
    }
}
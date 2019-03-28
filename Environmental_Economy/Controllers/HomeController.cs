using EnvironmentalEconomy.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Environmental_Economy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //FirebaseDB db = new FirebaseDB("https://andrfire-89083.firebaseio.com/");
            //var fbrespond = db.Node("UserCount").Node("TK001").Get();

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
    }
}
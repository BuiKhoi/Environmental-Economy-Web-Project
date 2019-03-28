using Environmental_Economy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Environmental_Economy.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLocationDesc(Scope scope)
        {
            //Process the values

            var av = new AirValue(1.23, 3.45, 5.67);
            return Json(av);
        } 
    }
}
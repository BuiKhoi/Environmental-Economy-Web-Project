using Environmental_Economy.Models;
using EnvironmentalEconomy.Models;
using EnvironmentalEconomy.Models.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Environmental_Economy.Controllers
{
    public class HomeController : Controller
    {
        List<ResultDbModel> results = new List<ResultDbModel>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Map()
        {
            FirebaseDB db = new FirebaseDB("https://andrfire-89083.firebaseio.com/");
            var fbrespond = db.Node("UserResult").Get();
            var RespondResult = JsonConvert.DeserializeObject
                <Dictionary<string, Dictionary<string, UserResult>>>(fbrespond.JSONContent);
            foreach (var item in RespondResult)
            {
                var rst = new ResultDbModel(item.Key);
                var val = item.Value;
                foreach (var result in val)
                {
                    if (result.Value != null)
                    {
                        //result.Value.Date = DateTime.Parse(result.Key);
                        rst.Results.Add(result.Value);
                    }
                }
                results.Add(rst);
            }

            return View(results);
        }

        [HttpGet]
        public ActionResult LocationDetails(Scope scope)
        {
            var ldvm = new LocationDetailViewModel();
            if (!scope.CheckNullScope())
            {
                ldvm.scope = scope;
            }
            ldvm.Results = results;
            return View(ldvm);
        }

        public ActionResult Debug()
        {
            return View();
        }
    }
}
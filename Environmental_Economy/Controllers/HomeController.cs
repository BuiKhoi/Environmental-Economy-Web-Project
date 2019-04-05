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
            List<ResultDbModel> results = new List<ResultDbModel>();
            var RespondResult = JsonConvert.DeserializeObject
                <Dictionary<string, Dictionary<string, UserResult>>>(fbrespond.JSONContent);
            foreach (var item in RespondResult)
            {
                var rst = new ResultDbModel(item.Key);
                int count = 0;
                foreach (var result in item.Value.Values)
                {
                    if (result != null)
                    {
                        result.TokenId = item.Key;
                        result.ResultId = count++;
                        rst.Results.Add(result);
                    }
                }
                results.Add(rst);
            }

            return View(results);
        }

        [HttpGet]
        public ActionResult LocationDetails(Scope scope)
        {
            return View();
        }

        public ActionResult Debug()
        {
            return View();
        }
    }
}
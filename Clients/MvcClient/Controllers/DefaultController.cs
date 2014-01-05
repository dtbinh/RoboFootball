using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            using (var client = new AnalyticsSvc.AnalyticsClient())
            {
                ViewBag.Message = client.GetData(10);
            }
            return View();
        }

    }
}

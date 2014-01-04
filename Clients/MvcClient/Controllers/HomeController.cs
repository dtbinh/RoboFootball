using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TODO: Call wcf from mvc :1. with http binding, 2. with pipe binding
            Create interfaces for each and every module

            Currently mvc client and one of pplatform services are deployed

            using (var client = new AnalyticsClient())
            {
                ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

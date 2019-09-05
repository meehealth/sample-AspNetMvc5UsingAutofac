using AspNetMvc5WithoutIdentity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5WithoutIdentity.Controllers
{
    public class HomeController : Controller
    {
        IDateTimeService _dateTimeService;
        public HomeController(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }
        public ActionResult Index()
        {
            ViewBag.DateTime = _dateTimeService.GetDateTime();
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
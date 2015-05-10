using System;
using System.Linq;
using System.Web.Mvc;

namespace SciaSquash.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please do not hesitate to contact us :)";

            return View();
        }
    }
}
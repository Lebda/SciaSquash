using System;
using System.Linq;
using System.Web.Mvc;

namespace SciaSquash.Web.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Please do not hesitate to contact us :)";

            return View();
        }
    }
}
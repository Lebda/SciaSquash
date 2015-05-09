using System;
using System.Linq;
using System.Web.Mvc;
using SciaSquash.Model.Abstract;

namespace SciaSquash.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IPlayerReposiroty repo)
        {
            m_playersRepo = repo;
        }

        #region MEMBERS
        private readonly IPlayerReposiroty m_playersRepo;
        #endregion

        public ActionResult Index()
        {
            ViewBag.PlayerReposiroty = m_playersRepo;
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
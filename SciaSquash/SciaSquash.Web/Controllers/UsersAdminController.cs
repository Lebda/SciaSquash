using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace SciaSquash.Web.Controllers
{
    public class UsersAdminController : Controller
    {
        // GET: UsersAdmin
        public ActionResult Index()
        {
            return View(UserManager.Users.ToList());
        }

        private ApplicationUserManager m_userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return m_userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                m_userManager = value;
            }
        }
    }
}
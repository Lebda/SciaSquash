using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdenityHelp.Controllers;
using IdenityHelp.ViewModels.Roles;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SciaSquash.Web.Models;

namespace SciaSquash.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RolesAdminController : RolesAdminControllerBase<ApplicationUser, ApplicationRole, RoleViewModel>
    {
        public RolesAdminController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
            : base()
        {
            m_userManager = userManager;
            m_roleManager = roleManager;
        }

        public RolesAdminController()
            : base()
        {
        }

        #region MEMBERS
        private ApplicationUserManager m_userManager;
        private ApplicationRoleManager m_roleManager;
        #endregion


        #region PROPERTIES
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return m_roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                m_roleManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return m_userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                m_userManager = value;
            }
        }
        #endregion

        // GET: RolesAdmin
        public ActionResult Index()
        {
            base.AttachData(UserManager, RoleManager);
            return IndexBase(item => new RoleViewModel { Id = item.Id, Name = item.Name, Description = item.Description });
        }

    }
}
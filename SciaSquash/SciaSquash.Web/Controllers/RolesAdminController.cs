using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using IdenityHelp.Controllers;
using IdenityHelp.Infrastrucutre;
using IdenityHelp.ViewModels.Roles;
using MVCHelp.Concrete;
using SciaSquash.Web.Models;

namespace SciaSquash.Web.Controllers
{
    [AuthorizeRoles(RoleNames.c_architectRoleName, RoleNames.c_adminRoleName)]
    public class RolesAdminController : RolesAdminControllerBase<ApplicationRoleManager, ApplicationRole, ApplicationUserManager, ApplicationUser, RoleViewModel>
    {
        public RolesAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
            : base(userManager, roleManager, CreateViewModel, CreateModel, UpdateModel, UpdateViewModel)
        {
        }
        public RolesAdminController()
            : base(CreateViewModel, CreateModel, UpdateModel, UpdateViewModel)
        {
        }
        
        #region NECCESARY METHODS
        static RoleViewModel CreateViewModel()
        {
            return new RoleViewModel();
        }
        static ApplicationRole CreateModel()
        {
            return new ApplicationRole();
        }
        static void UpdateViewModel(ApplicationRole model, RoleViewModel viewModel4Update)
        {
            viewModel4Update.Id = model.Id;
            viewModel4Update.Name = model.Name;
            viewModel4Update.Description = model.Description;
        }
        static void UpdateModel(RoleViewModel viewModel, ApplicationRole model4Update)
        {
            model4Update.Name = viewModel.Name;
            model4Update.Description = viewModel.Description;
        }
        #endregion

        #region ACTIONS
        public ActionResult Index()
        {
            return IndexBase();
        }
        public Task<ActionResult> Details(string id)
        {
            return base.DetailsBase(id);
        }
        public Task<ActionResult> Edit(string id)
        {
            return base.EditBase(id);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> EditPost(string id)
        {
            return base.EditPostBase(id, null, "Name", "Id", "Description");
        }
        public ActionResult Create()
        {
            return base.CreateBase();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> Create([Bind(Include = "Name, Id, Description")] RoleViewModel viewModel)
        {
            return base.CreateBase(viewModel);
        }
        public Task<ActionResult> Delete(string id)
        {
            return base.DeleteBase(id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> DeleteConfirmed(string id)
        {
            return base.DeleteConfirmedBase(id);
        }
        #endregion


    }
}
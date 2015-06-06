using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using IdenityHelp.Controllers;
using IdenityHelp.Infrastrucutre;
using MVCHelp.Concrete;
using SciaSquash.Web.Models;
using SciaSquash.Web.ViewModels.Users;

namespace SciaSquash.Web.Controllers
{
    [AuthorizeRoles(RoleNames.c_architectRoleName, RoleNames.c_adminRoleName)]
    public class UsersAdminController : UsersAdminControllerBase<ApplicationRoleManager, ApplicationRole, ApplicationUserManager, ApplicationUser>
    {
        public UsersAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
            : base(userManager, roleManager)
        {
        }
        public UsersAdminController()
            : base()
        {
        }
        
        #region NECCESARY METHODS
        static void UpdateModel(EditUserViewModel viewModel, ApplicationUser model4Update)
        {
            model4Update.UserName = viewModel.Email;
            model4Update.Email = viewModel.Email;
        }
        EditUserViewModel UpdateAndCreateViewModel(ApplicationUser model, IList<string> userRoles)
        {
            var retVal = new EditUserViewModel();
            retVal.Id = model.Id;
            retVal.Email = model.Email;
            if (userRoles != null)
            {
                retVal.RolesList = GetRoles4Aplication().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                });   
            }
            return retVal;
        }
        IndexUserViewModel UpdateAndCreateIndexViewModel(ApplicationUser model, IList<string> userRoles)
        {
            var retVal = new IndexUserViewModel();
            retVal.Id = model.Id;
            retVal.UserName = model.UserName;
            retVal.Role4User = userRoles;
            return retVal;
        }
        static ApplicationUser UpdateAndCreateModel(RegisterViewModel viewModel)
        {
            var retVal = new ApplicationUser();
            retVal.UserName = viewModel.Email;
            retVal.Email = viewModel.Email;
            return retVal;
        }
        #endregion
        
        #region ACTIONS
        public Task<ActionResult> Index()
        {
            return base.IndexBase<IndexUserViewModel>(UpdateAndCreateIndexViewModel);
        }
        public Task<ActionResult> Details(string id)
        {
            return base.DetailsBase(id);
        }
        [AuthorizeRoles(RoleNames.c_architectRoleName)]
        public Task<ActionResult> Edit(string id)
        {
            return base.EditBase(id, UpdateAndCreateViewModel);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RoleNames.c_architectRoleName)]
        public Task<ActionResult> EditPost(string id, params string[] selectedRole)
        {
            return base.EditPostBase<EditUserViewModel>(id, UpdateModel, ()=> new EditUserViewModel(), selectedRole, null, "Email", "Id");
        }
        [AuthorizeRoles(RoleNames.c_architectRoleName)]
        public Task<ActionResult> Create()
        {
            return base.CreateBase();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RoleNames.c_architectRoleName)]
        public Task<ActionResult> Create([Bind(Include = "Email, Password, ConfirmPassword")] RegisterViewModel viewModel, params string[] selectedRoles)
        {
            return base.CreateBase(viewModel, viewModel.Password, UpdateAndCreateModel, selectedRoles, null);
        }
        [AuthorizeRoles(RoleNames.c_architectRoleName)]
        public Task<ActionResult> Delete(string id)
        {
            return base.DeleteBase(id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RoleNames.c_architectRoleName)]
        public Task<ActionResult> DeleteConfirmed(string id)
        {
            return base.DeleteConfirmedBase(id);
        }
        #endregion
    }
}
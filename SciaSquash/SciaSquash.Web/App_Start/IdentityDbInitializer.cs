using System.Data.Entity;
using System.Web;
using IdenityHelp.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SciaSquash.Web.DataContexts;
using SciaSquash.Web.Models;

namespace SciaSquash.Web.App_Start
{
    public class IdentityDbInitializer : CreateDatabaseIfNotExists<IdentityDb > //DropCreateDatabaseIfModelChanges DropCreateDatabaseAlways
    {
        protected override void Seed(IdentityDb  context)
        {
            InitializeIdentityForEF();
            base.Seed(context);
        }
        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF()
        {
            if ( HttpContext.Current == null)
            {
                return;
            }
            IOwinContext owin = HttpContext.Current.GetOwinContext();
            if (owin == null)
            {
                return;
            }
            var userManager = owin.GetUserManager<ApplicationUserManager>();
            if (userManager == null)
            {
                return;
            }
            var roleManager = owin.Get<ApplicationRoleManager>();
            if (roleManager == null)
            {
                return;
            }
            var role = roleManager.FindByName(RoleNames.c_architectRoleName);
            if (role != null)
            {
                return;
            }
            CreateRole(roleManager, RoleNames.c_userRoleName, "Website user !");
            CreateRole(roleManager, RoleNames.c_dataMakerRoleName, "Website data creator !");
            var admin = CreateRole(roleManager, RoleNames.c_adminRoleName, "Can modificate data !");
            var architectRole = CreateRole(roleManager, RoleNames.c_architectRoleName, "All privileges !");
            AddUser2Role(userManager, architectRole, "lebsoft@seznam.cz", "Lebda@19810916");
            AddUser2Role(userManager, admin, "admin@example.com", "Admin@123456");
        }
        public static ApplicationRole CreateRole(ApplicationRoleManager manager, string roleName, string description)
        {
            var role = manager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                role.Description = description;
               manager.Create(role);
            }
            return role;
        }
        public static void AddUser2Role(ApplicationUserManager manager, ApplicationRole role, string name, string password)
        {
            ApplicationUser user = manager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                manager.Create(user, password);
                manager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = manager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                 manager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
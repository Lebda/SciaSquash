using System.Data.Entity;
using System.Web;
using IdenityHelp.Infrastrucutre;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SciaSquash.Web.Models;

namespace SciaSquash.Web.App_Start
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> //DropCreateDatabaseIfModelChanges DropCreateDatabaseAlways
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }
        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            IOwinContext owin = HttpContext.Current.GetOwinContext();
            var userManager = owin.GetUserManager<ApplicationUserManager>();
            var roleManager = owin.Get<ApplicationRoleManager>();

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
                var roleresult = manager.Create(role);
            }
            return role;
        }
        public static void AddUser2Role(ApplicationUserManager manager, ApplicationRole role, string name, string password)
        {
            ApplicationUser user = manager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = manager.Create(user, password);
                result = manager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = manager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = manager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
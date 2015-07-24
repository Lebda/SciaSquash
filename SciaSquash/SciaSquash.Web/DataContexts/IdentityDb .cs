using Microsoft.AspNet.Identity.EntityFramework;
using SciaSquash.Web.App_Start;
using SciaSquash.Web.Models;

namespace SciaSquash.Web.DataContexts
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class IdentityDb  : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb ()
            : base("SciasquashAspone", throwIfV1Schema: false)
        {
        }
        static IdentityDb ()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            // I have migrations
            System.Data.Entity.Database.SetInitializer<IdentityDb>(new IdentityDbInitializer());
        }
        public static IdentityDb  Create()
        {
            return new IdentityDb ();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("identity");
            base.OnModelCreating(modelBuilder);
        }
    }
}
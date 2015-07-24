namespace SciaSquash.Web.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SciaSquash.Web.DataContexts.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\IdentityMigrations";
        }

        protected override void Seed(SciaSquash.Web.DataContexts.IdentityDb context)
        {
            //  This method will be called after migrating to the latest version.
           // IdentityDbInitializer.InitializeIdentityForEF();
        }
    }
}

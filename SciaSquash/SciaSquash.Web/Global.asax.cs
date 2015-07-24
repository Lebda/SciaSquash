using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SciaSquash.Model.Infrastructure;
using SciaSquash.Web.Infrastructure;

namespace SciaSquash.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // I have migrations
            var intializer = new SciaSquash.Model.Infrastructure.SciaSquashDbInitializer();
            System.Data.Entity.Database.SetInitializer((System.Data.Entity.IDatabaseInitializer<SciaSquashDb>)intializer);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}

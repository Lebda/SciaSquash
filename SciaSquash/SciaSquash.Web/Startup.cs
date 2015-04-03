using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SciaSquash.Web.Startup))]
namespace SciaSquash.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

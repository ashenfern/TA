using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TA.Web.Startup))]
namespace TA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

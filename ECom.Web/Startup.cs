using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECom.Web.Startup))]
namespace ECom.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

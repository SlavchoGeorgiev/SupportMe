using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(SupportMe.Web.Startup))]

namespace SupportMe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}

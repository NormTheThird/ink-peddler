using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InkPeddler.UI.Website.Startup))]
namespace InkPeddler.UI.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

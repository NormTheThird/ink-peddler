using InkPeddler.UI.Website.Security;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InkPeddler.UI.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, System.EventArgs e)
        {
            if (!User.Identity.IsAuthenticated) return;
            var userToken = Common.Helpers.Security.ReadEncryptedCookie("UserToken");
            if (string.IsNullOrEmpty(userToken)) return;
            var cp = new CustomPrincipal(new CustomIdentity(userToken, true));
            Context.User = cp;
            Response.Cookies.Add(Common.Helpers.Security.CreateCookie("UserToken", userToken));
        }
    }
}

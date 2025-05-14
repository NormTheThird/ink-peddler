using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using InkPeddler.Common.Models;
using InkPeddler.UI.Admin.SecurityModels;

namespace InkPeddler.UI.Admin
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var formsAuthCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (string.IsNullOrEmpty(formsAuthCookie?.Value))
                return;

            var formsAuthTicket = FormsAuthentication.Decrypt(formsAuthCookie.Value);
            if (formsAuthTicket == null)
                return;

            var serializedSecurityModelModel = new JavaScriptSerializer().Deserialize<SecurityModel>(formsAuthTicket.UserData);
            var customPrincipal = new CustomPrincipal(new CustomIdentity(serializedSecurityModelModel));
            HttpContext.Current.User = customPrincipal;
        }
    }
}
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;
using InkPeddler.UI.Admin.SecurityModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace InkPeddler.UI.Admin.Controllers
{
    public class SecurityController : Controller
    {
        public IAccountService AccountService { get; private set; }
        public ISecurityService SecurityService { get; private set; }

        public SecurityController()
        {
            this.AccountService = new AccountService();
            this.SecurityService = new SecurityService();
        }

        public ActionResult Index(string resetId)
        {
            if (Request.IsAuthenticated)
            {
                if (((CustomPrincipal)User).IsSystemAdmin())
                    return RedirectToAction("Index", "Dashboard");
                return RedirectToAction("Index", "AccountUser");
            }

            @ViewBag.ResetId = resetId;
            return View();
        }

        [HttpPost]
        public ActionResult ValidateAccount(ValidateAccountRequest request)
        {
            var validateAccountResponse = this.SecurityService.ValidateAccount(request);
            if (!validateAccountResponse.IsSuccess) return Json(validateAccountResponse);

            var securityModel = validateAccountResponse.SecurityModel;
            var userData = new JavaScriptSerializer().Serialize(securityModel);
            var formsAuthTicket = new FormsAuthenticationTicket(1, request.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
            var encryptedFormsAuthonTicket = FormsAuthentication.Encrypt(formsAuthTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedFormsAuthonTicket) { HttpOnly = true, Secure = Request.IsSecureConnection };
            Response.Cookies.Set(cookie);
            return Json(validateAccountResponse);
        }

        [HttpPost]
        public ActionResult ValidatePasswordReset(ValidatePasswordResetRequest request)
        {
            var response = this.SecurityService.ValidatePasswordReset(request);
            return Json(response);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Security");
        }
    }
}
using InkPeddler.Common.Helpers;
using InkPeddler.Common.Models;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.UI.Website.Security;
using InkPeddler.UI.Website.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using InkPeddler.Common.Enums;

namespace InkPeddler.UI.Website.Controllers
{
    [Authorize]
    public class AccountController : _BaseController
    {
        public AccountController() { }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        [AllowAnonymous]
        public ActionResult Login(string login, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var model = new LoginViewModel();
            if (!string.IsNullOrEmpty(login)) model.Login = login.Trim();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var response = ServiceGet<ValidateAccountResponse, ValidateAccountRequest>("Account/ValidateAccount", new ValidateAccountRequest { Login = model.Login, Password = model.Password });
                if (response.IsSuccess)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                    var customPrincipal = new CustomPrincipal(new CustomIdentity(model.Login, model.Password));
                    HttpContext.User = customPrincipal;
                    var customIdentity = (CustomIdentity)customPrincipal.Identity;

                    if(customIdentity.Id == Guid.Empty) return RedirectToAction("Login", "Account", new { Login = model.Login });
                    Response.Cookies.Add(Common.Helpers.Security.CreateCookie("UserToken", (customIdentity).UserToken));
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        return Redirect(returnUrl);

                    else return RedirectToAction("Index", "Home", new { @id = customIdentity.Id.ToString() });
                }
                ModelState.AddModelError("", response.ErrorMessage);
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult CreatePassword(string id)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePassword(CreatePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var request = new RegisterAccountRequest { Email = model.Email, Username = model.Username, Password = model.Password, IsArtist = true};
            var result = ServicePost<RegisterAccountResponse, RegisterAccountRequest>("Account/RegisterAccount", request);
            //var result = AccountService.RegisterAccount(request);
            if (result.IsSuccess)
            {
                // TODO: Send email thanking them for registering or send email with link so they can activate their account.  We need to decide which one.
                return RedirectToAction("Login", "Account", new { email = model.Email });
            }
            ModelState.AddModelError("", result.ErrorMessage);
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var resetId = Guid.NewGuid();
            var response = ServiceGet<PasswordResetResponse, PasswordResetRequest>("Account/PasswordReset", new PasswordResetRequest { Email = model.Email });
            // var response = AccountService.PasswordReset(new PasswordResetRequest { Email = model.Email, ResetId = resetId });
            if (response.IsSuccess)
            {
                var longUrl = Request.Url.GetLeftPart(UriPartial.Authority).Trim() + "/Account/ResetPassword?id=" + resetId.ToString();
                var shortenUrl = Bitly.Shorten(longUrl);
                var emailResponse = ServiceGet<SendEmailResponse, SendResetEmailRequest>("Message/SendResetEmail", new SendResetEmailRequest { Recipient = model.Email, Url = shortenUrl });
                //var emailResponse = MessagingService.SendResetEmail(new SendResetEmailRequest { Recipient = model.Email, Url = shortenUrl });
                if (emailResponse.IsSuccess) return RedirectToAction("ForgotPasswordConfirmation", "Account");
                ModelState.AddModelError("", emailResponse.ErrorMessage);
            }
            else ModelState.AddModelError("", response.ErrorMessage);
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string id)
        {
            if (string.IsNullOrEmpty(id)) return View("Error");
            var model = new ResetPasswordViewModel { ResetId = id };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel _model)
        {
            if (!ModelState.IsValid) return View(_model);
            var response = ServiceGet<ValidatePasswordResetResponse, ValidatePasswordResetRequest>("Account/ValidatePasswordReset", new ValidatePasswordResetRequest { ResetId = Guid.Parse(_model.ResetId), NewPassword = _model.Password });
            //var response = AccountService.ValidatePasswordReset(new ValidatePasswordResetRequest { ResetId = Guid.Parse(_model.ResetId), NewPassword = _model.Password });
            if (response.IsSuccess) return RedirectToAction("ResetPasswordConfirmation", "Account");
            ModelState.AddModelError("", response.ErrorMessage);
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.RemoveAll();
            Response.Cookies["UserToken"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login", "Account");
        }
    }
}
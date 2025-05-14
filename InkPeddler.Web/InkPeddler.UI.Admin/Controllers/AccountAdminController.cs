using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;
using System.Web.Mvc;

namespace InkPeddler.UI.Admin.Controllers
{
    [Authorize]
    public class AccountAdminController : BaseController
    {
        public IAccountService AccountService { get; }
        public IMessagingService MessagingService { get; }
        public ISecurityService SecurityService { get; }
        public ITattooService TattooService { get; }

        public AccountAdminController()
        {
            this.AccountService = new AccountService();
            this.MessagingService = new MessagingService();
            this.SecurityService = new SecurityService();
            this.TattooService = new TattooService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAccounts(GetAccountsRequest request)
        {
            request.GetActiveAndInactive = true;
            var response = this.AccountService.GetAccounts(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult GetAccount(GetAccountRequest request)
        {
            var response = this.AccountService.GetAccount(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult GetAccountActivity(GetAccountActivityRequest request)
        {
            var response = this.AccountService.GetAccountActivity(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveAccount(SaveAccountRequest request)
        {
            var response = this.AccountService.SaveAccount(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveAccountProfileImage(SaveAccountProfileImageRequest request)
        {
            var response = this.AccountService.SaveAccountProfileImage(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult PasswordReset(PasswordResetRequest request)
        {
            var passwordResetResponse = this.SecurityService.PasswordReset(request);
            if (!passwordResetResponse.IsSuccess) return Json(passwordResetResponse);

            var emailRequest = new SendResetEmailRequest { RecipientEmail = request.Email };
            emailRequest.Url = "CREATE URL";
            var emailResponse = this.MessagingService.SendResetEmail(emailRequest);
            return Json(emailResponse);
        }

        [HttpPost]
        public ActionResult ChangeAccountStatus(ChangeAccountStatusRequest request)
        {
            var response = this.AccountService.ChangeAccountStatus(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult DeleteAccount(DeleteAccountRequest request)
        {
            var response = this.AccountService.DeleteAccount(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveNewPassword(SaveNewPasswordRequest request)
        {
            var response = this.SecurityService.SaveNewPassword(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveNewAccount(RegisterAccountRequest request)
        {
            var response = this.SecurityService.RegisterAccount(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult GetUserUploadedTattoos(GetUserTattoosWithMainImageRequest request)
        {
            var response = this.TattooService.GetUserTattoosWithMainImage(request);
            return Json(response);
        }
    }
}
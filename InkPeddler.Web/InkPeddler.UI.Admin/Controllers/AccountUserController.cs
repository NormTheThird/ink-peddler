using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;
using InkPeddler.UI.Admin.SecurityModels;
using System.Web.Mvc;

namespace InkPeddler.UI.Admin.Controllers
{
    [Authorize]
    public class AccountUserController : Controller
    {
        public IAccountService AccountService { get; }
        public ISecurityService SecurityService { get; }
        public ITattooService TattooService { get; }

        public AccountUserController()
        {
            this.AccountService = new AccountService();
            this.SecurityService = new SecurityService();
            this.TattooService = new TattooService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAccount(GetAccountRequest request)
        {
            request.AccountId = ((CustomIdentity)User.Identity).SecurityModel.Id;
            var response = this.AccountService.GetAccount(request);
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
        public ActionResult SaveNewPassword(SaveNewPasswordRequest request)
        {
            var response = this.SecurityService.SaveNewPassword(request);
            return Json(response);
        }
    }
}
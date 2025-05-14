using System.Web.Mvc;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;

namespace InkPeddler.UI.Admin.Controllers
{
    [Authorize]
    public class BusinessController : Controller
    {
        public IAccountService AccountService { get; }
        public IBusinessService BusinessService { get; }

        public BusinessController()
        {
            this.AccountService = new AccountService();
            this.BusinessService = new BusinessService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetBusinesses(GetBusinessesRequest request)
        {
            request.GetActiveAndInactive = true;
            var response = this.BusinessService.GetBusinesses(request);
            return new JsonResult() { ContentType = "application/json", Data = response, MaxJsonLength = int.MaxValue };
        }

        [HttpPost]
        public ActionResult GetBusiness(GetBusinessRequest request)
        {
            var response = this.BusinessService.GetBusiness(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult GetBusinessAccounts(GetBusinessAccountsRequest request)
        {
            var response = this.BusinessService.GetBusinessAccounts(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveBusiness(SaveBusinessRequest request)
        {
            var response = this.BusinessService.SaveBusiness(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveBusinessImage(SaveBusinessImageRequest request)
        {
            var response = this.BusinessService.SaveBusinessImage(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult GetAccountsNotTiedToABusiness(GetAccountsNotTiedToABusinessRequest request)
        {
            var response = this.AccountService.GetAccountsNotTiedToABusiness(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult AddBusinessAccount(AddBusinessAccountRequest request)
        {
            var response = this.BusinessService.AddBusinessAccount(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult RemoveBusinessAccount(RemoveBusinessAccountRequest request)
        {
            var response = this.BusinessService.RemoveBusinessAccount(request);
            return Json(response);
        }
    }
}
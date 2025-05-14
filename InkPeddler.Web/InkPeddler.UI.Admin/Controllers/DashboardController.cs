using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;
using System.Web.Mvc;

namespace InkPeddler.UI.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IBusinessService BusinessService { get; set; }
        public IDashboardService DashboardService { get; set; }

        public DashboardController()
        {
            this.BusinessService = new BusinessService();
            this.DashboardService = new DashboardService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDashboardTotals(GetDashboardTotalsRequest request)
        {
            var response = this.DashboardService.GetDashboardTotals(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetBusinessLocations(GetBusinessLocationsRequest request)
        {
            var response = this.BusinessService.GetBusinessLocations(request);
            return new JsonResult() { ContentType = "application/json", Data = response, MaxJsonLength = int.MaxValue };
        }
    }
}
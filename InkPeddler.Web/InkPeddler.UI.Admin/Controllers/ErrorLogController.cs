using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;
using System.Web.Mvc;

namespace InkPeddler.UI.Admin.Controllers
{
    [Authorize]
    public class ErrorLogController : Controller
    {
        public ILoggingService LoggingService { get; }

        public ErrorLogController()
        {
            this.LoggingService = new LoggingService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetErrors(GetErrorsRequest request)
        {
            var response = this.LoggingService.GetErrors(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult DeleteError(DeleteErrorRequest request)
        {
            var response = this.LoggingService.DeleteError(request);
            return Json(response);
        }
    }
}
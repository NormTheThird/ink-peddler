using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;
using System.Web.Mvc;

namespace InkPeddler.UI.Admin.Controllers
{
    [Authorize]
    public class StyleController : Controller
    {
        public IStyleService StyleService { get; set; }

        public StyleController()
        {
            this.StyleService = new StyleService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetStyles(GetStylesRequest request)
        {
            request.GetActiveAndInactive = true;
            var response = this.StyleService.GetStyles(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult ChangeStyleStatus(ChangeStyleStatusRequest request)
        {
            var response = this.StyleService.ChangeStyleStatus(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveStyle(SaveStyleRequest request)
        {
            var response = this.StyleService.SaveStyle(request);
            return Json(response);
        }
    }
}
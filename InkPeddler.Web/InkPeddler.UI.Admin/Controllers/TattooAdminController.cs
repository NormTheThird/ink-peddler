using System;
using System.Web.Mvc;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;

namespace InkPeddler.UI.Admin.Controllers
{
    [Authorize]
    public class TattooAdminController : BaseController
    {
        public ITattooService TattooService { get; set; }

        public TattooAdminController()
        {
                this.TattooService = new TattooService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllTattoos(GetAllTattoosRequest request)
        {
            var response = this.TattooService.GetAllTattoos(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult GetTattoo(GetTattooRequest request)
        {
            var response = this.TattooService.GetTattoo(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult GetTattooImages(GetTattooImagesRequest request)
        {
            var response = this.TattooService.GetTattooImages(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult ChangeTattooStatus(ChangeTattooStatusRequest request)
        {
            var response = this.TattooService.ChangeTattooStatus(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveTattoo(SaveTattooRequest request)
        {
            var response = this.TattooService.SaveTattoo(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveTattooImage(SaveTattooImageRequest request)
        {
            var response = this.TattooService.SaveTattooImage(request);
            return Json(response);
        }
    }
}
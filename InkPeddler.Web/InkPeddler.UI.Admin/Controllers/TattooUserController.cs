using System.Web.Mvc;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Services;
using InkPeddler.UI.Admin.SecurityModels;

namespace InkPeddler.UI.Admin.Controllers
{
    [Authorize]
    public class TattooUserController : Controller
    {
        public IBusinessService BusinessService { get; }
        public ITattooService TattooService { get; set; }

        public TattooUserController()
        {
            this.BusinessService = new BusinessService();
            this.TattooService = new TattooService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetUploadedTattoos(GetUploadedTattoosRequest request)
        {
            request.UploadedAccountId = ((CustomIdentity)User.Identity).SecurityModel.Id;
            var response = this.TattooService.GetUploadedTattoos(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult GetBusinessList(GetBusinessListRequest request)
        {
            var response = this.BusinessService.GetBusinessList(request);
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
        public ActionResult SaveTattoo(SaveTattooRequest request)
        {
            request.Tattoo.UploadedByAccountId = ((CustomIdentity)User.Identity).SecurityModel.Id;
            var response = this.TattooService.SaveTattoo(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveTattooImage(SaveTattooImageRequest request)
        {
            var response = this.TattooService.SaveTattooImage(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult SaveAsTattooMainImage(SaveAsTattooMainImageRequest request)
        {
            var response = this.TattooService.SaveAsTattooMainImage(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult DeleteTattooImage(DeleteTattooImageRequest request)
        {
            var response = this.TattooService.DeleteTattooImage(request);
            if(response.IsSuccess)
            {
                // TODO: TREY: 12/21/2018 Delete image from aws;
            }
            return Json(response);
        }

        [HttpPost]
        public ActionResult ChangeTattooStatus(ChangeTattooStatusRequest request)
        {
            var response = this.TattooService.ChangeTattooStatus(request);
            return Json(response);
        }


    }
}
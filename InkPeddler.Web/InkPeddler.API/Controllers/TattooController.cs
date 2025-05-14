using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkPeddler.API.Controllers
{
    public class TattooController
    {
    }

    //[Authorize]
    //[RoutePrefix("api/Tattoo")]
    //public class TattooController : ApiController
    //{
    //    public IStyleService StyleService { get; set; }
    //    public ITattooService TattooService { get; set; }

    //    public TattooController()
    //    {
    //        this.StyleService = new StyleService();
    //        this.TattooService = new TattooService();
    //    }

    //    [HttpPost]
    //    [Route("GetStyles")]
    //    public IHttpActionResult GetStyles(GetStylesRequest request)
    //    {
    //        request.GetActiveAndInactive = false;
    //        var response = this.StyleService.GetStyles(request);
    //        return Json(response);
    //    }

    //    [AllowAnonymous]
    //    [HttpPost]
    //    [Route("GetTattoosPerPageBySearchValue")]
    //    public IHttpActionResult GetTattoosPerPageBySearchValue(GetTattoosPerPageBySearchValueRequest request)
    //    {
    //        var response = this.TattooService.GetTattoosPerPageBySearchValue(request);
    //        return Json(response);
    //    }

    //    [AllowAnonymous]
    //    [HttpPost]
    //    [Route("GetTattoosPerPageWithMainImage")]
    //    public IHttpActionResult GetTattoosPerPageWithMainImage(GetTattoosPerPageWithMainImageRequest request)
    //    {
    //        var response = this.TattooService.GetTattoosPerPageWithMainImage(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("GetArtistTattoosWithMainImage")]
    //    public IHttpActionResult GetArtistTattoosWithMainImage(GetArtistTattoosWithMainImageRequest request)
    //    {
    //        var response = this.TattooService.GetArtistTattoosWithMainImage(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("GetUserTattoosWithMainImage")]
    //    public IHttpActionResult GetUserTattoosWithMainImage(GetUserTattoosWithMainImageRequest request)
    //    {
    //        var response = this.TattooService.GetUserTattoosWithMainImage(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("SaveTattoo")]
    //    public IHttpActionResult SaveTattoo(SaveTattooRequest request)
    //    {
    //        var response = this.TattooService.SaveTattoo(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("SaveTattooImage")]
    //    public IHttpActionResult SaveTattooImage(SaveTattooImageRequest request)
    //    {
    //        var response = this.TattooService.SaveTattooImage(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("SaveTattooTat")]
    //    public IHttpActionResult SaveTattooTat(SaveTattooTatRequest request)
    //    {
    //        var response = this.TattooService.SaveTattooTat(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("GetTattooComments")]
    //    public IHttpActionResult GetTattooComments(GetTattooCommentsRequest request)
    //    {
    //        var response = this.TattooService.GetTattooComments(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("GetTattooComment")]
    //    public IHttpActionResult GetTattooComment(GetTattooCommentRequest request)
    //    {
    //        var response = this.TattooService.GetTattooComment(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("SaveTattooComment")]
    //    public IHttpActionResult SaveTattooComment(SaveTattooCommentRequest request)
    //    {
    //        var response = this.TattooService.SaveTattooComment(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("ChangeTattooStatus")]
    //    public IHttpActionResult ChangeTattooStatus(ChangeTattooStatusRequest request)
    //    {
    //        var response = this.TattooService.ChangeTattooStatus(request);
    //        return Json(response);
    //    }

    //    [HttpPost]
    //    [Route("GetTattooTattedStatus")]
    //    public IHttpActionResult GetTattooTattedStatus(GetTattooTattedStatusRequest request)
    //    {
    //        var response = this.TattooService.GetTattooTattedStatus(request);
    //        return Json(response);
    //    }
    //}
}

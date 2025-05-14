using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkPeddler.API.Controllers
{
    public class BusinessController
    {
    }

    //[Authorize]
    //[RoutePrefix("api/Business")]
    //public class BusinessController : ApiController
    //{
    //    public IBusinessService BusinessService { get; set; }

    //    public BusinessController()
    //    {
    //        this.BusinessService = new BusinessService();
    //    }

    //    [HttpPost]
    //    [Route("GetBusinesses")]
    //    public IHttpActionResult GetBusinesses(GetBusinessesRequest request)
    //    {
    //        return Json(this.BusinessService.GetBusinesses(request));
    //    }

    //    [HttpPost]
    //    [Route("GetBusinessesForLocation")]
    //    public IHttpActionResult GetBusinessesForLocation(GetBusinessesForLocationRequest request)
    //    {
    //        var getBusinessesForLocationResponse = this.BusinessService.GetBusinessesForLocation(request);
    //        var json = Json(getBusinessesForLocationResponse);
    //        return json;
    //    }

    //    [HttpPost]
    //    [Route("GetBusinessAccounts")]
    //    public IHttpActionResult GetBusinessAccounts(GetBusinessAccountsRequest request)
    //    {
    //        return Json(this.BusinessService.GetBusinessAccounts(request));
    //    }

    //    [HttpPost]
    //    [Route("GetBusinessAndAccounts")]
    //    public IHttpActionResult GetBusinessAndArtist(GetBusinessAndAccountsRequest request)
    //    {
    //        var getBusinessAndArtistResponse = this.BusinessService.GetBusinessAndAccounts(request);
    //        var json = Json(getBusinessAndArtistResponse);
    //        return json;
    //    }

    //    [HttpPost]
    //    [Route("GetBusiness")]
    //    public IHttpActionResult GetBusiness(GetBusinessRequest request)
    //    {
    //        return Json(this.BusinessService.GetBusiness(request));
    //    }

    //    [HttpPost]
    //    [Route("SaveBusiness")]
    //    public IHttpActionResult SaveBusiness(SaveBusinessRequest request)
    //    {
    //        return Json(this.BusinessService.SaveBusiness(request));
    //    }
    //}
}

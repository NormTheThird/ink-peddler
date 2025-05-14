using System.Web.Mvc;

namespace InkPeddler.UI.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //TODO: 6/15/2020 FIX THIS
        //[HttpPost]
        //public ActionResult SendContactUsEmail(SendPlainTextEmailRequest request)
        //{
        //    var response = this.MessagingService.SendContactUsEmail(request);
        //    return Json(response);
        //}
    }
}

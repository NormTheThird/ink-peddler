using System.Web.Mvc;

namespace InkPeddler.UI.Website.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Username()
        {
            return View();
        }
    }
}
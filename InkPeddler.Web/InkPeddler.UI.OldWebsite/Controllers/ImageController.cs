using System.Web.Mvc;

namespace InkPeddler.UI.Website.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
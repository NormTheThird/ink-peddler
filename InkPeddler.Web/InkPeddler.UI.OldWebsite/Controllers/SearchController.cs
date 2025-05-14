using System.Web.Mvc;

namespace InkPeddler.UI.Website.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
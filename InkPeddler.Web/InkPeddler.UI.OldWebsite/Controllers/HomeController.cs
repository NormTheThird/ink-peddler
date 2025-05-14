using System.Web.Mvc;

namespace InkPeddler.UI.Website.Controllers
{
    //[Authorize]
    public class HomeController : Controller
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
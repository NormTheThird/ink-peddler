using System.Web.Mvc;

namespace InkPeddler.UI.Website.Controllers
{
    [Authorize]
    public class TattooController : Controller
    {
        public ActionResult Index(string name)
        {
            return View();
        }
    }
}
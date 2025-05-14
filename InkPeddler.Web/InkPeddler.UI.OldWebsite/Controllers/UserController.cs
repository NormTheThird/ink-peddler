using System.Web.Mvc;

namespace InkPeddler.UI.Website.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index(string username)
        {
            return View();
        }
    }
}
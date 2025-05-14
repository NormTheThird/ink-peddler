using System.Web.Mvc;

namespace InkPeddler.UI.Admin.Controllers
{
    public class LogController : Controller
    {
        public ActionResult ErrorLog()
        {
            return View("ErrorLog/Index");
        }

        public ActionResult TattooReviewLog()
        {
            return View("TattooReviewLog/Index");
        }
    }
}
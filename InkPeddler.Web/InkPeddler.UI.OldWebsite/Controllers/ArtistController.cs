using System.Web.Mvc;

namespace InkPeddler.UI.Website.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
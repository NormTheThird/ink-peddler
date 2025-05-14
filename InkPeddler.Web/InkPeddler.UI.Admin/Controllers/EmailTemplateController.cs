using System;
using System.IO;
using System.Web.Mvc;

namespace InkPeddler.UI.Admin.Controllers
{
    public class EmailTemplateController : Controller
    {
        //public ActionResult RegisterAccount()
        //{
        //    ViewBag.IsArtist = true;
        //    ViewBag.Email = "hanischandrew@gmail.com";
        //    return View("RegisterAccount");
        //}

        [HttpGet]
        public string GetRegisterAccountTemplate(bool isArtist, string email)
        {
            return RenderViewToString(this, "~/Views/EmailTemplate/RegisterAccount.cshtml", isArtist, email);
        }

        private static string RenderViewToString(Controller controller, string filePath, bool isArtist, string email)
        {
            try
            {
                controller.ViewData.Model = null;
                controller.ViewBag.IsArtist = isArtist;
                controller.ViewBag.Email = email;
                using (var sw = new StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, filePath);
                    var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
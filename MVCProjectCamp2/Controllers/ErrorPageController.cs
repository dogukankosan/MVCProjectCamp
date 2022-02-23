using System.Web.Mvc;
namespace MVCProjectCamp2.Controllers
{[AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}
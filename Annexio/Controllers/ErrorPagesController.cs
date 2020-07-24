using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class ErrorPagesController : Controller
    {
        // GET: ErrorPages
        public ActionResult Oops()
        {
            return View();
        }
    }
}
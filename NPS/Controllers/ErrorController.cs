//Author: Larson Kremer Vicente

using System.Web.Mvc;

namespace NPS.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            return View("Error");
        }
    }
}
using System.Web.Mvc;

namespace NetDemo.Controllers
{
    //[Authorize]
    [HandleError]
    public class DemoController : Controller
    {
        [HandleError]
        public ActionResult Index()
        {
            ViewBag.Message1 = "this is a ViewBag";
            ViewData["Message2"] = "this is a ViewData";
            return View();
        }

        [HttpGet]
        public string ResultString()
        {
            return "string";
        }

        public ActionResult ResultRedirect()
        {
            return Redirect("https://pluralsight.com");
        }

        public ActionResult ResultNotFound()
        {
            return HttpNotFound();
        }

        public ActionResult ResultCustomStatusCode()
        {
            return new HttpStatusCodeResult(410, "demo 410");
        }
    }
}
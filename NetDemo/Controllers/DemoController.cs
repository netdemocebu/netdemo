using NetDemo.Interfaces.Contract;
using NetDemo.Services;
using System.Web.Mvc;

namespace NetDemo.Controllers
{
    
    //[Authorize]
    [HandleError]
    public class DemoController : Controller
    {
        private IPersonRepository _personRepo;
        public DemoController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

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

        public ActionResult Verification(string token, string email)
        {
            
            var svc = new AuthenticationService(_personRepo);
            var dbToken = svc.GetToken(email);
            if(dbToken.Equals(token))
            {
                //registration success
                return View();
            }

            //registration failed
            return View();
        }
    }
}
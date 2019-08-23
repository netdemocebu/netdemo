using NetDemo.Interfaces.Contract;
using NetDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetDemo.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        // GET: Person
        public ActionResult Index()
        {
            //_personService.GetAllAsync();
            var person = new PersonViewModel()
            {
                LastName = "lastname",
                FirstName = "firstname",
                EmailAddress = "huhubells@example.com",
                Address = "avenir bldg",
                Age = 50,
                IsActive = true,
            };

            return View(person);
        }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;
using NetDemo.Interfaces.Contract;
using NetDemo.ViewModels;

namespace NetDemo.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingService _service;

        public TrainingController(ITrainingService service)
        {
            _service = service;
        }
        // GET: Training
        public ActionResult Index()
        {
            var trainings = _service.GetAllAsync().Result;

            return View(trainings);
        }

        // GET: Training/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Training/Create
        [HttpPost]
        public ActionResult Create(TrainingCreateViewModel model)
        {
            try
            {
                _service.SaveAsync(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Training/Edit/5
        [HttpPost]
        public ActionResult Edit(TrainingUpdateViewModel model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Training/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

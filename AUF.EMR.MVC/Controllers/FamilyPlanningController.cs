using AUF.EMR.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class FamilyPlanningController : Controller
    {
        private readonly IFamilyPlanningService _fpService;

        public FamilyPlanningController(IFamilyPlanningService fpService)
        {
            _fpService = fpService;
        }

        // GET: FamilyPlanningController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FamilyPlanningController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FamilyPlanningController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamilyPlanningController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FamilyPlanningController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FamilyPlanningController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FamilyPlanningController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FamilyPlanningController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

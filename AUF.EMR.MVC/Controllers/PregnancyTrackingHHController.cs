using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.CreateVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class PregnancyTrackingHHController : Controller
    {
        private readonly IPregnancyTrackingHHService _ptHHService;

        public PregnancyTrackingHHController(IPregnancyTrackingHHService ptHHService)
        {
            _ptHHService = ptHHService;
        }

        // GET: PregnancyTrackingHHController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PregnancyTrackingHHController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePregnancyTrackingHHVM model)
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

        // GET: PregnancyTrackingHHController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PregnancyTrackingHHController/Edit/5
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

        // GET: PregnancyTrackingHHController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PregnancyTrackingHHController/Delete/5
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

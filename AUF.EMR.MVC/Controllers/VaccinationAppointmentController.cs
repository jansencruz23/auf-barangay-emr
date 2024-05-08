using AUF.EMR.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class VaccinationAppointmentController : Controller
    {
        private readonly IVaccinationAppointmentService _appointmentService;

        public VaccinationAppointmentController(IVaccinationAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: VaccinationAppointmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VaccinationAppointmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VaccinationAppointmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VaccinationAppointmentController/Create
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

        // GET: VaccinationAppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VaccinationAppointmentController/Edit/5
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

        // GET: VaccinationAppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VaccinationAppointmentController/Delete/5
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

using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.CreateVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class PregnancyAppointmentController : Controller
    {
        private readonly IPregnancyAppointmentService _pregAppointmentService;
        private readonly IPregnancyRecordService _pregRecordService;

        public PregnancyAppointmentController(IPregnancyAppointmentService pregAppointmentService,
            IPregnancyRecordService pregRecordService)
        {
            _pregAppointmentService = pregAppointmentService;
            _pregRecordService = pregRecordService;
        }

        // GET: PregnancyAppointmentController/Create
        public async Task<ActionResult> Create(int recordId, string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo) || recordId == 0)
            {
                return NotFound();
            }

            var existing = await _pregRecordService.Exists(recordId);
            if (!existing)
            {
                return NotFound();
            }

            var model = new CreatePregnancyAppointmentVM
            {
                RecordId = recordId,
                HouseholdNo = householdNo,
            };

            return View(model);
        }

        // POST: PregnancyAppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePregnancyAppointmentVM model)
        {
            if (model == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var appointment = model.PregnancyAppointment;
                await _pregAppointmentService.Add(appointment);
                return RedirectToAction("Details", "PregnancyRecord", new { householdNo = model.HouseholdNo, id = model.RecordId });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: PregnancyAppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PregnancyAppointmentController/Edit/5
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

        // GET: PregnancyAppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PregnancyAppointmentController/Delete/5
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

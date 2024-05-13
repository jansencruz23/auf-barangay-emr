using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
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
        public async Task<ActionResult> Edit(int id, string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo) || id == 0)
            {
                return NotFound();
            }

            var appointment = await _pregAppointmentService.GetPregnancyAppointmentWithDetails(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var model = new EditPregnancyAppointmentVM
            {
                HouseholdNo = householdNo,
                PregnancyAppointment = appointment,
            };

            return View(model);
        }

        // POST: PregnancyAppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditPregnancyAppointmentVM model)
        {
            if (id == 0 || model == null)
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
                await _pregAppointmentService.Update(appointment);
                return RedirectToAction("Details", "PregnancyRecord", new { householdNo = model.HouseholdNo, id = model.PregnancyAppointment.PregnancyRecordId });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: PregnancyAppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, int recordId, string householdNo)
        {
            if (id == 0 || recordId == 0 || string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            try
            {
                var appointment = await _pregAppointmentService.Get(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                await _pregAppointmentService.Delete(appointment);
                return RedirectToAction("Details", "PregnancyRecord", new { householdNo = householdNo, id = recordId });
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}

using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class VaccinationAppointmentController : Controller
    {
        private readonly IVaccinationAppointmentService _appointmentService;
        private readonly IPatientRecordService _patientRecordService;
        private readonly IVaccineService _vaccineService;
        private readonly IVaccinationRecordService _vaccinationRecordService;

        public VaccinationAppointmentController(IVaccinationAppointmentService appointmentService,
            IPatientRecordService patientRecordService,
            IVaccineService vaccineService,
            IVaccinationRecordService vaccinationRecordService)
        {
            _appointmentService = appointmentService;
            _patientRecordService = patientRecordService;
            _vaccineService = vaccineService;
            _vaccinationRecordService = vaccinationRecordService;
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
        public async Task<ActionResult> Create(int recordId, string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _patientRecordService.Exists(recordId);
            if (!existing)
            {
                return NotFound();
            }
            var vaccines = await _vaccineService.GetAll();
            var model = new CreateVaccinationAppointmentVM
            {
                RecordId = recordId,
                Vaccines = vaccines.ToList(),
                HouseholdNo = householdNo
            };

            return View(model);
        }

        // POST: VaccinationAppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateVaccinationAppointmentVM model)
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
                var vaccines = model.Vaccines.Where(v => v.Selected).ToList();
                var vaccinationRecords = new List<VaccinationRecord>();

                foreach (var vaccine in vaccines)
                {
                    var vaccinationRecord = new VaccinationRecord
                    {
                        VaccinationAppointmentId = model.Appointment.Id,
                        VaccineId = vaccine.Id
                    };
                    vaccinationRecords.Add(vaccinationRecord);
                }

                model.Appointment.VaccinationRecords = vaccinationRecords;
                await _appointmentService.Add(model.Appointment);

                return RedirectToAction(nameof(Details), nameof(PatientRecord), new { householdNo = model.HouseholdNo, id = model.RecordId });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: VaccinationAppointmentController/Edit/5
        public async Task<ActionResult> Edit(int id, string householdNo)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetVaccinationAppointmentWithDetails(id);
            var vaccineRecords = await _vaccinationRecordService.GetVaccinationRecordsWithDetails(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var vaccines = await _vaccineService.GetAll();
            var selectedVaccines = new List<Vaccine>();

            foreach (var vaccine in vaccineRecords)
            {
                selectedVaccines.Add(await _vaccineService.Get(vaccine.VaccineId));
            }

            foreach (var vaccine in vaccines)
            {
                if (selectedVaccines.Contains(vaccine))
                {
                    vaccine.Selected = true;
                }
            }
            
            var model = new EditVaccinationAppointmentVM
            {
                HouseholdNo = householdNo,
                Appointment = appointment,
                Vaccines = vaccines.ToList(),
                SelectedVaccines = selectedVaccines,
                PatientId = appointment.PatientRecordId
            };

            return View(model);
        }

        // POST: VaccinationAppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditVaccinationAppointmentVM model)
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
                var appointment = model.Appointment;
                var vaccines = model.Vaccines.Where(v => v.Selected).ToList();
                var prevSelectedVaccines = model.SelectedVaccines;

                await _vaccinationRecordService.DeleteVaccinationRecords(id, prevSelectedVaccines);
                await _vaccinationRecordService.AddVaccinationRecords(id, vaccines);
                await _appointmentService.Update(appointment);

                return RedirectToAction(nameof(Details), nameof(PatientRecord), new { householdNo = model.HouseholdNo, id = model.PatientId });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: VaccinationAppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            try
            {
                var appointment = await _appointmentService.GetVaccinationAppointmentWithDetails(id);
                await _appointmentService.Delete(appointment);

                return RedirectToAction(nameof(Details), nameof(PatientRecord), new { householdNo = householdNo, id = appointment.PatientRecordId }); ;
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}

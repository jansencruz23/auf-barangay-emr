using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using FastReport;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class PatientRecordController : Controller
    {
        private readonly IPatientRecordService _patientRecordService;
        private readonly IHouseholdMemberService _householdMemberService;
        private readonly IHouseholdService _householdService;
        private readonly IVaccinationAppointmentService _vaccinationAppointmentService;
        private readonly IVaccinationRecordService _vaccinationRecordService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PatientRecordController(IPatientRecordService patientRecordService,
            IHouseholdMemberService householdMemberService,
            IHouseholdService householdService,
            IVaccinationAppointmentService vaccinationAppointmentService,
            IVaccinationRecordService vaccinationRecordService,
            IWebHostEnvironment webHostEnvironment)
        {
            _patientRecordService = patientRecordService;
            _householdMemberService = householdMemberService;
            _householdService = householdService;
            _vaccinationAppointmentService = vaccinationAppointmentService;
            _vaccinationRecordService = vaccinationRecordService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PatientRecordController
        public async Task<ActionResult> Index(string householdNo)
        {
            var records = await _patientRecordService.GetPatientRecordsWithDetails(householdNo);
            var model = new PatientRecordVM
            {
                PatientRecords = records,
                HouseholdNo = householdNo
            };

            return View(model);
        }

        // GET: PatientRecordController/Details/5
        public async Task<ActionResult> Details(int id, string householdNo)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var record = await _patientRecordService.GetPatientRecordWithDetails(id);

            if (record == null)
            {
                return NotFound();
            }

            var model = new DetailPatientRecordVM
            {
                HouseholdNo = householdNo,
                PatientRecord = record,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
            };

            return View(model);
        }

        // GET: PatientRecordController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var patientList = await _householdMemberService.GetHouseholdMembersWithDetails(householdNo);

            if (patientList == null)
            {
                return NotFound();
            }

            var model = new CreatePatientRecordVM
            {
                HouseholdNo = householdNo,
                PatientList = patientList
            };

            return View(model);
        }

        // POST: PatientRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePatientRecordVM model)
        {
            if (model == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                model.HouseholdNo = model.HouseholdNo;
                return View();
            }

            try
            {
                var record = model.PatientRecord;
                await _patientRecordService.Add(record);
                return RedirectToAction(nameof(Index), new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: PatientRecordController/Edit/5
        public async Task<ActionResult> Edit(int id, string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo) || id == 0)
            {
                return NotFound();
            }

            var record = await _patientRecordService.GetPatientRecordWithDetails(id);

            if (record == null)
            {
                return NotFound();
            }

            var patientList = await _householdMemberService.GetHouseholdMembersWithDetails(householdNo);
            var model = new EditPatientRecordVM
            {
                PatientList = patientList,
                HouseholdNo = householdNo,
                PatientRecord = record
            };

            return View(model);
        }

        // POST: PatientRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditPatientRecordVM model)
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
                var record = model.PatientRecord;
                await _patientRecordService.Update(record);
                return RedirectToAction(nameof(Details), new { householdNo = model.HouseholdNo, id = model.PatientRecord.Id });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: PatientRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            try
            {
                var patient = await _patientRecordService.GetPatientRecordWithDetails(id);
                if (patient == null)
                {
                    return RedirectToAction("PageNotFound", "Error");
                }

                await _patientRecordService.Delete(patient);
                return RedirectToAction(nameof(Index), new { householdNo = householdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction("Invalid", "Error");
        }

        public async Task<string> Print(string householdNo, int id, int householdMemberId)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return "Household no. is empty";
            }

            try
            {
                var patientRecord = await _patientRecordService.GetPatientRecordForm(id);
                var patientAppointments = (await _patientRecordService.GetPatientRecordWithDetails(id)).VaccinationAppointments;
                var vaccines = await _vaccinationRecordService.GetVaccinesForm(id);
                var vaccineRecords = await _vaccinationRecordService.GetVaccineRecordsForm(id);

                var householdMember = await _householdMemberService.GetHouseholdMemberForm(householdMemberId);  
                var address = (await _householdService.GetHouseholdWithDetails(householdNo)).FullAddress;

                Config.WebMode = true;
                var report = new Report();
                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine(contentRootPath, "Reports", "PatientRecordForm.frx");

                report.Load(path);
                report.RegisterData(patientRecord, "PatientRecord");
                report.RegisterData(patientAppointments, "PatientAppointments");
                report.RegisterData(householdMember, "HouseholdMember");
                report.RegisterData(vaccines, "Vaccine");
                report.RegisterData(vaccineRecords, "VaccinationRecords");

                report.SetParameterValue("HouseholdNo", householdNo);
                report.SetParameterValue("Address", address);

                if (report.Report.Prepare())
                {
                    var pdfExport = new PDFSimpleExport();
                    pdfExport.ShowProgress = true;
                    pdfExport.Subject = "Subject Report";
                    pdfExport.Title = "Report Title";
                    var memoryStream = new MemoryStream();
                    report.Report.Export(pdfExport, memoryStream);
                    report.Dispose();
                    pdfExport.Dispose();
                    memoryStream.Position = 0;

                    return Convert.ToBase64String(memoryStream.ToArray());
                    //return File(memoryStream, "application/pdf", "household.pdf");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

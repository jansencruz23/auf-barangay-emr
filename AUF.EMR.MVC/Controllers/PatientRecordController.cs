using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class PatientRecordController : Controller
    {
        private readonly IPatientRecordService _patientRecordService;
        private readonly IHouseholdMemberService _householdMemberService;

        public PatientRecordController(IPatientRecordService patientRecordService,
            IHouseholdMemberService householdMemberService)
        {
            _patientRecordService = patientRecordService;
            _householdMemberService = householdMemberService;
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
                PatientRecord = record
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

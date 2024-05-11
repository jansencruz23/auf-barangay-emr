using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AUF.EMR.MVC.Controllers
{
    public class PregnancyRecordController : Controller
    {
        private readonly IPregnancyRecordService _pregRecordService;
        private readonly IHouseholdMemberService _householdMemberService;

        public PregnancyRecordController(IPregnancyRecordService pregRecordService,
            IHouseholdMemberService householdMemberService)
        {
            _pregRecordService = pregRecordService;
            _householdMemberService = householdMemberService;
        }

        // GET: PregnancyRecordController
        public async Task<ActionResult> Index(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var records = await _pregRecordService.GetPregnancyRecordsWithDetails(householdNo);

            if (records == null)
            {
                return NotFound();
            }

            var model = new PregnancyRecordVM
            {
                HouseholdNo = householdNo,
                PregnancyRecords = records
            };

            return View(model);
        }

        // GET: PregnancyRecordController/Details/5
        public async Task<ActionResult> Details(int id, string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo) || id == 0)
            {
                return NotFound();
            }

            var record = await _pregRecordService.GetPregnancyRecordWithDetails(id);

            if (record == null)
            {
                return NotFound();
            }

            var model = new DetailPregnancyRecordVM
            {
                HouseholdNo = householdNo,
                PregnancyRecord = record
            };

            return View(model);
        }

        // GET: PregnancyRecordController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var womenList = await _householdMemberService.GetWRAHouseholdMembers(householdNo);
            if (womenList == null)
            {
                return NotFound();
            }

            var model = new CreatePregnancyRecordVM
            {
                Women = womenList,
                HouseholdNo = householdNo
            };

            return View(model);
        }

        // POST: PregnancyRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string householdNo, CreatePregnancyRecordVM model)
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
                var record = model.PregnancyRecord;
                await _pregRecordService.Add(record);
                return RedirectToAction(nameof(Index), new { householdNo = model.HouseholdNo });
            }
            catch
            {
                return View();
            }
        }

        // GET: PregnancyRecordController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PregnancyRecordController/Edit/5
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

        // GET: PregnancyRecordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PregnancyRecordController/Delete/5
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

﻿using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
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
        public async Task<ActionResult> Edit(int id, string householdNo)
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

            var women = await _householdMemberService.GetWRAHouseholdMembers(householdNo);
            var model = new EditPregnancyRecordVM
            {
                HouseholdNo = householdNo,
                PregnancyRecord = record,
                Women = women
            };

            return View(model);
        }

        // POST: PregnancyRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditPregnancyRecordVM model)
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
                var record = model.PregnancyRecord;
                await _pregRecordService.Update(record);
                return RedirectToAction(nameof(Details), new { householdNo = model.HouseholdNo, id = model.PregnancyRecord.Id });
            }
            catch
            {
                return View();
            }
        }

        // POST: PregnancyRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }
            try
            {
                var record = await _pregRecordService.Get(id);
                if (record == null)
                {
                    return NotFound();
                }

                await _pregRecordService.Delete(record);
                return RedirectToAction(nameof(Index), new { householdNo = householdNo });
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
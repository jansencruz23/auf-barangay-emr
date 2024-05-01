using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.FamilyPlanning;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class FamilyPlanningController : Controller
    {
        private readonly IFamilyPlanningService _fpService;
        private readonly IHouseholdMemberService _householdMemberService;

        public FamilyPlanningController(IFamilyPlanningService fpService,
            IHouseholdMemberService householdMemberService)
        {
            _fpService = fpService;
            _householdMemberService = householdMemberService;
        }

        // GET: FamilyPlanningController
        public async Task<ActionResult> Index(string householdNo)
        {
            var records = await _fpService.GetFPRecordsWithDetails(householdNo);
            if (records == null)
            {
                return NotFound();
            }

            var model = new FamilyPlanningVM
            {
                FPRecords = records,
                HouseholdNo = householdNo
            };

            return View(model);
        }

        // GET: FamilyPlanningController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FamilyPlanningController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var model = new CreateFamilyPlanningVM
            {
                HouseholdNo = householdNo,
                WomenHouseholdMember = await _householdMemberService.GetWRAHouseholdMembers(householdNo),
            };

            return View(model);
        }

        // POST: FamilyPlanningController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFamilyPlanningVM model)
        {
            if (model == null)
            {
                return NotFound();
            }


            try
            {
                var fpRecord = model.FPRecord;
                fpRecord.ClientType = model.ClientType;
                fpRecord.MedicalHistory = model.MedicalHistory;
                fpRecord.ObstetricalHistory = model.ObstetricalHistory;
                fpRecord.RisksForSTI = model.RisksForSTI;
                fpRecord.RisksForVAW = model.RisksForVAW;
                fpRecord.PhysicalExamination = model.PhysicalExamination;

                if (fpRecord == null)
                {
                    return NotFound();
                }

                await _fpService.AddFamilyPlanning(fpRecord);

                return RedirectToAction(nameof(Index), "FamilyPlanning");
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View(model);
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

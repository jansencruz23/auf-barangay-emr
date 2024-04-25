using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class PregnancyTrackingController : Controller
    {
        private readonly IPregnancyTrackingService _pregnancyService;
        private readonly IHouseholdMemberService _householdMemberService;

        public PregnancyTrackingController(IPregnancyTrackingService pregnancyService,
            IHouseholdMemberService householdMemberService)
        {
            _pregnancyService = pregnancyService;
            _householdMemberService = householdMemberService;
        }

        // GET: PregnancyTrackingController
        public async Task<ActionResult> Index(string householdNo)
        {
            var pregnancyList = await _pregnancyService.GetPregnancyTrackingListWithDetails(householdNo);
            var model = new PregnancyTrackingListVM
            {
                HouseholdNo = householdNo,
                PregnancyTrackingList = pregnancyList,
            };

            return View(model);
        }

        // GET: PregnancyTrackingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PregnancyTrackingController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMember(householdNo);
            var model = new CreatePregnancyTrackingVM
            {
                HouseholdNo = householdNo,
                WomenInHousehold = womenInHousehold,
            };

            return View(model);
        }

        // POST: PregnancyTrackingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePregnancyTrackingVM model)
        {
            try
            {
                var completed = await _pregnancyService.Add(model.PregnancyTracking);
                return RedirectToAction(nameof(Index), new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // GET: PregnancyTrackingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var pregnant = await _pregnancyService.GetPregnancyTrackingWithDetails(id);
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMember(pregnant.HouseholdMember.Household.HouseholdNo);

            var model = new EditPregnancyTrackingVM
            {
                WomenInHousehold = womenInHousehold,
                PregnancyTracking = pregnant,
                HouseholdNo = pregnant.HouseholdMember.Household.HouseholdNo
            };

            return View(model);
        }

        // POST: PregnancyTrackingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditPregnancyTrackingVM model)
        {
            try
            {
                var completed = await _pregnancyService.Update(model.PregnancyTracking);
                return RedirectToAction(nameof(Index), new { houseHoldNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // POST: PregnancyTrackingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            try
            {
                var preg = await _pregnancyService.Get(id);
                if (preg == null)
                {
                    return NotFound();
                }

                await _pregnancyService.Delete(preg);
                return RedirectToAction(nameof(Index), new { householdNo = householdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }
    }
}

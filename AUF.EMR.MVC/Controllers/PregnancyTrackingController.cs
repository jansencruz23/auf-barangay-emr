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
    [Authorize]
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
                PregnancyTrackingList = pregnancyList
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
                WomenInHousehold = womenInHousehold
            };

            return View(model);
        }

        // POST: PregnancyTrackingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePregnancyTrackingVM pregnancyTrackingVM)
        {
            try
            {
                var completed = await _pregnancyService.Add(pregnancyTrackingVM.PregnancyTracking);
                return RedirectToAction(nameof(Index), new { householdNo = pregnancyTrackingVM.PregnancyTracking.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(pregnancyTrackingVM);
        }

        // GET: PregnancyTrackingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var pregnant = await _pregnancyService.GetPregnancyTrackingWithDetails(id);
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMember(pregnant.HouseholdNo);

            var model = new EditPregnancyTrackingVM
            {
                WomenInHousehold = womenInHousehold,
                PregnancyTracking = pregnant
            };

            return View(model);
        }

        // POST: PregnancyTrackingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditPregnancyTrackingVM pregnancyTrackingVM)
        {
            try
            {
                var completed = await _pregnancyService.Update(pregnancyTrackingVM.PregnancyTracking);
                return RedirectToAction(nameof(Index), new { houseHoldNo = completed.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(pregnancyTrackingVM);
        }

        // GET: PregnancyTrackingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PregnancyTrackingController/Delete/5
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

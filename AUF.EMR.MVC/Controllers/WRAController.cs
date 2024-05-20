using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using AUF.EMR.MVC.Models.PrintVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class WRAController : Controller
    {
        private readonly IWRAService _wraService;
        private readonly IHouseholdMemberService _householdMemberService;
        private readonly IHouseholdService _householdService;
        private readonly UserManager<ApplicationUser> _userManager;

        public WRAController(IWRAService wraService,
            IHouseholdMemberService householdMemberService,
            IHouseholdService householdService,
            UserManager<ApplicationUser> userManager)
        {
            _wraService = wraService;
            _householdMemberService = householdMemberService;
            _householdService = householdService;
            _userManager = userManager;
        }

        // GET: WRAController
        public async Task<ActionResult> Index(string householdNo)
        {
            var wraList = await _wraService.GetWRAListWithDetails(householdNo);
            var model = new WRAListVM
            {
                HouseholdNo = householdNo,
                WRAs = wraList
            };

            return View(model);
        }

        // GET: WRAController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMembers(householdNo);
            var model = new CreateWRAVM
            {
                WomenInHousehold = womenInHousehold,
                HouseholdNo = householdNo
            };

            return View(model);
        }

        // POST: WRAController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateWRAVM model)
        {
            try
            {
                var completed = await _wraService.Add(model.WRA);
                return RedirectToAction(nameof(Index), new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // GET: WRAController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var wra = await _wraService.GetWRAWithDetails(id);
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMembers(wra.HouseholdMember.Household.HouseholdNo);

            var model = new EditWRAVM
            {
                WomenInHousehold = womenInHousehold,
                WRA = wra,
                HouseholdNo = wra.HouseholdMember.Household.HouseholdNo
            };

            return View(model);
        }

        // POST: WRAController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditWRAVM model)
        {
            try
            {
                var completed = await _wraService.Update(model.WRA);
                return RedirectToAction(nameof(Index), new { houseHoldNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // POST: WRAController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            try
            {
                var wra = await _wraService.Get(id);
                if (wra == null)
                {
                    return NotFound();
                }

                await _wraService.Delete(wra);
                return RedirectToAction(nameof(Index), new { householdNo = householdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }

        public async Task<ActionResult> Print(string householdNo)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new PrintWRAVM
            {
                Midwife = user.FullName,
                WRAs = await _wraService.GetWRAListWithDetails(householdNo),
                DatePrepared = DateTime.Now,
                Quarter = GetCurrentQuarter()
            };

            return View(model);
        }

        private int GetCurrentQuarter()
        {
            int month = DateTime.Today.Month;
            return (month - 1) / 3 + 1;
        }
    }
}

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
        private readonly IBarangayService _brgyService;
        private readonly UserManager<ApplicationUser> _userManager;

        public WRAController(IWRAService wraService,
            IHouseholdMemberService householdMemberService,
            IHouseholdService householdService,
            IBarangayService brgyService,
            UserManager<ApplicationUser> userManager)
        {
            _wraService = wraService;
            _householdMemberService = householdMemberService;
            _householdService = householdService;
            _userManager = userManager;
            _brgyService = brgyService;
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

        // GET: WRAController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WRAController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMember(householdNo);
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
        public async Task<ActionResult> Create(CreateWRAVM wraVM)
        {
            try
            {
                var completed = await _wraService.Add(wraVM.WRA);
                return RedirectToAction(nameof(Index), new { householdNo = wraVM.WRA.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(wraVM);
        }

        // GET: WRAController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var wra = await _wraService.GetWRAWithDetails(id);
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMember(wra.HouseholdNo);

            var model = new EditWRAVM
            {
                WomenInHousehold = womenInHousehold,
                WRA = wra
            };

            return View(model);
        }

        // POST: WRAController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditWRAVM wraVM)
        {
            try
            {
                var completed = await _wraService.Update(wraVM.WRA);
                return RedirectToAction(nameof(Index), new { houseHoldNo = completed.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(wraVM);
        }

        // GET: WRAController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WRAController/Delete/5
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

        public async Task<ActionResult> Print(string householdNo)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new PrintWRAVM
            {
                Barangay = await _brgyService.GetBarangay(),
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

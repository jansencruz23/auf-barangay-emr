using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class WRAController : Controller
    {
        private readonly IWRAService _wraService;
        private readonly IHouseholdMemberService _householdMemberService;
        private readonly IHouseholdService _householdService;

        public WRAController(IWRAService wraService,
            IHouseholdMemberService householdMemberService,
            IHouseholdService householdService)
        {
            _wraService = wraService;
            _householdMemberService = householdMemberService;
            _householdService = householdService;
        }

        // GET: WRAController
        public async Task<ActionResult> Index(string householdNo)
        {
            var wraList = await _wraService.GetWRAWithDetails(householdNo);
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
                HouseholdMembers = womenInHousehold,
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WRAController/Edit/5
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
    }
}

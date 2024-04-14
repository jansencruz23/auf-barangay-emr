using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AUF.EMR.Domain.Models;
using AUF.EMR.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models;
using Microsoft.Identity.Client;
using AUF.EMR.MVC.Models.CreateVM;
using Microsoft.AspNetCore.Authorization;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Identity;


namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class HouseholdController : Controller
    {
        private readonly IHouseholdService _houseHoldService;
        private readonly IHouseholdMemberService _houseHoldMemberService;
        private readonly IBarangayService _brgyService;

        public HouseholdController(IHouseholdService houseHoldService,
            IHouseholdMemberService houseHoldMemberService,
            IBarangayService brgyService)
        {
            _houseHoldService = houseHoldService;
            _houseHoldMemberService = houseHoldMemberService;
            _brgyService = brgyService;
        }

        // GET: HouseHolds
        public async Task<IActionResult> HouseholdProfile(string householdNo)
        {
            var searched = await _houseHoldService.GetSearchedhouseHoldWithDetails(householdNo);
            var barangay = await _brgyService.GetBarangay();

            var model = new HouseholdProfileVM
            {
                HouseholdNo = householdNo,
                Households = searched,
                Barangay = barangay
            };

            return View(model);
        }

        public async Task<IActionResult> Index(string query)
        {
            var barangay = await _brgyService.GetBarangay();
            var model = new HouseholdVM { Barangay = barangay };

            if (string.IsNullOrEmpty(query))
            {
                var households = await _houseHoldService.GetHouseholdsWithDetails();
                model.Households = households;

                return View(model);
            }

            var searched = await _houseHoldService.GetSearchedhouseHoldsWithDetails(query);
            model.Households = searched;

            return View(model);
        }

        // GET: HouseHolds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var houseHold = await _houseHoldService.GetHouseholdWithDetails(id.Value);
            var houseHoldMembers = await _houseHoldMemberService.GetHouseholdMembersWithDetails(houseHold.HouseholdNo);
            var model = new CreateHouseholdProfileVM
            {
                Household = houseHold,
                HouseholdMembers = houseHoldMembers,
                Barangay = await _brgyService.GetBarangay()
            };

            return View(model);
        }

        // GET: HouseHolds/Create
        public async Task<IActionResult> Create()
        {
            var model = new CreateHouseholdVM
            {
                Barangay = await _brgyService.GetBarangay()
            };

            return View(model);
        }

        // POST: HouseHolds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHouseholdVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Barangay = await _brgyService.GetBarangay();
                return View(model);
            }

            try
            {
                var isExisting = await _houseHoldService.IsHouseholdNoExisting(model.Household.HouseholdNo);
                if (isExisting)
                {
                    ModelState.AddModelError("", "Household No. is already existing.");
                    model.Barangay = await _brgyService.GetBarangay();
                    return View(model);
                }

                var household = model.Household;
                await _houseHoldService.Add(household);
                return RedirectToAction(nameof(HouseholdProfile), new { householdNo = household.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // GET: HouseHolds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var houseHold = await _houseHoldService.GetHouseholdWithDetails(id.Value);
            var houseHoldMembers = await _houseHoldMemberService.GetHouseholdMembersWithDetails(houseHold.HouseholdNo);
            var model = new CreateHouseholdProfileVM
            {
                Household = houseHold,
                HouseholdMembers = houseHoldMembers,
                Barangay = await _brgyService.GetBarangay()
            };
           
            return View(model);
        }

        // POST: HouseHolds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateHouseholdProfileVM householdVM)
        {
            try
            {
                var household = householdVM.Household;
                await _houseHoldService.Update(household);
                return RedirectToAction(nameof(HouseholdProfile), new { householdNo = household.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(householdVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var household = await _houseHoldService.Get(id.Value);
                if (household == null)
                {
                    return NotFound();
                }

                await _houseHoldService.DeleteHousehold(id.Value);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }
    }
}

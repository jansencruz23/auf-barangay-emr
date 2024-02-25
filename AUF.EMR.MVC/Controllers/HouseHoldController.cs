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

namespace AUF.EMR.MVC.Controllers
{
    public class HouseHoldController : Controller
    {
        private readonly IHouseHoldService _houseHoldService;
        private readonly IHouseHoldMemberService _houseHoldMemberService;

        public HouseHoldController(IHouseHoldService houseHoldService,
            IHouseHoldMemberService houseHoldMemberService)
        {
            _houseHoldService = houseHoldService;
            _houseHoldMemberService = houseHoldMemberService;
        }

        // GET: HouseHolds
        public async Task<IActionResult> Index(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                var model = await _houseHoldService.GetHouseHoldsWithDetails();
                return View(model);
            }

            var searched = await _houseHoldService.GetSearchedHouseHoldsWithDetails(query);
            return View(searched);
        }

        // GET: HouseHolds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _houseHoldService.GetHouseHoldWithDetails(id.Value);
            return View(model);
        }

        // GET: HouseHolds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseHolds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HouseHold houseHold)
        {
            try
            {
                await _houseHoldService.Add(houseHold);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(houseHold);
        }

        // GET: HouseHolds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var houseHold = await _houseHoldService.GetHouseHoldWithDetails(id.Value);
            var houseHoldMembers = await _houseHoldMemberService.GetHouseHoldMembersWithDetails(houseHold.HouseHoldNo);
            var model = new HouseHoldProfileVM
            {
                HouseHold = houseHold,
                HouseHoldMembers = houseHoldMembers
            };
           
            return View(model);
        }

        // POST: HouseHolds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HouseHold houseHold)
        {
            try
            {
                await _houseHoldService.Update(houseHold);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(houseHold);
        }

        // GET: HouseHolds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var houseHold = await _houseHoldService.Get(id.Value);
                await _houseHoldService.Update(houseHold);
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

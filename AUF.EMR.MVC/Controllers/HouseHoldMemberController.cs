using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class HouseholdMemberController : Controller
    {
        private readonly IHouseholdMemberService _houseHoldMemberService;
        private readonly IHouseholdService _houseHoldService;
        private readonly IMapper _mapper;

        public HouseholdMemberController(IHouseholdMemberService houseHoldMemberService,
            IHouseholdService houseHoldService, IMapper mapper)
        {
            _houseHoldMemberService = houseHoldMemberService;
            _houseHoldService = houseHoldService;
            _mapper = mapper;
        }

        // GET: HouseHoldMemberController
        public async Task<ActionResult> Index(int id)
        {
            var household = await _houseHoldService.GetHouseholdWithDetails(id);
            if (household == null)
            {
                return NotFound();
            }

            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = household.HouseholdMembers,
                Household = household,
            };

            return View(model);
        }

        // GET: HouseHoldMemberController/Details/5
        public async Task<ActionResult> Details(int id, string requestUrl)
        {
            var model = new DetailHouseholdMemberVM
            {
                HouseholdMember = await _houseHoldMemberService.GetHouseholdMemberWithDetails(id),
                ReturnUrl = requestUrl
            };

            return View(model);
        }

        // GET: HouseHoldMemberController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var householdId = await _houseHoldService.GetHouseholdId(householdNo);

            var model = new CreateHouseholdMemberVM
            {
                HouseholdNo = householdNo,
                HouseholdId = householdId,
            };

            return View(model);
        }

        // POST: HouseHoldMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHouseholdMemberVM householdMemberVM)
        {
            try
            {
                var householdMember = householdMemberVM.HouseholdMember;
                var householdId = await _houseHoldService.GetHouseholdId(householdMember.Household.HouseholdNo);
                householdMember.HouseholdId = householdId;
                var completed = await _houseHoldMemberService.Add(householdMember);

                return RedirectToAction(nameof(Edit), nameof(Household), new { id = householdId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(householdMemberVM);
        }

        // GET: HouseHoldMemberController/Edit/5
        public async Task<ActionResult> Edit(int id, string requestUrl)
        {
            var member = await _houseHoldMemberService.GetHouseholdMemberWithDetails(id);
            var model = new EditHouseholdMemberVM
            {
                HouseholdMember = member,
                ReturnUrl = requestUrl,
            };

            return View(model);
        }

        // POST: HouseHoldMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditHouseholdMemberVM householdMemberVM)
        {
            try
            {
                var householdMember = householdMemberVM.HouseholdMember;
                var householdId = await _houseHoldService.GetHouseholdId(householdMember.Household.HouseholdNo);
                householdMember.HouseholdId = householdId;
                var completed = await _houseHoldMemberService.Update(householdMember);

                if (!string.IsNullOrEmpty(householdMemberVM.ReturnUrl) 
                    && Url.IsLocalUrl(householdMemberVM.ReturnUrl))
                {
                    return Redirect(householdMemberVM.ReturnUrl);
                }

                return RedirectToAction(nameof(Edit), nameof(Household), new { id = householdId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(householdMemberVM);
        }

        // POST: HouseHoldMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdId)
        {
            try
            {
                var member = await _houseHoldMemberService.Get(id);
                if (member == null)
                {
                    return NotFound();
                }

                await _houseHoldMemberService.DeleteHouseholdMember(id);
                return RedirectToAction(nameof(Edit), nameof(Household), new { id = householdId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }
    }
}

using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
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
        private readonly IBarangayService _brgyService;
        private readonly IMapper _mapper;

        public HouseholdMemberController(IHouseholdMemberService houseHoldMemberService,
            IHouseholdService houseHoldService, IBarangayService brgyService, IMapper mapper)
        {
            _houseHoldMemberService = houseHoldMemberService;
            _houseHoldService = houseHoldService;
            _brgyService = brgyService;
            _mapper = mapper;
        }

        // GET: HouseHoldMemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HouseHoldMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HouseHoldMemberController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var householdId = await _houseHoldService.GetHouseholdId(householdNo);
            var barangay = await _brgyService.GetBarangay();

            var model = new CreateHouseholdMemberVM
            {
                HouseholdNo = householdNo,
                HouseholdId = householdId,
                Barangay = barangay
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
                var householdId = await _houseHoldService.GetHouseholdId(householdMember.HouseholdNo);
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
                ReturnUrl = requestUrl
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
                var householdId = await _houseHoldService.GetHouseholdId(householdMember.HouseholdNo);
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

        // GET: HouseHoldMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HouseHoldMemberController/Delete/5
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

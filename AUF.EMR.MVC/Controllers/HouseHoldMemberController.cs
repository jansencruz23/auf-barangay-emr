using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
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
        public ActionResult Create(string householdNo)
        {
            var model = new CreateHouseholdMemberVM
            {
                HouseholdNo = householdNo
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
                var completed = await _houseHoldMemberService.Add(householdMember);
                var householdId = await _houseHoldService.GetHouseholdId(householdMember.HouseholdNo);

                return RedirectToAction(nameof(Edit), nameof(Household), new { id = householdId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(householdMemberVM);
        }

        // GET: HouseHoldMemberController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _houseHoldMemberService.GetHouseholdMemberWithDetails(id);
            return View(model);
        }

        // POST: HouseHoldMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HouseholdMember householdMember)
        {
            try
            {
                var completed = await _houseHoldMemberService.Update(householdMember);
                var householdId = await _houseHoldService.GetHouseholdId(householdMember.HouseholdNo);

                return RedirectToAction(nameof(Edit), nameof(Household), new { id = householdId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(householdMember);
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

using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class MasterlistChildrenController : Controller
    {
        private readonly IMasterlistChildrenService _masterListChildrenService;
        private readonly IHouseholdMemberService _householdMemberService;

        public MasterlistChildrenController(IMasterlistChildrenService masterListChildrenService,
            IHouseholdMemberService householdMemberService)
        {
            _masterListChildrenService = masterListChildrenService;
            _householdMemberService = householdMemberService;
        }

        // GET: MasterListChildrenController
        public async Task<ActionResult> Index(string householdNo)
        {
            var searched = await _masterListChildrenService.GetMasterlistChildrenWithDetails(householdNo);
            return View(searched);
        }

        // GET: MasterListChildrenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterListChildrenController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var members = await _householdMemberService.GetHouseholdMembersWithDetails(householdNo);
            var model = new CreateMasterlistChildrenVM
            {
                HouseholdNo = householdNo,
                HouseholdMembers = members
            };
            
            return View(model);
        }

        // POST: MasterListChildrenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMasterlistChildrenVM model)
        {
            try
            {
                await _masterListChildrenService.Add(model.MasterlistChildren);
                return RedirectToAction(nameof(Index), new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // GET: MasterListChildrenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MasterListChildrenController/Edit/5
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

        // GET: MasterListChildrenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterListChildrenController/Delete/5
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

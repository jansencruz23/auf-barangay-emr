using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class HouseHoldMemberController : Controller
    {
        private readonly IHouseHoldMemberService _houseHoldMemberService;

        public HouseHoldMemberController(IHouseHoldMemberService houseHoldMemberService)
        {
            _houseHoldMemberService = houseHoldMemberService;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseHoldMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HouseHoldMember houseHoldMember)
        {
            try
            {
                var houseHold = await _houseHoldMemberService.GetHouseHoldMemberWithDetails(houseHoldMember.Id);
                var completed = await _houseHoldMemberService.Add(houseHoldMember);
                return RedirectToAction(nameof(Create), nameof(HouseHold));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(houseHoldMember);
        }

        // GET: HouseHoldMemberController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _houseHoldMemberService.GetHouseHoldMemberWithDetails(id);
            return View(model);
        }

        // POST: HouseHoldMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HouseHoldMember houseHoldMember)
        {
            try
            {
                var houseHold = await _houseHoldMemberService.GetHouseHoldMemberWithDetails(id);
                await _houseHoldMemberService.Update(houseHoldMember);
                return RedirectToAction(nameof(Edit), nameof(HouseHold), new { id = houseHold.HouseHold.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(houseHoldMember);
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

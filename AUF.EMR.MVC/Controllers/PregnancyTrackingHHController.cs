using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class PregnancyTrackingHHController : Controller
    {
        private readonly IPregnancyTrackingHHService _ptHHService;

        public PregnancyTrackingHHController(IPregnancyTrackingHHService ptHHService)
        {
            _ptHHService = ptHHService;
        }

        // GET: PregnancyTrackingHHController/Edit/5
        public async Task<ActionResult> Edit(int id, string householdNo)
        {
            var pregTrackHH = await _ptHHService.GetPregnancyTrackingHHWithDetails(householdNo);
            var model = new EditPregnancyTrackingHHVM
            {
                PregnancyTrackingHH = pregTrackHH,
                HouseholdNo = householdNo
            };

            return View(model);
        }

        // POST: PregnancyTrackingHHController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditPregnancyTrackingHHVM model)
        {
            if (!id.Equals(model.PregnancyTrackingHH.Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var pregTrackHH = model.PregnancyTrackingHH;
                if (pregTrackHH == null)
                {
                    return NotFound();
                }

                await _ptHHService.Update(pregTrackHH);

                return RedirectToAction(nameof(Index), "PregnancyTracking", new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View(model);
            }
        }
    }
}

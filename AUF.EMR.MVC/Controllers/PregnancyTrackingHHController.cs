using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
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
                var pregTrackHH = await _ptHHService.GetPregnancyTrackingHHWithDetails(id);
                if (pregTrackHH == null)
                {
                    return NotFound();
                }

                await _ptHHService.Update(pregTrackHH);

                return RedirectToAction(nameof(Edit), new { id });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // GET: PregnancyTrackingHHController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PregnancyTrackingHHController/Delete/5
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

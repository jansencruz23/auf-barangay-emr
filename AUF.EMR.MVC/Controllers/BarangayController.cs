using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.EditVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize]
    public class BarangayController : Controller
    {
        private readonly IBarangayService _barangayService;

        public BarangayController(IBarangayService barangayService)
        {
            _barangayService = barangayService;
        }

        // GET: BarangayController
        public async Task<ActionResult> Index()
        {
            var barangay = await _barangayService.GetBarangay();
            return View(barangay);
        }

        // GET: BarangayController/Edit/5
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Edit(int id)
        {
            var barangay = await _barangayService.GetBarangay();
            var model = new EditBarangayVM
            {
                Barangay = barangay,
                LogoFile = null
            };

            return View(model);
        }

        // POST: BarangayController/Edit/5
        [HttpPost]
        [Authorize(Policy = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditBarangayVM barangayVM)
        {
            if (!ModelState.IsValid)
            {
                barangayVM.Barangay = await _barangayService.GetBarangay();
                return View(barangayVM);
            }
            try
            {
                if (barangayVM.LogoFile != null && barangayVM.LogoFile.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await barangayVM.LogoFile.CopyToAsync(memoryStream);
                    byte[] logoBytes = memoryStream.ToArray();

                    barangayVM.Barangay.Logo = logoBytes;
                }
                var completed = await _barangayService.Update(barangayVM.Barangay);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(barangayVM);
        }
    }
}

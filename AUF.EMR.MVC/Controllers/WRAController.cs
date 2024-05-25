using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using AUF.EMR.MVC.Models.PrintVM;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using FastReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class WRAController : Controller
    {
        private readonly IWRAService _wraService;
        private readonly IHouseholdMemberService _householdMemberService;
        private readonly IHouseholdService _householdService;
        private readonly IBarangayService _brgyService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WRAController(IWRAService wraService,
            IHouseholdMemberService householdMemberService,
            IHouseholdService householdService,
            IBarangayService brgyService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _wraService = wraService;
            _householdMemberService = householdMemberService;
            _householdService = householdService;
            _brgyService = brgyService;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: WRAController
        public async Task<ActionResult> Index(string householdNo)
        {
            var wraList = await _wraService.GetWRAListWithDetails(householdNo);
            var model = new WRAListVM
            {
                HouseholdNo = householdNo,
                WRAs = wraList
            };

            return View(model);
        }

        // GET: WRAController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMembers(householdNo);
            var model = new CreateWRAVM
            {
                WomenInHousehold = womenInHousehold,
                HouseholdNo = householdNo
            };

            return View(model);
        }

        // POST: WRAController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateWRAVM model)
        {
            try
            {
                var completed = await _wraService.Add(model.WRA);
                return RedirectToAction(nameof(Index), new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // GET: WRAController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var wra = await _wraService.GetWRAWithDetails(id);
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMembers(wra.HouseholdMember.Household.HouseholdNo);

            var model = new EditWRAVM
            {
                WomenInHousehold = womenInHousehold,
                WRA = wra,
                HouseholdNo = wra.HouseholdMember.Household.HouseholdNo
            };

            return View(model);
        }

        // POST: WRAController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditWRAVM model)
        {
            try
            {
                var completed = await _wraService.Update(model.WRA);
                return RedirectToAction(nameof(Index), new { houseHoldNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // POST: WRAController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            try
            {
                var wra = await _wraService.Get(id);
                if (wra == null)
                {
                    return NotFound();
                }

                await _wraService.Delete(wra);
                return RedirectToAction(nameof(Index), new { householdNo = householdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }

        public async Task<string> Print(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return "Household no. is empty";
            }

            try
            {
                var wras = await _wraService.GetWRAListWithDetails(householdNo);
                var householdMembers = await _householdMemberService.GetWRAHouseholdMembers(householdNo);
                var brgyName = (await _brgyService.GetBarangay()).BarangayName;
                var address = (await _householdService.GetHouseholdWithDetails(householdNo)).FullAddress;
                var midwife = (await _userManager.GetUserAsync(User)).FullName;
                var date = DateTime.Today.ToString("MM/dd/YYYY");
                var year = DateTime.Today.Year;
                var quarter = GetCurrentQuarter();

                Config.WebMode = true;
                var report = new Report();
                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine(contentRootPath, "Reports", "WRAForm.frx");

                report.Load(path);
                report.RegisterData(wras, "WRA");
                report.RegisterData(householdMembers, "HouseholdMembers");

                report.SetParameterValue("Barangay", brgyName);
                report.SetParameterValue("Address", brgyName);
                report.SetParameterValue("Midwife", midwife);
                report.SetParameterValue("Date", date);
                report.SetParameterValue("Year", year);
                report.SetParameterValue("Quarter", quarter);
                report.SetParameterValue("Address", address);

                if (report.Report.Prepare())
                {
                    var pdfExport = new PDFSimpleExport();
                    pdfExport.ShowProgress = true;
                    pdfExport.Subject = "Subject Report";
                    pdfExport.Title = "Report Title";
                    var memoryStream = new MemoryStream();
                    report.Report.Export(pdfExport, memoryStream);
                    report.Dispose();
                    pdfExport.Dispose();
                    memoryStream.Position = 0;

                    return Convert.ToBase64String(memoryStream.ToArray());
                    //return File(memoryStream, "application/pdf", "household.pdf");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private int GetCurrentQuarter()
        {
            int month = DateTime.Today.Month;
            return (month - 1) / 3 + 1;
        }
    }
}

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
using AUF.EMR.MVC.Models.CreateVM;
using Microsoft.AspNetCore.Authorization;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Identity;
using AUF.EMR.Domain.Models.Identity;
using FastReport.Utils;
using FastReport;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using FastReport.Export.PdfSimple;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class HouseholdController : Controller
    {
        private readonly IHouseholdService _houseHoldService;
        private readonly IHouseholdMemberService _houseHoldMemberService;
        private readonly IBarangayService _brgyService;
        private readonly IPregnancyTrackingHHService _ptHHService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HouseholdController(IHouseholdService houseHoldService,
            IHouseholdMemberService houseHoldMemberService,
            IBarangayService brgyService,
            IPregnancyTrackingHHService ptHHService,
            IWebHostEnvironment webHostEnvironment)
        {
            _houseHoldService = houseHoldService;
            _houseHoldMemberService = houseHoldMemberService;
            _brgyService = brgyService;
            _ptHHService = ptHHService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: HouseHolds
        public async Task<IActionResult> HouseholdProfile(string householdNo)
        {
            var searched = await _houseHoldService.GetSearchedhouseHoldWithDetails(householdNo);
            var householdMembers = await _houseHoldMemberService.GetHouseholdMembersWithDetails(householdNo);

            if (searched == null)
            {
                return NotFound();
            }

            var model = new HouseholdProfileVM
            {
                HouseholdNo = householdNo,
                Household = searched,
                HouseholdMembers = householdMembers,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
            };

            return View(model);
        }

        public async Task<IActionResult> Index(string query)
        {
            var model = new HouseholdVM();

            if (string.IsNullOrEmpty(query))
            {
                var households = await _houseHoldService.GetHouseholdsWithDetails();
                model.Households = households;

                return View(model);
            }

            var searched = await _houseHoldService.GetSearchedhouseHoldsWithDetails(query);
            model.Households = searched;

            return View(model);
        }

        // GET: HouseHolds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var houseHold = await _houseHoldService.GetHouseholdWithDetails(id.Value);
            var houseHoldMembers = await _houseHoldMemberService.GetHouseholdMembersWithDetails(houseHold.HouseholdNo);
            var model = new CreateHouseholdProfileVM
            {
                Household = houseHold,
                HouseholdMembers = houseHoldMembers
            };

            return View(model);
        }

        // GET: HouseHolds/Create
        public IActionResult Create()
        {
            var model = new CreateHouseholdVM();
            return View(model);
        }

        // POST: HouseHolds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHouseholdVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var isExisting = await _houseHoldService.IsHouseholdNoExisting(model.Household.HouseholdNo);
                if (isExisting)
                {
                    ModelState.AddModelError("", "Household No. is already existing.");
                    model.ErrorMessage = "Household No. is already existing.";
                    return View(model);
                }

                var household = model.Household;
                await _houseHoldService.Add(household);

                var pregTrackHH = await CreatePregnancyTrackingHH(model.Household);
                await _ptHHService.Add(pregTrackHH);
                return RedirectToAction(nameof(HouseholdProfile), new { householdNo = household.HouseholdNo });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        private async Task<PregnancyTrackingHH> CreatePregnancyTrackingHH(Household household)
        {
            var barangay = await _brgyService.GetBarangay();
            return new PregnancyTrackingHH
            {
                Barangay = barangay.BarangayName,
                Region = barangay.Region,
                Municipality = barangay.Municipality,
                Province = barangay.Province,
                Year = DateTime.Now.Year,
                BHWName = string.Empty,
                BirthingCenter = string.Empty,
                BirthingCenterAddress = string.Empty,
                MidwifeName = string.Empty,
                ReferralCenter = string.Empty,
                ReferralCenterAddress = string.Empty,
                BarangayHealthStation = barangay.BarangayHealthStation,
                RuralHealthUnit = barangay.RuralHealthUnit,
                HouseholdId = household.Id,
            };
        }

        // GET: HouseHolds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var household = await _houseHoldService.GetHouseholdWithDetails(id.Value);

            if (household == null)
            {
                return NotFound();
            }
            
            var householdMembers = await _houseHoldMemberService.GetHouseholdMembersWithDetails(household.HouseholdNo);
            var model = new CreateHouseholdProfileVM
            {
                Household = household,
                HouseholdMembers = householdMembers
            };
           
            return View(model);
        }

        // POST: HouseHolds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CreateHouseholdProfileVM model)
        {
            if (id == null || model == null)
            {
                return NotFound();
            }

            try
            {
                var prevHouseholdNo = await _houseHoldService.GetHouseholdNo(id.Value);
                var isExisting = await _houseHoldService.IsHouseholdNoExisting(model.Household.HouseholdNo);
                if (isExisting && model.Household.HouseholdNo != prevHouseholdNo)
                {
                    ModelState.AddModelError("", "Household No. is already existing.");
                    model.ErrorMessage = "Household No. is already existing.";
                    return View(model);
                }

                var household = model.Household;
                await _houseHoldService.Update(household);
                return RedirectToAction(nameof(HouseholdProfile), new { householdNo = household.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var household = await _houseHoldService.Get(id.Value);
                if (household == null)
                {
                    return NotFound();
                }

                await _houseHoldService.DeleteHousehold(id.Value);
                return RedirectToAction(nameof(Index));
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
                var household = await _houseHoldService.GetHouseholdForm(householdNo);

                if (household == null)
                {
                    return "Household does not exist";
                }

                Config.WebMode = true;
                var report = new Report();
                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine(contentRootPath, "Reports", "HouseholdForm.frx");
                var householdMembers = await _houseHoldMemberService.GetHouseholdMembersWithDetails(householdNo);

                report.Load(path);
                report.RegisterData(household, "HouseholdRef");
                report.RegisterData(householdMembers, "HouseholdMemberRef");
               
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
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

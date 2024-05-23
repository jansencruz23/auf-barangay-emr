using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using FastReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class PregnancyTrackingController : Controller
    {
        private readonly IPregnancyTrackingService _pregnancyService;
        private readonly IHouseholdMemberService _householdMemberService;
        private readonly IPregnancyTrackingHHService _pregTrackHHService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PregnancyTrackingController(IPregnancyTrackingService pregnancyService,
            IHouseholdMemberService householdMemberService,
            IPregnancyTrackingHHService pregTrackHHService,
            IWebHostEnvironment webHostEnvironment)
        {
            _pregnancyService = pregnancyService;
            _householdMemberService = householdMemberService;
            _pregTrackHHService = pregTrackHHService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PregnancyTrackingController
        public async Task<ActionResult> Index(string householdNo)
        {
            var pregTrackHH = await _pregTrackHHService.GetPregnancyTrackingHHWithDetails(householdNo);
            var pregnancyList = await _pregnancyService.GetPregnancyTrackingListWithDetails(householdNo);
            var model = new PregnancyTrackingListVM
            {
                HouseholdNo = householdNo,
                PregnancyTrackingList = pregnancyList,
                PregnancyTrackingHH = pregTrackHH
            };

            return View(model);
        }

        // GET: PregnancyTrackingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PregnancyTrackingController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMembers(householdNo);
            var model = new CreatePregnancyTrackingVM
            {
                HouseholdNo = householdNo,
                WomenInHousehold = womenInHousehold,
            };

            return View(model);
        }

        // POST: PregnancyTrackingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePregnancyTrackingVM model)
        {
            try
            {
                var completed = await _pregnancyService.Add(model.PregnancyTracking);
                return RedirectToAction(nameof(Index), new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // GET: PregnancyTrackingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var pregnant = await _pregnancyService.GetPregnancyTrackingWithDetails(id);
            var womenInHousehold = await _householdMemberService.GetWRAHouseholdMembers(pregnant.HouseholdMember.Household.HouseholdNo);

            var model = new EditPregnancyTrackingVM
            {
                WomenInHousehold = womenInHousehold,
                PregnancyTracking = pregnant,
                HouseholdNo = pregnant.HouseholdMember.Household.HouseholdNo
            };

            return View(model);
        }

        // POST: PregnancyTrackingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditPregnancyTrackingVM model)
        {
            try
            {
                var completed = await _pregnancyService.Update(model.PregnancyTracking);
                return RedirectToAction(nameof(Index), new { houseHoldNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // POST: PregnancyTrackingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            try
            {
                var preg = await _pregnancyService.Get(id);
                if (preg == null)
                {
                    return NotFound();
                }

                await _pregnancyService.Delete(preg);
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
                var pregTrack = await _pregnancyService.GetPregnancyTrackingListWithDetails(householdNo);
                var pregTrackHH = await _pregTrackHHService.GetPregnancyTrackingsHHWithDetails(householdNo);
                var householdMembers = await _pregnancyService.GetPregnantTrackingMembers(householdNo);

                Config.WebMode = true;
                var report = new Report();
                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine(contentRootPath, "Reports", "PregnancyTracking.frx");

                report.Load(path);
                report.RegisterData(pregTrack, "PregnancyTracking");
                report.RegisterData(pregTrackHH, "PregnancyTrackingHH");
                report.RegisterData(householdMembers, "HouseholdMember");

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
    }
}

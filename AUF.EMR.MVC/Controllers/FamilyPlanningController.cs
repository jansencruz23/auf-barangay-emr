﻿using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.FamilyPlanning;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using FastReport;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class FamilyPlanningController : Controller
    {
        private readonly IFamilyPlanningService _fpService;
        private readonly IHouseholdMemberService _householdMemberService;
        private readonly IHouseholdService _householdService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FamilyPlanningController(IFamilyPlanningService fpService,
            IHouseholdMemberService householdMemberService,
            IHouseholdService householdService,
            IWebHostEnvironment webHostEnvironment)
        {
            _fpService = fpService;
            _householdMemberService = householdMemberService;
            _householdService = householdService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: FamilyPlanningController
        public async Task<ActionResult> Index(string householdNo)
        {
            var records = await _fpService.GetFPRecordsWithDetails(householdNo);
            if (records == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            var model = new FamilyPlanningVM
            {
                FPRecords = records,
                HouseholdNo = householdNo
            };

            return View(model);
        }

        // GET: FamilyPlanningController/Details/5
        public async Task<ActionResult> Details(int id, string householdNo)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(householdNo))
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            try
            {
                var record = await _fpService.GetFPRecordWithDetails(id);
                if (record == null)
                {
                    return RedirectToAction("PageNotFound", "Error");
                }

                var model = new DetailFamilyPlanningVM
                {
                    FamilyPlanning = record,
                    HouseholdNo = householdNo
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: FamilyPlanningController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            try
            {
                var model = new CreateFamilyPlanningVM
                {
                    HouseholdNo = householdNo,
                    WomenHouseholdMember = await _householdMemberService.GetWRAHouseholdMembers(householdNo),
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Invalid", "Error", new { message = ex.Message });
            }
        }

        // POST: FamilyPlanningController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFamilyPlanningVM model)
        {
            if (model == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            try
            {
                var fpRecord = model.FPRecord;
                fpRecord.ClientType = model.ClientType;
                fpRecord.MedicalHistory = model.MedicalHistory;
                fpRecord.ObstetricalHistory = model.ObstetricalHistory;
                fpRecord.RisksForSTI = model.RisksForSTI;
                fpRecord.RisksForVAW = model.RisksForVAW;
                fpRecord.PhysicalExamination = model.PhysicalExamination;

                if (fpRecord == null)
                {
                    return NotFound();
                }

                await _fpService.AddFamilyPlanning(fpRecord);

                return RedirectToAction(nameof(Index), "FamilyPlanning", new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // GET: FamilyPlanningController/Edit/5
        public async Task<ActionResult> Edit(int id, string householdNo)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(householdNo))
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            try
            {
                var fpRecord = await _fpService.GetFPRecordWithDetails(id);
                var model = new EditFamilyPlanningVM
                {
                    HouseholdNo = householdNo,
                    FPRecord = fpRecord,
                    ClientType = fpRecord.ClientType,
                    MedicalHistory = fpRecord.MedicalHistory,
                    ObstetricalHistory = fpRecord.ObstetricalHistory,
                    RisksForSTI = fpRecord.RisksForSTI,
                    RisksForVAW = fpRecord.RisksForVAW,
                    PhysicalExamination = fpRecord.PhysicalExamination,
                    WomenHouseholdMember = await _householdMemberService.GetWRAHouseholdMembers(householdNo),
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Invalid", "Error", new { message = ex.Message });
            }
        }

        // POST: FamilyPlanningController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditFamilyPlanningVM model)
        {
            if (model == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var fpRecord = model.FPRecord;
                fpRecord.ClientType = model.ClientType;
                fpRecord.MedicalHistory = model.MedicalHistory;
                fpRecord.ObstetricalHistory = model.ObstetricalHistory;
                fpRecord.RisksForSTI = model.RisksForSTI;
                fpRecord.RisksForVAW = model.RisksForVAW;
                fpRecord.PhysicalExamination = model.PhysicalExamination;

                if (fpRecord == null)
                {
                    return NotFound();
                }

                await _fpService.UpdateFamilyPlanning(fpRecord);

                return RedirectToAction(nameof(Index), "FamilyPlanning", new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: FamilyPlanningController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(householdNo))
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            try
            {
                var record = await _fpService.GetFPRecordWithDetails(id);
                if (record == null)
                {
                    return RedirectToAction("PageNotFound", "Error");
                }
                await _fpService.Delete(record);
                return RedirectToAction(nameof(Index), new { householdNo = householdNo });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<string> Print(string householdNo, int id, int householdMemberId)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return "Household no. is empty";
            }

            try
            {
                var fpRecord = await _fpService.GetFamilyPlanningForm(id);
                var clientType = await _fpService.GetClientTypeForm(id);
                var medicalHistory = await _fpService.GetMedicalHistoryForm(id);
                var obstetricalHistory = await _fpService.GetObstetricalHistoryForm(id);
                var risksForSti = await _fpService.GetRisksForSTIForm(id);
                var risksForVaw = await _fpService.GetRisksForVAWForm(id);
                var physicalExampination = await _fpService.GetPhysicalExaminationForm(id);
                var householdMember = await _householdMemberService.GetHouseholdMemberForm(householdMemberId);
                var household = await _householdService.GetHouseholdWithDetails(householdNo);
                var streetNo = household.HouseNoAndStreet;
                var barangay = household.Barangay;
                var city = household.City;
                var province = household.Province;

                Config.WebMode = true;
                var report = new Report();
                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine(contentRootPath, "Reports", "FamilyPlanning.frx");

                report.Load(path);
                report.RegisterData(fpRecord, "FamilyPlanning");
                report.RegisterData(clientType, "ClientType");
                report.RegisterData(medicalHistory, "MedicalHistory");
                report.RegisterData(obstetricalHistory, "ObstetricalHistory");
                report.RegisterData(risksForSti, "RisksForSTI");
                report.RegisterData(risksForVaw, "RisksForVAW");
                report.RegisterData(physicalExampination, "PhysicalExamination");
                report.RegisterData(householdMember, "HouseholdMember");

                report.SetParameterValue("StreetNo", streetNo);
                report.SetParameterValue("Barangay", barangay);
                report.SetParameterValue("City", city);
                report.SetParameterValue("Province", province);

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

using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using FastReport.Export.PdfSimple;
using FastReport;
using Google.Protobuf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using FastReport.Utils;

namespace AUF.EMR.MVC.Controllers;

[Authorize(Policy = "User")]
public class DiabetesRiskController : Controller
{
    private readonly IDiabetesRiskService _diabetesRiskService;
    private readonly IHouseholdMemberService _householdMemberService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public DiabetesRiskController(
        IDiabetesRiskService diabetesRiskService,
        IHouseholdMemberService householdMemberService,
        IWebHostEnvironment webHostEnvironment)
    {
        _diabetesRiskService = diabetesRiskService;
        _householdMemberService = householdMemberService;
        _webHostEnvironment = webHostEnvironment;
    }

    // GET: DiabetesRiskController
    public async Task<ActionResult> Index(string householdNo)
    {
        var diabetesRiskList = await _diabetesRiskService.GetDiabetesRiskWithDetails(householdNo);
        var model = new DiabetesRiskVM
        {
            DiabetesRisks = diabetesRiskList,
            HouseholdNo = householdNo
        };

        return View(model);
    }

    // GET: DiabetesRiskController/Details/5
    public async Task<ActionResult> Details(int id, string householdNo)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var diabetesRisk = await _diabetesRiskService.GetDiabetesRiskWithDetails(id);
        if (diabetesRisk == null)
        {
            return NotFound();
        }

        var model = new DetailDiabetesRiskVM
        {
            DiabetesRisk = diabetesRisk,
            HouseholdNo = householdNo
        };

        return View(model);
    }

    // GET: DiabetesRiskController/Create
    public async Task<ActionResult> Create(string householdNo)
    {
        var viewModel = await CreateCreateDiabetesRiskVM(householdNo!);
        return View(viewModel);
    }

    // POST: DiabetesRiskController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateDiabetesRiskVM model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            var viewModel = await CreateCreateDiabetesRiskVM(model.HouseholdNo!);
            return View(viewModel);
        }

        try
        {
            var diabetesRisk = await _diabetesRiskService.Add(model.DiabetesRisk);
            return RedirectToAction(nameof(Index), new { householdNo = model.HouseholdNo });
        }
        catch
        {
            var viewModel = await CreateCreateDiabetesRiskVM(model.HouseholdNo!);
            return View(viewModel);
        }
    }

    private async Task<CreateDiabetesRiskVM> CreateCreateDiabetesRiskVM(string householdNo)
    {
        var members = await _householdMemberService.GetHouseholdMembersWithDetails(householdNo);
        var model = new CreateDiabetesRiskVM
        {
            MemberList = members,
            HouseholdNo = householdNo
        };
        return model;
    }
    private async Task<EditDiabetesRiskVM> CreateEditDiabetesRiskVM(string householdNo)
    {
        var members = await _householdMemberService.GetHouseholdMembersWithDetails(householdNo);
        var model = new EditDiabetesRiskVM
        {
            MemberList = members,
            HouseholdNo = householdNo
        };
        return model;
    }

    // GET: DiabetesRiskController/Edit/5
    public async Task<ActionResult> Edit(int id, string householdNo)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var diabetesRisk = await _diabetesRiskService.GetDiabetesRiskWithDetails(id);
        if (diabetesRisk == null)
        {
            return NotFound();
        }

        var model = await CreateEditDiabetesRiskVM(householdNo);
        model.DiabetesRisk = diabetesRisk;

        return View(model);
    }

    // POST: DiabetesRiskController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(EditDiabetesRiskVM model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            var members = await _householdMemberService.GetHouseholdMembersWithDetails(model.HouseholdNo);
            model.MemberList = members;
            return View(model);
        }

        try
        {
            await _diabetesRiskService.Update(model.DiabetesRisk);
            return RedirectToAction(nameof(Index), new { model.HouseholdNo });
        }
        catch
        {
            var members = await _householdMemberService.GetHouseholdMembersWithDetails(model.HouseholdNo);
            model.MemberList = members;
            return View(model);
        }
    }

    // POST: DiabetesRiskController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, string householdNo)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        try
        {
            var diabetesRisk = await _diabetesRiskService.GetDiabetesRiskWithDetails(id);
            if (diabetesRisk == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            await _diabetesRiskService.Delete(diabetesRisk);
            diabetesRisk = await _diabetesRiskService.GetDiabetesRiskWithDetails(id);
            return RedirectToAction(nameof(Index), new { householdNo });
        }
        catch
        {
            return BadRequest();
        }
    }

    public async Task<string> Print(string householdNo, int id, int householdMemberId)
    {
        if (string.IsNullOrWhiteSpace(householdNo) || id == 0 || householdMemberId == 0)
        {
            return "An error occured.";
        }

        try
        {
            var diabetesRiskForm = await _diabetesRiskService.GetDiabetesRiskForm(id);
            var householdMember = await _householdMemberService.GetHouseholdMemberForm(householdMemberId);

            Config.WebMode = true;
            var report = new Report();
            var contentRootPath = _webHostEnvironment.ContentRootPath;
            var path = Path.Combine(contentRootPath, "Reports", "DiabetesRiskForm.frx");

            report.Load(path);
            report.RegisterData(diabetesRiskForm, "DiabetesRiskForm");
            report.RegisterData(householdMember, "HouseholdMember");

            report.SetParameterValue("HouseholdNo", householdNo);

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

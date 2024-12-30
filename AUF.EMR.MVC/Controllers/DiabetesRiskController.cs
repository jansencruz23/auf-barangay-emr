using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using Google.Protobuf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers;

[Authorize(Policy = "User")]
public class DiabetesRiskController : Controller
{
    private readonly IDiabetesRiskService _diabetesRiskService;
    private readonly IHouseholdMemberService _householdMemberService;

    public DiabetesRiskController(
        IDiabetesRiskService diabetesRiskService,
        IHouseholdMemberService householdMemberService)
    {
        _diabetesRiskService = diabetesRiskService;
        _householdMemberService = householdMemberService;
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
}

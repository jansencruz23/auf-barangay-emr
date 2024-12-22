using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.IndexVM;
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
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: DiabetesRiskController/Create
    public async Task<ActionResult> Create(string householdNo)
    {
        var members = await _householdMemberService.GetHouseholdMembersWithDetails(householdNo);
        var model = new CreateDiabetesRiskVM
        {
            MemberList = members,
        };
        return View(model);
    }

    // POST: DiabetesRiskController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    // GET: DiabetesRiskController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: DiabetesRiskController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
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

    // GET: DiabetesRiskController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: DiabetesRiskController/Delete/5
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

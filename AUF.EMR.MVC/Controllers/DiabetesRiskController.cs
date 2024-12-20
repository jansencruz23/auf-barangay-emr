using AUF.EMR.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers;

[Authorize(Policy = "User")]
public class DiabetesRiskController : Controller
{
    private readonly IDiabetesRiskService _diabetesRiskService;

    public DiabetesRiskController(IDiabetesRiskService diabetesRiskService)
    {
        _diabetesRiskService = diabetesRiskService;
    }

    // GET: DiabetesRiskController
    public async Task<ActionResult> Index(string householdNo)
    {
        var list = await _diabetesRiskService.GetDiabetesRiskWithDetails(householdNo);
        return View(list);
    }

    // GET: DiabetesRiskController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: DiabetesRiskController/Create
    public ActionResult Create()
    {
        return View();
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

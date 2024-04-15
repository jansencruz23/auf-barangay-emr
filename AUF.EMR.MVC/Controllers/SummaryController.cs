using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AUF.EMR.MVC.Controllers
{
    public class SummaryController : Controller
    {
        private readonly ISummaryService _dashboardService;
        private readonly IHttpContextAccessor _httpContext;

        public SummaryController(ISummaryService dashboardService,
            IHttpContextAccessor httpContext)
        {
            _dashboardService = dashboardService;
            _httpContext = httpContext;
        }

        // GET: SummaryController
        public async Task<ActionResult> Index()
        {
            var user = _httpContext.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (user == null) 
            {
                return View();
            }

            var userId = Guid.Parse(user);
            var totalChecked = await _dashboardService.GetAllCheckedToday(userId);
            var model = new SummaryVM
            {
                NewbornCount = await _dashboardService.GetCheckedNewbornToday(userId),
                InfantCount = await _dashboardService.GetCheckedInfantToday(userId),
                UnderFiveCount = await _dashboardService.GetCheckedUnderFiveToday(userId),
                SchoolAgedCount = await _dashboardService.GetCheckedSchoolAgedToday(userId),
                AdolescentCount = await _dashboardService.GetCheckedAdolescentToday(userId),
                AdultCount = await _dashboardService.GetCheckedAdultToday(userId),
                SeniorCount = await _dashboardService.GetCheckedSeniorToday(userId),
                TotalRecords = totalChecked
            };

            return View(model);
        }

        // GET: SummaryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SummaryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SummaryController/Create
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

        // GET: SummaryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SummaryController/Edit/5
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

        // GET: SummaryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SummaryController/Delete/5
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

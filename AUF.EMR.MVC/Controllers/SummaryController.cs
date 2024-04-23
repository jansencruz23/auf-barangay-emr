using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class SummaryController : Controller
    {
        private readonly ISummaryService _dashboardService;
        private readonly IBarangayService _brgyService;
        private readonly IHttpContextAccessor _httpContext;

        public SummaryController(ISummaryService dashboardService,
            IBarangayService brgyService,
            IHttpContextAccessor httpContext)
        {
            _dashboardService = dashboardService;
            _brgyService = brgyService;
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
                TotalRecords = totalChecked,
                Barangay = await _brgyService.GetBarangay()
            };

            return View(model);
        }
    }
}

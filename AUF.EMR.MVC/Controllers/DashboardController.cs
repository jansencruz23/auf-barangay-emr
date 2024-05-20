using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IHouseholdService _householdService;

        public DashboardController(IDashboardService dashboardService,
            IHouseholdService householdService)
        {
            _dashboardService = dashboardService;
            _householdService = householdService;
        }

        // GET: DashboardController/Barangay
        public async Task<ActionResult> Barangay()
        {
            var model = new DashboardVM
            {
                HouseholdCount = await _dashboardService.GetHouseholdCount(),
                HouseholdMemberCount = await _dashboardService.GetHouseholdMemberCount(),
                NewbornCount = await _dashboardService.GetNewbornCount(),
                InfantCount = await _dashboardService.GetInfantCount(),
                UnderFiveCount = await _dashboardService.GetUnderFiveCount(),
                SchoolAgedCount = await _dashboardService.GetSchoolAgedCount(),
                AdolescentsCount = await _dashboardService.GetAdolescentCount(),
                AdultCount = await _dashboardService.GetAdultsCount(),
                SeniorCount = await _dashboardService.GetSeniorCount(),
            };

            return View(model);
        }

        // GET: DashboardController/Household/5
        public async Task<ActionResult> Household(string householdNo)
        {
            var householdExisting = await _householdService.IsHouseholdNoExisting(householdNo);
            if (!householdExisting)
            {
                return NotFound();
            }

            var model = new DashboardVM
            {
                HouseholdMemberCount = await _dashboardService.GetHouseholdMemberCount(householdNo),
                NewbornCount = await _dashboardService.GetNewbornCount(householdNo),
                InfantCount = await _dashboardService.GetInfantCount(householdNo),
                UnderFiveCount = await _dashboardService.GetUnderFiveCount(householdNo),
                SchoolAgedCount = await _dashboardService.GetSchoolAgedCount(householdNo),
                AdolescentsCount = await _dashboardService.GetAdolescentCount(householdNo),
                AdultCount = await _dashboardService.GetAdultsCount(householdNo),
                SeniorCount = await _dashboardService.GetSeniorCount(householdNo),
            };

            return View(model);
        }
    }
}

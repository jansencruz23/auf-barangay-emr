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
        private readonly IDashboardService _summaryService;

        public DashboardController(IDashboardService summaryService)
        {
            _summaryService = summaryService;
        }

        // GET: DashboardController/Barangay
        public async Task<ActionResult> Barangay()
        {
            var model = new DashboardVM
            {
                HouseholdCount = await _summaryService.GetHouseholdCount(),
                HouseholdMemberCount = await _summaryService.GetHouseholdMemberCount(),
                NewbornCount = await _summaryService.GetNewbornCount(),
                InfantCount = await _summaryService.GetInfantCount(),
                UnderFiveCount = await _summaryService.GetUnderFiveCount(),
                SchoolAgedCount = await _summaryService.GetSchoolAgedCount(),
                AdolescentsCount = await _summaryService.GetAdolescentCount(),
                AdultCount = await _summaryService.GetAdultsCount(),
                SeniorCount = await _summaryService.GetSeniorCount(),
            };

            return View(model);
        }

        // GET: DashboardController/Household/5
        public async Task<ActionResult> Household(string householdNo)
        {
            var model = new DashboardVM
            {
                HouseholdMemberCount = await _summaryService.GetHouseholdMemberCount(householdNo),
                NewbornCount = await _summaryService.GetNewbornCount(householdNo),
                InfantCount = await _summaryService.GetInfantCount(householdNo),
                UnderFiveCount = await _summaryService.GetUnderFiveCount(householdNo),
                SchoolAgedCount = await _summaryService.GetSchoolAgedCount(householdNo),
                AdolescentsCount = await _summaryService.GetAdolescentCount(householdNo),
                AdultCount = await _summaryService.GetAdultsCount(householdNo),
                SeniorCount = await _summaryService.GetSeniorCount(householdNo),
            };

            return View(model);
        }
    }
}

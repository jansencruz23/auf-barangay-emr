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
        private readonly IBarangayService _brgyService;

        public DashboardController(IDashboardService dashboardService,
            IHouseholdService householdService,
            IBarangayService brgyService)
        {
            _dashboardService = dashboardService;
            _householdService = householdService;
            _brgyService = brgyService;
        }

        // GET: DashboardController/Barangay
        public async Task<ActionResult> Barangay()
        {
            try
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
                    PregnantCount = await _dashboardService.GetPregnantCount(),
                    WRAFormCount = await _dashboardService.GetWRAFormCount(),
                    PregTrackCount = await _dashboardService.GetPregnancyTrackingFormCount(),
                    FamilyPlanningFormsCount = await _dashboardService.GetFamilyPlanningFormCount(),
                    PatientRecordCount = await _dashboardService.GetPatientRecordCount(),
                    PregnancyRecordCount = await _dashboardService.GetPregnancyRecordCount(),
                    HHCount1 = await _dashboardService.GetHouseholdCount(1),
                    HHCount2 = await _dashboardService.GetHouseholdCount(2,2),
                    HHCount3 = await _dashboardService.GetHouseholdCount(3,3),
                    HHCount4 = await _dashboardService.GetHouseholdCount(4,4),
                    HHCount5 = await _dashboardService.GetHouseholdCount(5,5),
                    HHCount6 = await _dashboardService.GetHouseholdCount(6,6),
                    HHCount7 = await _dashboardService.GetHouseholdCount(7,7),
                    Barangay = (await _brgyService.GetBarangay()).BarangayName
                };

                return View(model);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Invalid", "Error", new { message = ex.Message });
            }
        }

        // GET: DashboardController/Household/5
        public async Task<ActionResult> Household(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            var householdExisting = await _householdService.IsHouseholdNoExisting(householdNo);
            if (!householdExisting)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            var model = new DashboardVM
            {
                HouseholdNo = householdNo,
                HouseholdMemberCount = await _dashboardService.GetHouseholdMemberCount(householdNo),
                NewbornCount = await _dashboardService.GetNewbornCount(householdNo),
                InfantCount = await _dashboardService.GetInfantCount(householdNo),
                UnderFiveCount = await _dashboardService.GetUnderFiveCount(householdNo),
                SchoolAgedCount = await _dashboardService.GetSchoolAgedCount(householdNo),
                AdolescentsCount = await _dashboardService.GetAdolescentCount(householdNo),
                AdultCount = await _dashboardService.GetAdultsCount(householdNo),
                SeniorCount = await _dashboardService.GetSeniorCount(householdNo),
                PregnantCount = await _dashboardService.GetPregnantCount(householdNo),
                WRAFormCount = await _dashboardService.GetWRAFormCount(householdNo),
                PregTrackCount = await _dashboardService.GetPregnancyTrackingFormCount(householdNo),
                FamilyPlanningFormsCount = await _dashboardService.GetFamilyPlanningFormCount(householdNo),
                PatientRecordCount = await _dashboardService.GetPatientRecordCount(householdNo),
                PregnancyRecordCount = await _dashboardService.GetPregnancyRecordCount(householdNo),
            };

            return View(model);
        }
    }
}

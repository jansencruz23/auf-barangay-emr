using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models.Enums;
using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Constants;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class SummaryController : Controller
    {
        private readonly ISummaryService _summaryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public SummaryController(ISummaryService summaryService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _summaryService = summaryService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index(string householdNo)
        {
            try
            {
                var userId = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var user = (await _userManager.GetUserAsync(User)).FirstName;

                if (user == null)
                {
                    return RedirectToAction("PageNotFound", "Error");
                }

                var model = new SummaryVM
                {
                    TotalDay1 = await _summaryService.GetTotalFormsCount(DateRange.Daily, DaysOffset.OFFSET1, userId),
                    TotalDay2 = await _summaryService.GetTotalFormsCount(DateRange.Daily, DaysOffset.OFFSET2, userId),
                    TotalDay3 = await _summaryService.GetTotalFormsCount(DateRange.Daily, DaysOffset.OFFSET3, userId),
                    TotalDay4 = await _summaryService.GetTotalFormsCount(DateRange.Daily, DaysOffset.OFFSET4, userId),
                    TotalDay5 = await _summaryService.GetTotalFormsCount(DateRange.Daily, DaysOffset.OFFSET5, userId),
                    TotalDay6 = await _summaryService.GetTotalFormsCount(DateRange.Daily, DaysOffset.OFFSET6, userId),
                    TotalDay7 = await _summaryService.GetTotalFormsCount(DateRange.Daily, DaysOffset.OFFSET7, userId),
                    HouseholdNo = householdNo,
                    Name = user,
                    TotalForms = await _summaryService.GetTotalFormsCount(DateRange.Daily, userId),
                    HHForms = await _summaryService.GetFormsCount(FormType.Household, DateRange.Daily, userId),
                    HHMembers = await _summaryService.GetFormsCount(FormType.HouseholdMember, DateRange.Daily, userId),
                    WRAForms = await _summaryService.GetFormsCount(FormType.WomanOfReproductiveAge, DateRange.Daily, userId),
                    PregTrackForms = await _summaryService.GetFormsCount(FormType.PregnancyTracking, DateRange.Daily, userId),
                    FPForms = await _summaryService.GetFormsCount(FormType.FamilyPlanningRecord, DateRange.Daily, userId),
                    PatientForms = await _summaryService.GetFormsCount(FormType.PatientRecord, DateRange.Daily, userId),
                    VaccinationAppointments = await _summaryService.GetFormsCount(FormType.VaccinationAppointment, DateRange.Daily, userId),
                    PregForms = await _summaryService.GetFormsCount(FormType.PregnancyRecord, DateRange.Daily, userId),
                    PregAppointments = await _summaryService.GetFormsCount(FormType.PregnancyAppointment, DateRange.Daily, userId),
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Invalid", "Error", new { ex.Message });
            }
        }

        public async Task<ActionResult> Weekly(string householdNo)
        {
            try
            {
                var userId = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var user = (await _userManager.GetUserAsync(User)).FirstName;

                if (user == null)
                {
                    return RedirectToAction("PageNotFound", "Error");
                }

                var model = new SummaryVM
                {
                    TotalDay1 = await _summaryService.GetTotalFormsCount(DateRange.Weekly, DaysOffset.OFFSET1, userId),
                    TotalDay2 = await _summaryService.GetTotalFormsCount(DateRange.Weekly, DaysOffset.OFFSET2, userId),
                    TotalDay3 = await _summaryService.GetTotalFormsCount(DateRange.Weekly, DaysOffset.OFFSET3, userId),
                    TotalDay4 = await _summaryService.GetTotalFormsCount(DateRange.Weekly, DaysOffset.OFFSET4, userId),
                    TotalDay5 = await _summaryService.GetTotalFormsCount(DateRange.Weekly, DaysOffset.OFFSET5, userId),
                    TotalDay6 = await _summaryService.GetTotalFormsCount(DateRange.Weekly, DaysOffset.OFFSET6, userId),
                    TotalDay7 = await _summaryService.GetTotalFormsCount(DateRange.Weekly, DaysOffset.OFFSET7, userId),
                    HouseholdNo = householdNo,
                    Name = user,
                    TotalForms = await _summaryService.GetTotalFormsCount(DateRange.Weekly, userId),
                    HHForms = await _summaryService.GetFormsCount(FormType.Household, DateRange.Weekly, userId),
                    HHMembers = await _summaryService.GetFormsCount(FormType.HouseholdMember, DateRange.Weekly, userId),
                    WRAForms = await _summaryService.GetFormsCount(FormType.WomanOfReproductiveAge, DateRange.Weekly, userId),
                    PregTrackForms = await _summaryService.GetFormsCount(FormType.PregnancyTracking, DateRange.Weekly, userId),
                    FPForms = await _summaryService.GetFormsCount(FormType.FamilyPlanningRecord, DateRange.Weekly, userId),
                    PatientForms = await _summaryService.GetFormsCount(FormType.PatientRecord, DateRange.Weekly, userId),
                    VaccinationAppointments = await _summaryService.GetFormsCount(FormType.VaccinationAppointment, DateRange.Weekly, userId),
                    PregForms = await _summaryService.GetFormsCount(FormType.PregnancyRecord, DateRange.Weekly, userId),
                    PregAppointments = await _summaryService.GetFormsCount(FormType.PregnancyAppointment, DateRange.Weekly, userId),
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Invalid", "Error", new { ex.Message });
            }
        }

        public async Task<ActionResult> Monthly(string householdNo)
        {
            try
            {
                var userId = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var user = (await _userManager.GetUserAsync(User)).FirstName;

                if (user == null)
                {
                    return RedirectToAction("PageNotFound", "Error");
                }

                var model = new SummaryVM
                {
                    TotalDay1 = await _summaryService.GetTotalFormsCount(DateRange.Monthly, DaysOffset.OFFSET1, userId),
                    TotalDay2 = await _summaryService.GetTotalFormsCount(DateRange.Monthly, DaysOffset.OFFSET2, userId),
                    TotalDay3 = await _summaryService.GetTotalFormsCount(DateRange.Monthly, DaysOffset.OFFSET3, userId),
                    TotalDay4 = await _summaryService.GetTotalFormsCount(DateRange.Monthly, DaysOffset.OFFSET4, userId),
                    TotalDay5 = await _summaryService.GetTotalFormsCount(DateRange.Monthly, DaysOffset.OFFSET5, userId),
                    TotalDay6 = await _summaryService.GetTotalFormsCount(DateRange.Monthly, DaysOffset.OFFSET6, userId),
                    TotalDay7 = await _summaryService.GetTotalFormsCount(DateRange.Monthly, DaysOffset.OFFSET7, userId),
                    HouseholdNo = householdNo,
                    Name = user,
                    TotalForms = await _summaryService.GetTotalFormsCount(DateRange.Monthly, userId),
                    HHForms = await _summaryService.GetFormsCount(FormType.Household, DateRange.Monthly, userId),
                    HHMembers = await _summaryService.GetFormsCount(FormType.HouseholdMember, DateRange.Monthly, userId),
                    WRAForms = await _summaryService.GetFormsCount(FormType.WomanOfReproductiveAge, DateRange.Monthly, userId),
                    PregTrackForms = await _summaryService.GetFormsCount(FormType.PregnancyTracking, DateRange.Monthly, userId),
                    FPForms = await _summaryService.GetFormsCount(FormType.FamilyPlanningRecord, DateRange.Monthly, userId),
                    PatientForms = await _summaryService.GetFormsCount(FormType.PatientRecord, DateRange.Monthly, userId),
                    VaccinationAppointments = await _summaryService.GetFormsCount(FormType.VaccinationAppointment, DateRange.Monthly, userId),
                    PregForms = await _summaryService.GetFormsCount(FormType.PregnancyRecord, DateRange.Monthly, userId),
                    PregAppointments = await _summaryService.GetFormsCount(FormType.PregnancyAppointment, DateRange.Monthly, userId),
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Invalid", "Error", new { ex.Message });
            }
        }
    }
}

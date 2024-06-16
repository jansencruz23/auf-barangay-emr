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

                if (user == null || userId == null)
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
                    PregAppointments = await _summaryService.GetFormsCount(FormType.PregnancyRecord, DateRange.Daily, userId),
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

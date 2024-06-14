using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models.Enums;
using AUF.EMR.Domain.Models.Identity;
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

        public async Task<ActionResult> Index()
        {
            try
            {
                var userId = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var user = (await _userManager.GetUserAsync(User)).FullName;

                if (user == null || userId == null)
                {
                    return RedirectToAction("PageNotFound", "Error");
                }

                var model = new SummaryVM
                {
                    TotalForms = await _summaryService.GetTotalFormsCount(DateRange.Daily, userId),
                    CreatedHHForms = await _summaryService.GetCreatedFormsCount(FormType.Household, DateRange.Daily, userId),
                    CreatedHHMembers = await _summaryService.GetCreatedFormsCount(FormType.HouseholdMember, DateRange.Daily, userId),
                    CreatedWRAForms = await _summaryService.GetCreatedFormsCount(FormType.WomanOfReproductiveAge, DateRange.Daily, userId),
                    CreatedPregTrackForms = await _summaryService.GetCreatedFormsCount(FormType.PregnancyTracking, DateRange.Daily, userId),
                    CreatedFPForms = await _summaryService.GetCreatedFormsCount(FormType.FamilyPlanningRecord, DateRange.Daily, userId),
                    CreatedPatientForms = await _summaryService.GetCreatedFormsCount(FormType.PatientRecord, DateRange.Daily, userId),
                    CreatedVaccinationAppointments = await _summaryService.GetCreatedFormsCount(FormType.PatientRecord, DateRange.Daily, userId),
                    CreatedPregForms = await _summaryService.GetCreatedFormsCount(FormType.PregnancyRecord, DateRange.Daily, userId),
                    CreatedPregAppointments = await _summaryService.GetCreatedFormsCount(FormType.PregnancyRecord, DateRange.Daily, userId),
                    ModifiedHHForms = await _summaryService.GetModifiedFormsCount(FormType.Household, DateRange.Daily, userId),
                    ModifiedHHMembers = await _summaryService.GetModifiedFormsCount(FormType.HouseholdMember, DateRange.Daily, userId),
                    ModifiedWRAForms = await _summaryService.GetModifiedFormsCount(FormType.WomanOfReproductiveAge, DateRange.Daily, userId),
                    ModifiedPregTrackForms = await _summaryService.GetModifiedFormsCount(FormType.PregnancyTracking, DateRange.Daily, userId),
                    ModifiedPatientForms = await _summaryService.GetModifiedFormsCount(FormType.PatientRecord, DateRange.Daily, userId),
                    ModifiedVaccinationAppointments = await _summaryService.GetModifiedFormsCount(FormType.PatientRecord, DateRange.Daily, userId),
                    ModifiedPregForms = await _summaryService.GetModifiedFormsCount(FormType.PregnancyRecord, DateRange.Daily, userId),
                    ModifiedPregAppointments = await _summaryService.GetModifiedFormsCount(FormType.PregnancyRecord, DateRange.Daily, userId),
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

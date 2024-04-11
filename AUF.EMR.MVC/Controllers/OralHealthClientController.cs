using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.MVC.Models.IndexVM;
using AUF.EMR.MVC.Models.PrintVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class OralHealthClientController : Controller
    {
        private readonly IOralHealthService _oralHealthService;

        public OralHealthClientController(IOralHealthService oralHealthService)
        {
            _oralHealthService = oralHealthService;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: OralHealthClientController/Infant
        public async Task<ActionResult> Infant(string householdNo)
        {
            var members = await _oralHealthService.GetOralClientInfant(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo
            };
            return View(model);
        }

        // GET: OralHealthClientController/OneToFour
        public async Task<ActionResult> OneToFour(string householdNo)
        {
            var members = await _oralHealthService.GetOralClient1to4(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo
            };
            return View(model);
        }

        // GET: OralHealthClientController/FiveToNine
        public async Task<ActionResult> FiveToNine(string householdNo)
        {
            var members = await _oralHealthService.GetOralClient5to9(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo
            };
            return View(model);
        }

        // GET: OralHealthClientController/TenToFourteen
        public async Task<ActionResult> TenToFourteen(string householdNo)
        {
            var members = await _oralHealthService.GetOralClient10to14(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo
            };
            return View(model);
        }

        // GET: OralHealthClientController/FifteenToNineteen
        public async Task<ActionResult> FifteenToNineteen(string householdNo)
        {
            var members = await _oralHealthService.GetOralClient15to19(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo
            };
            return View(model);
        }

        // GET: OralHealthClientController/TwentyToFourtynine
        public async Task<ActionResult> TwentyToFourtynine(string householdNo)
        {
            var members = await _oralHealthService.GetOralClient20to49(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo
            };
            return View(model);
        }

        // GET: OralHealthClientController/PregnantFifteenToNineteen
        public async Task<ActionResult> PregnantFifteenToNineteen(string householdNo)
        {
            var members = await _oralHealthService.GetOralClientPregnant15to19(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo
            };
            return View(model);
        }

        // GET: OralHealthClientController/PregnantTwentyToFourtynine
        public async Task<ActionResult> PregnantTwentyToFourtynine(string householdNo)
        {
            var members = await _oralHealthService.GetOralClientPregnant20to49(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo
            };
            return View(model);
        }

        public async Task<ActionResult> Print(string householdNo, string requestUrl)
        {
            var model = new PrintOralListVM
            {
                Infants = await _oralHealthService.GetOralClientInfant(householdNo),
                OneToFour = await _oralHealthService.GetOralClient1to4(householdNo),
                FiveToNine = await _oralHealthService.GetOralClient5to9(householdNo),
                TenToFourteen = await _oralHealthService.GetOralClient10to14(householdNo),
                PregnantFifteenToNineteen = await _oralHealthService.GetOralClientPregnant15to19(householdNo),
                PregnantTwentyToFourtyNine = await _oralHealthService.GetOralClientPregnant20to49(householdNo),
                RequestUrl = requestUrl
            };

            return View(model);
        }
    }
}

using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using AUF.EMR.MVC.Models.PrintVM;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class MasterlistController : Controller
    {
        private readonly IMasterlistService _masterlistService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBarangayService _brgyService;
        private readonly IHouseholdMemberService _householdMemberService;

        public MasterlistController(IMasterlistService masterlistService,
            UserManager<ApplicationUser> userManager,
            IBarangayService brgyService,
            IHouseholdMemberService householdMemberService)
        {
            _masterlistService = masterlistService;
            _userManager = userManager;
            _brgyService = brgyService;
            _householdMemberService = householdMemberService;
        }

        // GET: MasterlistController/EditChildrenInfo
        public async Task<ActionResult> EditChildrenInfo(int id, string requestUrl)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _householdMemberService.GetHouseholdMemberWithDetails(id);

            if (member == null)
            {
                return NotFound();
            }

            var model = new EditChildrenInfoVM
            {
                HouseholdMember = member,
                RequestUrl = requestUrl
            };

            return View(model);
        }

        // POST: MasterlistController/EditChildrenInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditChildrenInfo(EditChildrenInfoVM model)
        {
            if (model == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var member = model.HouseholdMember;
                await _householdMemberService.Update(member);

                return Redirect(model.RequestUrl);
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // GET: MasterlistController/Newborn
        public async Task<ActionResult> Newborn(string householdNo)
        {
            var members = await _masterlistService.GetMasterlistNewborn(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: MasterlistController/Infant
        public async Task<ActionResult> Infant(string householdNo)
        {
            var members = await _masterlistService.GetMasterlistInfant(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: MasterlistController/UnderFive
        public async Task<ActionResult> UnderFive(string householdNo)
        {
            var members = await _masterlistService.GetMasterlistUnderFive(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: MasterlistController/SchoolAged
        public async Task<ActionResult> SchoolAged(string householdNo)
        {
            var members = await _masterlistService.GetMasterlistSchoolAge(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: MasterlistController/Adolescent
        public async Task<ActionResult> Adolescent(string householdNo)
        {
            var members = await _masterlistService.GetMasterlistAdolescent(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: MasterlistController/Adult
        public async Task<ActionResult> Adult(string householdNo)
        {
            var members = await _masterlistService.GetMasterlistAdult(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: MasterlistController/SeniorCitizen
        public async Task<ActionResult> SeniorCitizen(string householdNo)
        {
            var members = await _masterlistService.GetMasterlistSeniorCitizen(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        public async Task<ActionResult> PrintChildren(string householdNo, string requestUrl)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new PrintChildrenMasterlistVM
            {
                Newborns = await _masterlistService.GetMasterlistNewborn(householdNo),
                Infants = await _masterlistService.GetMasterlistInfant(householdNo),
                UnderFive = await _masterlistService.GetMasterlistUnderFive(householdNo),
                SchoolAged = await _masterlistService.GetMasterlistSchoolAge(householdNo),
                Adolescents = await _masterlistService.GetMasterlistAdolescent(householdNo),
                RequestUrl = requestUrl,
                Midwife = user.FullName,
                Barangay = await _brgyService.GetBarangay()
            };

            return View(model);
        }

        public async Task<ActionResult> PrintAdults(string householdNo, string requestUrl)
        {
            var model = new PrintAdultsMasterlistVM
            {
                Adults = await _masterlistService.GetMasterlistAdult(householdNo),
                RequestUrl = requestUrl,
                Barangay = await _brgyService.GetBarangay()
            };

            return View(model);
        }

        public async Task<ActionResult> PrintSeniors(string householdNo, string requestUrl)
        {
            var model = new PrintAdultsMasterlistVM
            {
                Adults = await _masterlistService.GetMasterlistSeniorCitizen(householdNo),
                RequestUrl = requestUrl,
                Barangay = await _brgyService.GetBarangay()
            };

            return View(model);
        }
    }
}

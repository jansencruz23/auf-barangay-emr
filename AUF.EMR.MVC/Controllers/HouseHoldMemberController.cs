using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models;
using AUF.EMR.MVC.Models.CreateVM;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using AUF.EMR.MVC.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class HouseholdMemberController : Controller
    {
        private readonly IHouseholdMemberService _houseHoldMemberService;
        private readonly IHouseholdService _houseHoldService;
        private readonly IMapper _mapper;

        public HouseholdMemberController(IHouseholdMemberService houseHoldMemberService,
            IHouseholdService houseHoldService, IMapper mapper)
        {
            _houseHoldMemberService = houseHoldMemberService;
            _houseHoldService = houseHoldService;
            _mapper = mapper;
        }

        // GET: HouseHoldMemberController
        public async Task<ActionResult> Index(int id)
        {
            var household = await _houseHoldService.GetHouseholdWithDetails(id);
            if (household == null)
            {
                return NotFound();
            }

            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = household.HouseholdMembers,
                Household = household,
            };

            return View(model);
        }

        // GET: HouseHoldMemberController/Details/5
        public async Task<ActionResult> Details(int id, string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            try
            {
                var member = await _houseHoldMemberService.GetHouseholdMemberWithDetails(id);
                if (member == null)
                {
                    return RedirectToAction("PageNotFound", "Error");
                }

                var model = new DetailHouseholdMemberVM
                {
                    HouseholdMember = member,
                    HouseholdNo = householdNo,
                    RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                    FirstClassificationList = new ClassificationService().GetClassificationString(member.FirstQtrClassification),
                    SecondClassificationList = new ClassificationService().GetClassificationString(member.SecondQtrClassification),
                    ThirdClassificationList = new ClassificationService().GetClassificationString(member.ThirdQtrClassification),
                    FourthClassificationList = new ClassificationService().GetClassificationString(member.FourthQtrClassification),
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Invalid", "Error", new { message = ex.Message });
            }
        }

        // GET: HouseHoldMemberController/Create
        public async Task<ActionResult> Create(string householdNo)
        {
            var householdId = await _houseHoldService.GetHouseholdId(householdNo);
            var classifications = new ClassificationService().GetClassifications();

            var model = new CreateHouseholdMemberVM
            {
                HouseholdNo = householdNo,
                HouseholdId = householdId,
                Classifications = classifications,
                FirstQtrClassifications = classifications,
                SecondQtrClassifications = classifications,
                ThirdQtrClassifications = classifications,
                FourthQtrClassifications = classifications,
            };

            return View(model);
        }

        // POST: HouseHoldMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHouseholdMemberVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                if (model == null)
                {
                    return NotFound();
                }

                var firstQtrClassification = _houseHoldMemberService.GetClassifications(model.FirstQtrClassifications);
                var secondQtrClassification = _houseHoldMemberService.GetClassifications(model.SecondQtrClassifications);
                var thirdQtrClassification = _houseHoldMemberService.GetClassifications(model.ThirdQtrClassifications);
                var fourthQtrClassification = _houseHoldMemberService.GetClassifications(model.FourthQtrClassifications);

                var householdMember = model.HouseholdMember;

                householdMember.Age = $"{householdMember.Age} {model.AgeSuffix}";
                householdMember.FirstQtrClassification = firstQtrClassification;
                householdMember.SecondQtrClassification = secondQtrClassification;
                householdMember.ThirdQtrClassification = thirdQtrClassification;
                householdMember.FourthQtrClassification = fourthQtrClassification;

                var completed = await _houseHoldMemberService.Add(householdMember);

                return RedirectToAction("HouseholdProfile", nameof(Household), new { householdNo = model.HouseholdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // GET: HouseHoldMemberController/Edit/5
        public async Task<ActionResult> Edit(int id, string householdNo, string requestUrl)
        {
            if (id == 0)
            {
                return NotFound();
            }

            try
            {
                var member = await _houseHoldMemberService.GetHouseholdMemberWithDetails(id);

                if (member == null)
                {
                    return NotFound();
                }

                var classificationService = new ClassificationService();
                var classifications = classificationService.GetClassifications();               
                var ageParts = member.Age.Split(" ");
                var ageSuffix = ageParts.Length < 2 ? "yrs" : ageParts[1];
                int.TryParse(ageParts[0], out int age);

                var model = new EditHouseholdMemberVM
                {
                    HouseholdMember = member,
                    HouseholdNo = member.Household.HouseholdNo,
                    AgePrefix = age,
                    RequestUrl = requestUrl,
                    AgeSuffix = ageSuffix,
                    Classifications = classifications,
                    FirstQtrClassifications = new ClassificationService().MapSelected(member.FirstQtrClassification),
                    SecondQtrClassifications = new ClassificationService().MapSelected(member.SecondQtrClassification),
                    ThirdQtrClassifications = new ClassificationService().MapSelected(member.ThirdQtrClassification),
                    FourthQtrClassifications = new ClassificationService().MapSelected(member.FourthQtrClassification),
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: HouseHoldMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditHouseholdMemberVM model)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var firstQtrClassification = _houseHoldMemberService.GetClassifications(model.FirstQtrClassifications);
                var secondQtrClassification = _houseHoldMemberService.GetClassifications(model.SecondQtrClassifications);
                var thirdQtrClassification = _houseHoldMemberService.GetClassifications(model.ThirdQtrClassifications);
                var fourthQtrClassification = _houseHoldMemberService.GetClassifications(model.FourthQtrClassifications);

                var householdMember = model.HouseholdMember;
                householdMember.Age = $"{model.AgePrefix} {model.AgeSuffix}";

                householdMember.FirstQtrClassification = firstQtrClassification;
                householdMember.SecondQtrClassification = secondQtrClassification;
                householdMember.ThirdQtrClassification = thirdQtrClassification;
                householdMember.FourthQtrClassification = fourthQtrClassification;

                var completed = await _houseHoldMemberService.Update(householdMember);

                if (!string.IsNullOrEmpty(model.RequestUrl)
                    && Url.IsLocalUrl(model.RequestUrl))
                {
                    return Redirect(model.RequestUrl);
                }

                return RedirectToAction(nameof(Edit), nameof(Household), new { id = model.HouseholdMember.HouseholdId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // POST: HouseHoldMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string householdNo)
        {
            try
            {
                var member = await _houseHoldMemberService.Get(id);
                if (member == null)
                {
                    return NotFound();
                }
                 
                await _houseHoldMemberService.DeleteHouseholdMember(id);
                return RedirectToAction("HouseholdProfile", "Household", new { householdNo = householdNo });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }
    }
}

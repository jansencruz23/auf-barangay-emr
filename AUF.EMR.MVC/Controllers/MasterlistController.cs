using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.IndexVM;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AUF.EMR.MVC.Controllers
{
    public class MasterlistController : Controller
    {
        private readonly IMasterlistService _masterlistService;
        private readonly IMapper _mapper;

        public MasterlistController(IMasterlistService masterlistService,
            IMapper mapper)
        {
            _masterlistService = masterlistService;
            _mapper = mapper;
        }

        // GET: MasterlistController
        public async Task<ActionResult> Index(string householdNo)
        {
            return View();
        }

        // GET: MasterlistController/Newborn
        public async Task<ActionResult> Newborn(string householdNo)
        {
            var members = await _masterlistService.GetMasterlistNewborn(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString
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
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString
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
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString
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
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString
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
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString
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
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString
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
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString
            };
            return View(model);
        }

        // GET: MasterlistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterlistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterlistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterlistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MasterlistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterlistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterlistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var newborns = await _masterlistService.GetMasterlistNewborn(householdNo);
            var model = _mapper.Map<List<HouseholdMember>>(newborns);
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

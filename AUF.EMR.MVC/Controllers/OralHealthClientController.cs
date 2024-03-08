using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
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
            var clients = await _oralHealthService.GetOralClientInfant(householdNo);
            return View(clients);
        }

        // GET: OralHealthClientController/OneToFour
        public async Task<ActionResult> OneToFour(string householdNo)
        {
            var clients = await _oralHealthService.GetOralClient1to4(householdNo);
            return View(clients);
        }

        // GET: OralHealthClientController/FiveToNine
        public async Task<ActionResult> FiveToNine(string householdNo)
        {
            var clients = await _oralHealthService.GetOralClient5to9(householdNo);
            return View(clients);
        }

        // GET: OralHealthClientController/TenToFourteen
        public async Task<ActionResult> TenToFourteen(string householdNo)
        {
            var clients = await _oralHealthService.GetOralClient10to14(householdNo);
            return View(clients);
        }

        // GET: OralHealthClientController/FifteenToNineteen
        public async Task<ActionResult> FifteenToNineteen(string householdNo)
        {
            var clients = await _oralHealthService.GetOralClient15to19(householdNo);
            return View(clients);
        }

        // GET: OralHealthClientController/TwentyToFourtynine
        public async Task<ActionResult> TwentyToFourtynine(string householdNo)
        {
            var clients = await _oralHealthService.GetOralClient20to49(householdNo);
            return View(clients);
        }

        // GET: OralHealthClientController/PregnantFifteenToNineteen
        public async Task<ActionResult> PregnantFourteenToNineteen(string householdNo)
        {
            var clients = await _oralHealthService.GetOralClientPregnant15to19(householdNo);
            return View(clients);
        }

        // GET: OralHealthClientController/PregnantTwentyToFourtynine
        public async Task<ActionResult> PregnantTwentyToFourtynine(string householdNo)
        {
            var clients = await _oralHealthService.GetOralClientPregnant20to49(householdNo);
            return View(clients);
        }

        // GET: OralHealthClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OralHealthClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OralHealthClientController/Create
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

        // GET: OralHealthClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OralHealthClientController/Edit/5
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

        // GET: OralHealthClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OralHealthClientController/Delete/5
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

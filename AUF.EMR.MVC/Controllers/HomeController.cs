using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AUF.EMR.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBarangayService _brgyService;

        public HomeController(ILogger<HomeController> logger,
            IBarangayService brgyService)
        {
            _logger = logger;
            _brgyService = brgyService;
        }

        public async Task<IActionResult> Index()
        {
            var barangay = await _brgyService.GetBarangay();
            return View(barangay);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
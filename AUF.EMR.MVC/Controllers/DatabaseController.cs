using AUF.EMR.Application.Contracts.Services.Data;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly IDatabaseExportService _databaseService;

        public DatabaseController(IDatabaseExportService databaseService)
        {
            _databaseService = databaseService;    
        }

        public IActionResult Export()
        {
            try
            {
                _databaseService.ExportDatabase();
                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

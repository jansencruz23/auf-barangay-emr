using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.MVC.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        // GET: RecordController
        //public async Task<ActionResult> Index()
        //{
        //    var record = await _recordService.GetRecords(DateRecord.)
        //    return View();
        //}
    }
}

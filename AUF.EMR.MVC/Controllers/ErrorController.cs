using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound(string requestUrl = "")
        {
            return View(requestUrl);
        }

        public IActionResult Invalid()
        {
            return View();
        }
    }
}

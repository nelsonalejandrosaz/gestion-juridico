using System.Diagnostics;
using GestionJuridico.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            switch (code)
            {
                case 403:
                    return View("403");
                case 404:
                    return View("403");
                case 500:
                    return View("500");
                default:
                    ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";
                    return View("~/Views/Shared/Error.cshtml");
            }
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }
    }
}

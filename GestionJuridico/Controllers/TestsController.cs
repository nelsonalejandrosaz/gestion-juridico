using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

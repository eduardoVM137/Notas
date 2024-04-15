using Microsoft.AspNetCore.Mvc;

namespace Notas.Controllers
{
    public class CalendarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

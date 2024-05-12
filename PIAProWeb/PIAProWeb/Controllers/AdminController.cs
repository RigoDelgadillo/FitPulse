using Microsoft.AspNetCore.Mvc;

namespace PIAProWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult CRUDUsuarios()
        {
            return View();
        }
        public IActionResult CRUDRutinas()
        {
            return View();
        }
        public IActionResult ReporteDeVentas()
        {
            return View();
        }
        public IActionResult MenuAdmin()
        {
            return View();
        }
    }
}

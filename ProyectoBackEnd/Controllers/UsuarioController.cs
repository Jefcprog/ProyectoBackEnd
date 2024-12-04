using Microsoft.AspNetCore.Mvc;

namespace ProyectoBackEnd.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

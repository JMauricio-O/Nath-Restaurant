using Microsoft.AspNetCore.Mvc;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaReservaHorarios.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View(); // Página só para Admin
        }

        [Authorize(Roles = "Cliente")]
        public IActionResult Cliente()
        {
            return View(); // Página só para Cliente
        }

        [Authorize] // Qualquer usuário logado
        public IActionResult Index()
        {
            return View(); // Página para qualquer usuário autenticado
        }
    }
}

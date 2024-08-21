using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

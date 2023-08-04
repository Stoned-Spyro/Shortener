using Microsoft.AspNetCore.Mvc;

namespace Shortener.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}

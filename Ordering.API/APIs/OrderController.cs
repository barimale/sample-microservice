using Microsoft.AspNetCore.Mvc;

namespace Ordering.API.APIs
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

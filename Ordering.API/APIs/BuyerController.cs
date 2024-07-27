using Microsoft.AspNetCore.Mvc;

namespace Ordering.API.APIs
{
    public class BuyerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

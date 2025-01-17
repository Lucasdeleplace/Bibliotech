using Microsoft.AspNetCore.Mvc;

namespace bibliotech.Controllers
{
    public class MembreController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}

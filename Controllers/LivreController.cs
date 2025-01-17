using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;


namespace bibliotech.Controllers
{
    public class LivreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateEditLivre()
        {
            return View();
        }
        
        public IActionResult CreateEditLivreForm(Livre model)
        {
           return RedirectToAction ("Index");
        }

    }
}

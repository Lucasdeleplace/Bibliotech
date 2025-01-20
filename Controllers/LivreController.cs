using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace bibliotech.Controllers
{
    public class LivreController : Controller

    {
        private readonly BibliotechDb _db;

        public LivreController(BibliotechDb db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            var allLivre = _db.Livres.ToList();
                return View(allLivre);
        }
      public IActionResult CreateEditLivre(int ? id)

        {
           
            if (id != null)
            {
                var LivreInDb = _db.Livres.SingleOrDefault(livre => livre.Id == id);
                return View(LivreInDb);
            }
            return View();
        }
        
        public IActionResult CreateEditLivreForm(Livre model)
        {
            if (model.Id == 0)
            {
                _db.Livres.Add(model);
            }
            else
            {
                _db.Livres.Update(model);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
        public IActionResult DeleteLivre(int id)
        {
            var livreInDb = _db.Livres.SingleOrDefault(livre => livre.Id == id);
            if(livreInDb == null)
            {
                return NotFound();
            }
            _db.Livres.Remove(livreInDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}

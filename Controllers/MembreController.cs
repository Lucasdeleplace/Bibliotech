using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;

namespace bibliotech.Controllers
{
    public class MembreController : Controller
    {
        private readonly BibliotechDb _db;

        public MembreController(BibliotechDb db)
        {
            _db = db;
        }
        public IActionResult Index() 
        {
            var allMembre = _db.Membre.ToList();
            return View(allMembre);
        }
        public IActionResult CreateEditMembre(int? id)
        {
            if(id != null)
            {
                var membreInDb = _db.Membre.SingleOrDefault(membre => membre.Id == id);
                return View(membreInDb);
            }

            return View();
        }
        public IActionResult CreateEditMembreForm(Membre model)
        {
            if(model.Id == 0)
            {
                _db.Membre.Add(model);
            }
            else
            {
                _db.Membre.Update(model);
            }
            

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult DeleteMembre(int id)
        {
            var membreInDb = _db.Membre.SingleOrDefault(membre => membre.Id == id);
            _db.Membre.Remove(membreInDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

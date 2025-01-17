using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;

namespace bibliotech.Controllers
{
    public class EmpruntsController : Controller
    {
        private readonly BibliotechDb _db;

        public EmpruntsController(BibliotechDb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var allEmprunt = _db.Emprunts.ToList();
            return View(allEmprunt);
        }

        public IActionResult CreateEditEmprunt(int? id)
        {
            if (id != null)
            {
                var empruntInDb = _db.Emprunts.SingleOrDefault(emprunt => emprunt.Id == id);
                return View(empruntInDb);
            }

            return View();
        }
        public IActionResult CreateEditEmpruntForm(Emprunt model)
        {
            if (model.Id == 0)
            {
                _db.Emprunts.Add(model);
            }
            else
            {
                _db.Emprunts.Update(model);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmprunt(int id)
        {
            var empruntInDb = _db.Emprunts.SingleOrDefault(emprunt => emprunt.Id == id);
            _db.Emprunts.Remove(empruntInDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

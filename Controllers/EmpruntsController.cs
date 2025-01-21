using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace bibliotech.Controllers
{
    public class EmpruntsController : Controller
    {
        private readonly BibliotechDb _db;

        public EmpruntsController(BibliotechDb db)
        {
            _db = db;
        }

        [HttpGet]
        [SwaggerOperation(
  Summary = "Afficher les emprunts",
  Description = "La description de mon Emprunts ",
  OperationId = "Get Emprunt")]
        [SwaggerResponse(200, "Emprunts trouvé avec success", typeof(Emprunt))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/emprunts")]
        public IActionResult Index()
        {
            var allEmprunt = _db.Emprunts.Include(e => e.Livre).ToList();
            return View(allEmprunt);
        }



        [HttpGet]
        [SwaggerOperation(
             Summary = "Afficher un Emprunt",
             Description = "La description de mon Emprunt",
             OperationId = "Get Emprunt by id")]
        [SwaggerResponse(200, "Emprunt trouvé avec succes", typeof(Emprunt))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/emprunts/{id}")]
        public IActionResult CreateEditEmprunt(int? id)
        {
            if (id != null)
            {
                var empruntInDb = _db.Emprunts.SingleOrDefault(emprunt => emprunt.Id == id);
                return View(empruntInDb);
            }

            return View();
        }
        [HttpPost]
        [SwaggerOperation(
     Summary = "Crée ou modifier un emprunt",
     Description = "La description de mon Emprunt",
     OperationId = "Post/Put")]
        [SwaggerResponse(200, "Emprunt trouvé avec succes", typeof(Emprunt))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/emprunts")]
        public IActionResult CreateEditEmpruntForm(Emprunt model)
        {
                if (model.Id == 0)
                {
                    var LivreInDb = _db.Livres.SingleOrDefault(Livre => Livre.Id == model.Id_Livre);
                    if (LivreInDb == null)
                    {
                        return NotFound();
                    }
                    else if (LivreInDb.Disponibilite == false)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _db.Emprunts.Add(model);
                        LivreInDb.Disponibilite = false;
                    }
                }
                else
                {
                    _db.Emprunts.Update(model);
                }
                _db.SaveChanges();
          
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/emprunts/{id}")]
        [SwaggerOperation(
    Summary = "Supprimer un emprunt",
    Description = "La description de mon Emprunt",
    OperationId = "DeleteEmprunt")]
        [SwaggerResponse(200, "Emprunt supprimé avec succès", typeof(Emprunt))]
        [SwaggerResponse(400, "Demande invalide")]
        public IActionResult DeleteEmprunt(int id)
        {
            var empruntInDb = _db.Emprunts.SingleOrDefault(emprunt => emprunt.Id == id);
            if (empruntInDb == null)
            {
                return NotFound();
            }
            _db.Emprunts.Remove(empruntInDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("/retourEmprunt/{id}")]
        [SwaggerOperation(
    Summary = "Rendre un livre emprunter",
    Description = "La description de mon Emprunt",
    OperationId = "RetourEmprunt")]
        [SwaggerResponse(200, "Retour avec succès", typeof(Emprunt))]
        [SwaggerResponse(400, "Demande invalide")]
        public IActionResult RetourLivre(int id)
        {

            var empruntInDb = _db.Emprunts.SingleOrDefault(emprunt => emprunt.Id == id);
            if (empruntInDb == null)
            {
                return NotFound();
            }

            var LivreInDb = _db.Livres.SingleOrDefault(livre => livre.Id == empruntInDb.Id_Livre);
            if (LivreInDb == null)
            {
                return NotFound();
            }

            LivreInDb.Disponibilite = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace bibliotech.Controllers
{
    public class MembreController : Controller
    {
        private readonly BibliotechDb _db;

        public MembreController(BibliotechDb db)
        {
            _db = db;
        }

        [HttpGet]
        [SwaggerOperation(
         Summary = "Afficher les membres ",
         Description = "La description des membres",
         OperationId = "Get Livre")]
        [SwaggerResponse(200, "Memres trouvé avec success", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/membre")]
        public IActionResult Index() 
        {
            var allMembre = _db.Membre.ToList();
            return View(allMembre);
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Afficher un Membre",
          Description = "La description de mon Membre",
          OperationId = "Get Membre by id")]
        [SwaggerResponse(200, "Membre trouvé avec succes", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/membre/{id}")]
        public IActionResult CreateEditMembre(int? id)
        {
            if(id != null)
            {
                var membreInDb = _db.Membre.SingleOrDefault(membre => membre.Id == id);
                return View(membreInDb);
            }

            return View();
        }
        [HttpPost]
        [SwaggerOperation(
         Summary = "Ajouter ou modifier un Membre",
         Description = "La description de mon membre",
         OperationId = "Post/Put")]
        [SwaggerResponse(200, "membrere crée avec succes", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/membre")]
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

        [HttpPost]
        [Route("/membre/{id}")]
        [SwaggerOperation(
          Summary = "Supprimer un membre",
          Description = "La description de mon membre",
          OperationId = "DeleteLivre")]
        [SwaggerResponse(200, "membre supprimé avec succès", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
        public IActionResult DeleteMembre(int id)
        {
            var membreInDb = _db.Membre.SingleOrDefault(membre => membre.Id == id);
            _db.Membre.Remove(membreInDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/membre/{id}/emprunt")]
        [SwaggerOperation(
          Summary = "Afficher l'historique d'emprunt d'un membre",
          Description = "La description de l'historique du membre",
          OperationId = "empruntMembre")]
        [SwaggerResponse(200, "Historique chargé avec succès", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
        public IActionResult HistoriqueMembre(int id)
        {
            var empruntMembreInDb = _db.Emprunts.Include(e => e.Membre).Where(emprunt => emprunt.Id_Membre == id).ToList();
            var membre = _db.Membre.SingleOrDefault(m => m.Id == id);

            ViewBag.Nom = membre?.Nom;
            ViewBag.Prenom = membre?.Prenom;

            return View(empruntMembreInDb);
        }


    }
}

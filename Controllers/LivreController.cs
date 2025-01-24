using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using bibliotech.Helpers;


namespace bibliotech.Controllers
    {
    public class LivreController : Controller

    {



    [ApiController]
    [Route("api/livres")]
    public class LivresController : ControllerBase
    {
        private readonly string _jsonFilePath;

        public LivresController(IWebHostEnvironment env)
        {
            // Définit le chemin du fichier JSON
            _jsonFilePath = Path.Combine(env.ContentRootPath, "Data", "livres.json");
        }

        [HttpGet]
        public IActionResult GetAllLivres()
        {
            try
            {
                // Charger les livres à partir du fichier JSON
                var livres = JsonFileHelper.LoadLivresFromFile(_jsonFilePath);
                return Ok(livres);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Une erreur est survenue.", Details = ex.Message });
            }
        }
    }


        
        private readonly BibliotechDb _db;

        public LivreController(BibliotechDb db)
        {
            _db = db;
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Afficher les livres disponible",
          Description = "La description des livres",
          OperationId = "Get Livre")]
        [SwaggerResponse(200, "Livres trouvé avec success", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/livre")]

        public IActionResult Index()
        {
            var allLivre = _db.Livres.ToList();
                return View(allLivre);
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Afficher un Livre",
          Description = "La description de mon Livre",
          OperationId = "Get Livre by id")]
        [SwaggerResponse(200, "Livre trouvé avec succes", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/livre/{id}")]
        public IActionResult CreateEditLivre(int ? id)
        {
           
            if (id != null)
            {
                var LivreInDb = _db.Livres.SingleOrDefault(livre => livre.Id == id);
                return View(LivreInDb);
            }
            return View();
        }


        [HttpPost]
        [SwaggerOperation(
          Summary = "Ajouter ou modifier un livre",
          Description = "La description de mon livre",
          OperationId = "Post/Put")]
        [SwaggerResponse(200, "Livre trouvé avec succes", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
        [Route("/livre")]

        public IActionResult CreateEditLivreForm(Livre model)
        {
         if (ModelState.IsValid)
        {
            // Si le model n'est pas valide , retourn la vue avec les erreurs
            return View(model); 
        }
            if (model.Id == 0 )
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

        [HttpPost]
        [Route("/livre/{id}")]
        [SwaggerOperation(
          Summary = "Supprimer un livre",
          Description = "La description de mon Livre",
          OperationId = "DeleteLivre")]
        [SwaggerResponse(200, "Livre supprimé avec succès", typeof(Livre))]
        [SwaggerResponse(400, "Demande invalide")]
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

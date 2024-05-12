using GestionEtudiant.Data;
using GestionEtudiant.Models;
using Microsoft.AspNetCore.Mvc;


namespace GestionEtudiant.Controllers
{
    public class EtudiantController : Controller
    {
        public EtudiantController(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;
        public IActionResult Index()
        {
            IEnumerable<Etudiant> ListEtudiant = _db.etudiants.ToList();
            return View(ListEtudiant);
        } 
        public IActionResult New()
        { 
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Etudiant etudiant)
        {
            _db.etudiants.Add(etudiant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var etudiant = _db.etudiants.Find(Id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Etudiant etudiant)
        {
            
            if (ModelState.IsValid)
            {
                _db.etudiants.Update(etudiant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(etudiant);
            }
        }

        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var etudiant = _db.etudiants.Find(Id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEtudiant(int? Id)
        {
            var etudiant = _db.etudiants.Find(Id);
            if (etudiant == null)
            {
                return NotFound();
            }
            _db.Remove(etudiant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}

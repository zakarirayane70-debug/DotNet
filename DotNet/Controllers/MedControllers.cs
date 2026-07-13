using appTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace appTest.Controllers
{
    public class MedControllers : Controller
    {
        private readonly appTestDB _context;
        public MedControllers(appTestDB context)
        {
            _context = context;
        }
        // GET: MedControllers
        public ActionResult Index()
        {
            var Medicament = _context.Medicament.ToList();
            return View(Medicament);
        }

        // GET: MedControllers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicament Medicament)
        {

            if (ModelState.IsValid)
            {
                _context.Medicament.Add(Medicament);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Medicament);
        }


        // GET: MedControllers/Edit/5
        public ActionResult Edit(int id)
        {
            var Medicament = _context.Medicament.SingleOrDefault(Medicament => Medicament.Id == id);
            if (Medicament == null)
            {
                return NotFound();
            }
            return View(Medicament);
        }

        // POST: MedControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medicament Medicament)
        {

            var exist = _context.Medicament.SingleOrDefault(Medicaments => Medicaments.Id == Medicaments.Id);
            if (exist == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                exist.Id = Medicament.Id;
                exist.Code = exist.Code;
                exist.Nom = Medicament.Nom;
                exist.CategorieId = exist.CategorieId;
                exist.Prix = Medicament.Prix;
                exist.Quantite = Medicament.Quantite;
                exist.DateExpiration = exist.DateExpiration;
                exist.FournisseurId = Medicament.FournisseurId;
                exist.Fournisseur = Medicament.Fournisseur;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(Medicament);
        }

        // GET: MedControllers/Delete/5
        public ActionResult Delete(int id)
        {
            var Medicament = _context.Medicament.SingleOrDefault(Medicament => Medicament.Id == Id);
            if (Medicament == null)
            {
                return NotFound();
            }
            _context.Fournisseurs.Remove(Medicament);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

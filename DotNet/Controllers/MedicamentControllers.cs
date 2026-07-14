using appTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering ;
using Microsoft.EntityFrameworkCore;
namespace appTest.Controllers
{
    public class MedicamentController : Controller
    {
        private readonly appTestDB _context;
        public MedicamentController(appTestDB context)
        {
            _context = context;
        }
        // GET: MedControllers
        public ActionResult Index()
        {
            var Medicaments = _context.Medicament.
                Include(m => m.Categorie).
                Include(m => m.Fournisseur)
                .ToList();
            return View(Medicaments);
        }

        // GET: MedControllers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedControllers/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(
     _context.Categories, "Id", "Nom");
            ViewBag.FournisseurId = new SelectList(_context.Fournisseurs, "Id", "Nom");
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
            ViewBag.CategorieId = new SelectList(
     _context.Categories, "Id", "Nom", Medicament.CategorieId);
            ViewBag.FournisseurId = new SelectList(_context.Fournisseurs, "Id", "Nom", Medicament.FournisseurId);
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
            ViewBag.CategorieId = new SelectList(_context.Categories, "Id", "Nom", Medicament.CategorieId);
            ViewBag.FournisseurId = new SelectList(_context.Fournisseurs, "Id", "Nom", Medicament.FournisseurId);

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
                exist.Code = Medicament.Code;
                exist.Nom = Medicament.Nom;
                exist.CategorieId = Medicament.CategorieId;
                exist.Prix = Medicament.Prix;
                exist.Quantite = Medicament.Quantite;
                exist.DateExpiration = Medicament.DateExpiration;
                exist.FournisseurId = Medicament.FournisseurId;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            ViewBag.CategorieId = new SelectList(_context.Categories, "Id", "Nom", Medicament.CategorieId);
            ViewBag.FournisseurId = new SelectList(_context.Fournisseurs, "Id", "Nom", Medicament.FournisseurId);
            return View(Medicament);
        }

        // GET: MedControllers/Delete/5
        public ActionResult Delete(int id)
        {
            var MedicamentDB = _context.Medicament.SingleOrDefault(Medicament => Medicament.Id == id);
            if (MedicamentDB == null)
            {
                return NotFound();
            }
            _context.Medicament.Remove(MedicamentDB);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Indexo(string search)
        {
            var Medicament = _context.Medicament.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                Medicament = Medicament.Where(p =>
                    p.Nom.Contains(search) ||
                    p.Code.ToString().Contains(search));
            }

            return View(Medicament.ToList());
        }
    }
}

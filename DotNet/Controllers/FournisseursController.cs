using appTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace appTest.Controllers
{
    public class FournisseursController : Controller
    {
        private readonly appTestDB _context;
        public FournisseursController(appTestDB context)
        {
            _context = context;
        }
        // GET: FournisseursController
        public IActionResult Index()
        {
            var fournisseurs = _context.fournisseurs.ToList();
            return View(fournisseurs);
        }

        // GET: FournisseursController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: CategorieController/Create
        public ActionResult Create()
        {
            //tolist;
            return View();
        }
        // POST: FournisseursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fournisseurs fournisseur)
        {

            if (ModelState.IsValid)
            {
                _context.fournisseurs.Add(fournisseur);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(fournisseur);

        }

        // GET: FournisseursController/Edit/5
        public ActionResult Edit(int id)
        {
            var FournisseursDB = _context.fournisseurs.SingleOrDefault(Fournisseurs => Fournisseurs.Id == id);
            if (FournisseursDB == null)
            {
                return NotFound();
            }
            return View(FournisseursDB);
        }

        // POST: FournisseursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fournisseurs fournisseurs)
        {

            var exist = _context.fournisseurs.SingleOrDefault(Fournisseurs => Fournisseurs.Id == fournisseurs.Id);
            if (exist == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                exist.Id = fournisseurs.Id;
                exist.Nom = fournisseurs.Nom;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(fournisseurs);
        }


        // GET: FournisseursController/Delete/5
        public ActionResult Delete(int id)
        {
            var produitDB = _context.fournisseurs.SingleOrDefault(Produit => Produit.Id == id);
            if (produitDB == null)
            {
                return NotFound();
            }
            _context.fournisseurs.Remove(produitDB);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



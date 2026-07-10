using appTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace appTest.Controllers
{
    public class CategorieController : Controller
       
    {
        private readonly CategorieDB _context;
        public CategorieController(CategorieDB context)
        {
            _context = context;
        }
        // GET: CategorieController
        public IActionResult Index()
        {
            var categories= _context.Categories.ToList();
            return View(categories);
        }

        // GET: CategorieController/Details/5
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

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //dyl sécurité pour éviter les attaques CSRF 
        public ActionResult Create(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add (categorie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }
        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
    {
            var exist = _context.Categories.SingleOrDefault(Categorie => Categorie.Id == id);
            if (exist == null)
            {
                return NotFound();
            }
            return View(exist);
        }
        //todo    
        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie categorie)
        {
            var exist = _context.Categories.SingleOrDefault(Categorie => Categorie.Id == categorie.Id);
            if (ModelState.IsValid)
            {

                exist.Id = categorie.Id;
                exist.Nom= categorie.Nom;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // POST: CategorieController/Delete
        public ActionResult Delete(int id)
        {
            var CategorieDB = _context.Categories.SingleOrDefault(Categorie => Categorie.Id == id);
            if (CategorieDB == null) {
                return NotFound();
            }
            _context.Categories.Remove(CategorieDB);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            }
        }
}
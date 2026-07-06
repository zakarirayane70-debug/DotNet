using appTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace appTest.Controllers
{
    public class ProduitController : Controller
    {
        private readonly appTestDB _context;
        public ProduitController(appTestDB context)
        {
            _context = context;
        }

        // GET: ProduitController
        public IActionResult Index()
        {
            var produits = _context.Produits.ToList();
            return View(produits);
        }

        //GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            //tolist;
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //dyl sécurité pour éviter les attaques CSRF 
        public ActionResult Create(Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Produits.Add(produit);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        /* // GET: ProduitController/Edit/5
         public ActionResult Edit(int id)
         {
             return View();
         }

         // POST: ProduitController/Edit/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit(int id, IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }

         // GET: ProduitController/Delete/5
         public ActionResult Delete(int id)
         {
             return View();
         }

         // POST: ProduitController/Delete/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Delete(int id, IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }*/
    }
}

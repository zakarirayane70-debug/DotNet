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
        public ActionResult Delete(int id)
        {
            var produitDB = _context.Produits.SingleOrDefault(Produit => Produit.Id == id);
            if (produitDB == null)
            {
                return NotFound();
            }
            _context.Produits.Remove(produitDB);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //get : ProduitController/Edit
        public ActionResult Edit(int id)
        {
            var produitDB = _context.Produits.SingleOrDefault(Produit => Produit.Id == id);
            if (produitDB == null)
            {
                return NotFound();
            }
            return View(produitDB);
        }
            //post : ProduitController/Edit/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produit produit)
        {
            
            var exist = _context.Produits.SingleOrDefault(Produit => Produit.Id == produit.Id);
            if (exist == null)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                exist.Id = produit.Id;
                exist.Nom = produit.Nom;
                exist.Prix = produit.Prix;
                exist.Quantite = produit.Quantite;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

    }

    }

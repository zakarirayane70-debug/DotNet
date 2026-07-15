using appTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace appTest.Controllers
{
    public class StockController : Controller
    {
        private readonly appTestDB _context;
        public StockController(appTestDB context)
        {
            _context = context;
        }
        // GET: StockController
        public ActionResult Index()
        {
            var stocks = _context.Stocks.ToList();
            return View(stocks);
        }

        // GET: StockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stock stock)
        {
            
                if (ModelState.IsValid)
                {
                    _context.Stocks.Add(stock);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(stock);
            
        }

        // GET: StockController/Edit/5
        public ActionResult Edit(int id)
        {
            var exist = _context.Stocks.SingleOrDefault(Stock => Stock.Id == id);
            if (exist == null)
            {
                return NotFound();
            }


            return View(exist);
        }

        // POST: StockController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Stock stock)
        {
            var exist = _context.Stocks.SingleOrDefault(s => s.Id == stock.Id);
            if (exist==null){
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                exist.Id = stock.Id;
                exist.MedicamentId = stock.MedicamentId;
                exist.Type = stock.Type;
                exist.Quantite = stock.Quantite;
                exist.DateStock = stock.DateStock;
                exist.Motif = stock.Motif;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicamentId = new SelectList(_context.Medicament, "Nom", stock.MedicamentId);
            return View(stock);
        }
        

        // GET: StockController/Delete/5
        public ActionResult Delete(int id)
        {
            var exist = _context.Stocks.SingleOrDefault(Stock => Stock.Id == id);
            if (exist == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(exist);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}

using CinemaManager.Models.Cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaManager.Controllers
{
    public class ProducersController : Controller
    {
        // GET: ProducersController
        CinemaDbContext _context;
        public ProducersController(CinemaDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Producers);
        }

        // GET: ProducersController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Producers.Find(id));
        }

        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer p)
        {
            try
            {
                _context.Producers.Add(p);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProducersController/Edit/5
        public ActionResult Edit(int id)
        {


            return View(_context.Producers.Find(id));

        }

        // POST: ProducersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producer p)
        {
            try
            {
                _context.Producers.Update(p);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
               
            }
            catch
            {
                return View();
            }
        }

        // GET: ProducersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Producers.Find(id));
        }

        // POST: ProducersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Producer p)
        {
            try
            {
                _context.Producers.Remove(p);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ProdsAndTheirMovies()
        {
            var cinemaDbContext = _context.Producers.Include(p => p.Movies);

            return View(cinemaDbContext);//list
        }
        public ActionResult ProdsAndTheirMovies_UsingModel()
        {
            var producer = from p in _context.Producers
                         join m in _context.Movies
                         on p.Id equals m.ProducerId
                         select new ProdMovie
                         {
                             mGenre = m.Genre,
                             mTitle = m.Titre,
                             pName = p.Name,
                             pNat = p.Nationality,
                         };

            return View(producer);

        }
        public ActionResult MyMovies(int id)
        {
            var producer = from p in _context.Producers
                           join m in _context.Movies
                           on p.Id equals m.ProducerId
                           where p.Id==id
                           select new ProdMovie
                           {
                               mGenre = m.Genre,
                               mTitle = m.Titre,
                               pName = p.Name,
                               pNat = p.Nationality,
                           };

            return View(producer);

        }
    }
    
}

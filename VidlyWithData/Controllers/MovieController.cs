using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyWithData.Models;
using System.Data.Entity;
using VidlyWithData.ViewModel;
using System.Data.Entity.Validation;

namespace VidlyWithData.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var movie = _context.Movies.Include(g=> g.Genre).ToList();


            return View(movie);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == Id);

            return View(movie);
            
        }

        public ActionResult New()
        {

            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genre
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            
            if (viewModel.Movie.Id == 0)
            {
                viewModel.Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(viewModel.Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == viewModel.Movie.Id);
                movieInDb.Name = viewModel.Movie.Name;
                movieInDb.ReleaseDate = viewModel.Movie.ReleaseDate;
                movieInDb.GenreId = viewModel.Movie.GenreId;
                movieInDb.NumberInStock = viewModel.Movie.NumberInStock;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
           

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int Id)
        {

            var movie = _context.Movies.Single(m => m.Id == Id);
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };


            return View("MovieForm",viewModel);
        }
    }
}
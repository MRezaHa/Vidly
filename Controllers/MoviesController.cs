using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies
        [Route("Movies")]
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(mov => mov.Genre).ToList();

            return View(movies);
        }

        [Route("Movies/EditMovie/{id}")]
        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.Include(mov => mov.Genre).SingleOrDefault(movie1 => movie1.Id.Equals(id));
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [Route("Movies/NewMovie")]
        public ActionResult NewMovie()
        {
            var movie = new Movie()
            {
                Id = 0
            };
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.AddedDate = movie.AddedDate;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



    }
}
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
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        [Route("Movies/EditMovie/{id}")]
        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.Include(mov => mov.Genre).SingleOrDefault(movie1 => movie1.Id.Equals(id));
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [Route("Movies/NewMovie")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult NewMovie()
        {
            var movie = new Movie()
            {
                Id = 0
            };
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.Genre = _context.Genres.SingleOrDefault(m => m.Id == movie.GenreId); ////////////////////
                _context.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Genre = _context.Genres.SingleOrDefault(m => m.Id == movieInDb.GenreId); //////////////////// pas fayede tarif karadan genre chie ? // hatman bayad dorost beshe choon moshkel performance ijad misavad, choon bayad yek darkhast be db bezanad
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.AddedDate = movie.AddedDate;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



    }
}
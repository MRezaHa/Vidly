using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

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

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(mov => mov.Genre).SingleOrDefault(movie1 => movie1.Id.Equals(id));
            return View(movie);
        }
    }
}
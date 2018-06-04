using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("Movies")]
        public ActionResult Index()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Shrek"
            };

            var customers = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Reza"},

                new Customer() {Id = 2, Name = "Ali"}
            };

            var viewModel = new MoviesViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}
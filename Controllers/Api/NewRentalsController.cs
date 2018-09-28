using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids have been given. ");
            }

            var customer = _context.Customers.SingleOrDefault(m => m.Id.Equals(newRental.CustomerId));

            if (customer == null)
            {
                return BadRequest("CustomerId is not valid. ");
            }

            var rentedMovie =  _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (rentedMovie.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more movies are invalid. ");
            }

            foreach (var movie in rentedMovie)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available. ");
                }

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };


                _context.Rentals.Add(rental);
            }

           _context.SaveChanges();
           return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetNewRentals()
        {
            var test = new NewRentalDto()
            {
                CustomerId = 1,
                MovieIds = new List<int>()
                {
                    1,2,3
                }
            };

            return Ok(test);
        }
    }
}

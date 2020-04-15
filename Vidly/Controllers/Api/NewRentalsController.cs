using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Route("api/rental/new")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            IEnumerable<Movie> movies = 
                _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id) && m.NumberAvailable > 0);

            if (movies.Count() == newRental.MovieIds.Count)
            {
                foreach (var movie in movies)
                {
                    _context.Rentals.Add(new Rental
                    {
                        CustomerId = newRental.CustomerId,
                        MovieId = movie.Id,
                        RentalDate = DateTime.UtcNow
                    }); 
                    movie.NumberAvailable--;
                }
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest("One or more movies are unavailable");
        }
    }
}

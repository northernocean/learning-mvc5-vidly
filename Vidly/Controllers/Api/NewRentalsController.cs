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
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            foreach(int id in newRental.MovieIds)
            {
                _context.Rentals.Add(new Rental { 
                        CustomerId = newRental.CustomerId, 
                        MovieId = id, 
                        RentalDate = DateTime.UtcNow.ToLocalTime().Date
                });
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}

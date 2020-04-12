using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{

    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;
        
        public MoviesController()
        {

            _context = new ApplicationDbContext();

        }

        //[HttpGet]
        //public  IHttpActionResult GetMovies()
        //{
        
        //    var movies = 
        //        _context.Movies
        //        .Include(m => m.GenreDetails).ToList()
        //        .Select(Mapper.Map<MovieDto>);
        //    return Ok(movies);
        
        //}

        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return Ok(moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>));
        }


        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
        
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<MovieDto>(movie));
        
        }

        [HttpPost]
        public IHttpActionResult CreateMovie (MovieDto movie)
        {
        
            if (!ModelState.IsValid)
                return BadRequest();

            var newMovie = Mapper.Map<Movie>(movie);
            
            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            movie.Id = newMovie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie (int id, MovieDto movie)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDB is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movie, movieInDB);
            
            _context.SaveChanges();
            return Ok(movie);
        
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDB is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();
            return Ok();

        }

    }

}

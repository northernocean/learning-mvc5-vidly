using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{

		ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}
		
		[Route("movies/random")]
		public ActionResult Random()
		{
			var movies = _context.Movies.ToList();
			var customers = _context.Customers.ToList();
			var viewModel = new RandomMovieViewModel
			{
				Movie = movies[new Random().Next(0, movies.Count())],
				Customers = customers
			};
			return View(viewModel);
		}

		public ActionResult Index()
		{
			//GET: Movies
			var movies = _context.Movies.Include(m => m.GenreDetails).ToList();

			if (User.IsInRole(RoleName.CanManageMovies))
				return View("Index", movies);
			else			
				return View("IndexReadOnly", movies);

		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult New()
		{

			var viewModel = new MovieFormViewModel
			{
				Movie = new Movie(),
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}
		
		public ActionResult Edit(int id)
		{

			var viewModel = new MovieFormViewModel
			{
				Movie = _context.Movies.Single(m => m.Id == id),
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{

			if (!ModelState.IsValid)
			{
				var ViewModel = new MovieFormViewModel
				{
					Movie = movie,
					Genres = _context.Genres.ToList()
				};
				return View("MovieForm", ViewModel);
			}

			if (movie.Id == 0)
			{
				movie.Id = _context.Movies.Max(m => m.Id) + 1;
				movie.DateAdded = DateTime.UtcNow;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
				movieInDB.GenreId = movie.GenreId;
				movieInDB.Name = movie.Name;
				movieInDB.NumberInStock = movie.NumberInStock;
				movieInDB.ReleaseDate = movie.ReleaseDate;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");

		}


		[Route("Movies/{Id:regex(\\d)}")]
		public ActionResult Details(int Id)
		{
			var movie = _context.Movies.Include("GenreDetails").ToList()[Id];
			return View(movie);
		}

		// GET: Movies/Random
		public ActionResult Random1()
		{
			// Preferred by Mosh! 
			// Note - MVC will assign movie to the ViewResult.ViewData.Model property
			//        when we pass an object as a parameter to the view method.
			Movie movie = new Movie { Name = "Shrek!" };
			return View(movie);
		}
		public ActionResult Random2()
		{
			// Requires awkward casting in the view
			Movie movie = new Movie { Name = "Shrek!" };
			ViewData["Movie"] = movie;
			return View();
		}
		public ActionResult Random3()
		{
			//with ViewBag - but no compile time type safety
			Movie movie = new Movie { Name = "Shrek!" };
			ViewBag.Movie = movie;
			return View();
		}
		

		[Route("movies/released/{year}/{month:regex(\\d{1,2}):range(1,12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		[Route("movies/random")]
		public ActionResult Random()
		{
			Movie movie = new Movie { Name = "Shrek!" };
			var customers = new List<Customer> {
				new Customer{ Name = "Customer 1" },
				new Customer{ Name = "Customer 2"},
				new Customer{ Name = "Customer 3"},
				new Customer{ Name = "Customer 4"},
				new Customer{ Name = "Customer 5"}
			};
			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};
			return View(viewModel);
		}

		public ActionResult Index()
		{
			//GET: Movies
			var viewModel = new MoviesViewModel
			{
				Movies = new List<Movie>
				{
					new Movie { Id = 1, Name = "Shrek!" },
					new Movie { Id = 2, Name = "Footloose" }
				}
			};

			return View(viewModel);

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
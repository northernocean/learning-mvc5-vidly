using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        // Ensure the context is disposed when the CustomersController class is disposed
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            CustomersViewModel viewModel = new CustomersViewModel
            {
                Customers = _context.Customers.ToList()
            };
            
            return View(viewModel);
        }

        [Route("Customers/{Id:regex(\\d)}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.CustomerId == Id);
            if(customer is null)
                return HttpNotFound();
            else
                return View(customer);
        }

    }
}
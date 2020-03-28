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
        
        private IEnumerable<Customer> _customers;

        public CustomersController()
        {
            _customers = new List<Customer>
            {
                new Customer{CustomerId = 1, Name = "Customer 1"},
                new Customer{CustomerId = 2, Name = "Customer 2"}
            };
        }

        // GET: Customer
        public ActionResult Index()
        {
            CustomersViewModel viewModel = new CustomersViewModel
            {
                Customers = _customers
            };
            
            return View(viewModel);
        }

        [Route("Customers/{Id:regex(\\d)}")]
        public ActionResult Details(int Id)
        {
            var customer = _customers.FirstOrDefault(p => p.CustomerId == Id);
            if(customer is null)
                return HttpNotFound();
            else
                return View(customer);
        }
    }
}
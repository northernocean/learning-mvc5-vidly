using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        
        protected override void Dispose(bool disposing)
        {
            // Ensure the context is disposed when the CustomersController class is disposed
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            
            return View(customers);
        }

        [Route("Customers/{Id:regex(\\d)}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(p => p.Id == Id);
            if(customer is null)
                return HttpNotFound();
            else
                return View(customer);
        }
        
        public ActionResult New()
        {

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                customer.Id = _context.Customers.Max(c => c.Id) + 1;
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");

        
        }

    }

}
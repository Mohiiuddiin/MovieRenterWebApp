using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRenterWebApp.Models;
using MovieRenterWebApp.ViewModels;

namespace MovieRenterWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbContext;

        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var Customers = dbContext.Customers.Include(c => c.MembershipType).ToList();
            return View(Customers);
        }

        [HttpGet]
        public ActionResult Save()
        {
            var memberShipType = dbContext.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = memberShipType
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = dbContext.MembershipTypes.ToList()
                };
                return View("Save", viewModel);
            }

            if (customer.Id == 0)
            {
                dbContext.Customers.Add(customer);
            }
            else
            {
                var updateCustomer = dbContext.Customers.SingleOrDefault(c => c.Id == customer.Id);
                updateCustomer.Name = customer.Name;
                updateCustomer.BirthDate = customer.BirthDate;
                updateCustomer.MembershipTypeId = customer.MembershipTypeId;
                updateCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }

            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");






        }

        public ActionResult Edit(int Id)
        {
            var viewModel = new NewCustomerViewModel()
            {
                Customer = dbContext.Customers.SingleOrDefault(c => c.Id == Id),
                MembershipTypes = dbContext.MembershipTypes.ToList()
            };
            return View("Save", viewModel);
        }

        public ActionResult Details(int Id)
        {

            return View(dbContext.Customers.Include(c => c.MembershipType).FirstOrDefault(x => x.Id == Id));
        }

        //public List<Customer> GetCustomers()
        //{
        //    List<Customer> customers = new List<Customer>()
        //    {
        //        new Customer{Id = 1,Name = "Golum Mohammed Mohiuddin"},
        //        new Customer{Id = 2,Name = "Mohammed Sharfuddin Saif"},
        //        new Customer{Id = 3,Name = "Mohammed Tawhid Hossain"},
        //    };

        //    return customers;
        //}
    }
}
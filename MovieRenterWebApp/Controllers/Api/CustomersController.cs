
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MovieRenterWebApp.Models;

namespace MovieRenterWebApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext dbContext;
        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }


        public IEnumerable<Customer> GetCustomers()
        {
            var customers = dbContext.Customers.ToList();

            return customers;
        }
       
        public Customer GetCustomer(int Id)
        {
            var customer = dbContext.Customers.SingleOrDefault(x => x.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int Id,Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var UpdateCustomer = dbContext.Customers.SingleOrDefault(x => x.Id == Id);

                if(UpdateCustomer != null)
                {
                    UpdateCustomer.Name = customer.Name;
                    UpdateCustomer.BirthDate = customer.BirthDate;
                    UpdateCustomer.MembershipTypeId = customer.MembershipTypeId;
                    UpdateCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

                    dbContext.SaveChanges();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }

        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var deleteCustomer = dbContext.Customers.SingleOrDefault(x => x.Id == Id);

            if(deleteCustomer != null){
                dbContext.Customers.Remove(deleteCustomer);
                dbContext.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            }
        }
    }
}

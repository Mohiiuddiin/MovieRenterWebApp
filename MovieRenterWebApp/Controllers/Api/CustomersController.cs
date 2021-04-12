using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MovieRenterWebApp.DTOs;
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


        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = dbContext.Customers.ToList().Select(AutoMapper.Mapper.Map<Customer,CustomerDto>);

            return customers;
        }

        public CustomerDto GetCustomer(int Id)
        {
            var customer = dbContext.Customers.SingleOrDefault(x => x.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return AutoMapper.Mapper.Map<Customer,CustomerDto>(customer);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customer = AutoMapper.Mapper.Map<CustomerDto,Customer>(customerDto);
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();

                customerDto.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            }
            else
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }
            
            
        }

        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var UpdateCustomer = dbContext.Customers.SingleOrDefault(x => x.Id == Id);

                if (UpdateCustomer != null)
                {

                    AutoMapper.Mapper.Map(customerDto,UpdateCustomer);

                    //UpdateCustomer.Name = customerDto.Name;
                    //UpdateCustomer.BirthDate = customerDto.BirthDate;
                    //UpdateCustomer.MembershipTypeId = customerDto.MembershipTypeId;
                    //UpdateCustomer.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;

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

            if (deleteCustomer != null)
            {
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

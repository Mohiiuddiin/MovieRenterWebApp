using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MovieRenterWebApp.Models
{
    public class Is18yearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
            {
                return ValidationResult.Success;
            }
            else if(customer.BirthDate == null ){
                return new ValidationResult("Birth Date is required");                
            }else
            {
                var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
                if (age >= 18)
                {
                   return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Age should be minimum 18y old.");
                }
            }
        }
    }
}
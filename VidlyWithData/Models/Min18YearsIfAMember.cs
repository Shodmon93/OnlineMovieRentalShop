using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace VidlyWithData.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
    
      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unkown 
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
        
                return ValidationResult.Success;
            

            if (customer.BirthDate == null)
            
                return new ValidationResult("Birth Date is Required.");


            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success
                    : new ValidationResult("Customer should be at least 18 years old to go on Membership ");



        }
    }
}
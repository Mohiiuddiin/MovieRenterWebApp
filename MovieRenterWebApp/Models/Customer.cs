using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRenterWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:25)]
        public string Name { get; set; }
        [Display(Name="Date of Birth")]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
       
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        
        [Is18yearsOld]
        public int MembershipTypeId { get; set; }

    }
}
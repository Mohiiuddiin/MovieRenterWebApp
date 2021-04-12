using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRenterWebApp.Models;

namespace MovieRenterWebApp.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        //[Is18yearsOld]
        public int MembershipTypeId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; } // a Navigation Property
        
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        [Column(TypeName="Date")]
        [Display(Name="Date of Birth")]
        public DateTime? Birthdate { get; set; }
        
        public override string ToString()
        {
            return "" + CustomerId + Name;
        }
    }
}
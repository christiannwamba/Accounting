using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(100)]
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Address should be less than 200 and more than 10 characters")]
        public string Address { get; set; }
        public int Phone { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage="Invalid Email Address")]
        public string Email { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual ICollection<Order> Order { get; set; }

    }
}

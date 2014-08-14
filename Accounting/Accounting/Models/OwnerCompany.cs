using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Accounting.Models
{
    public class OwnerCompany
    {
        [Key]
        public Guid OwnerID { get; set; }
        [Required]
        public string Owner { get; set; }
        [DataType(DataType.MultilineText)]
        public string About { get; set; }
        [DataType(DataType.MultilineText)]
        public string Cotact { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
       
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
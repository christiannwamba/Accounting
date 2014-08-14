using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        public string SupplierName { get; set; }

        public Guid? OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public virtual OwnerCompany OwnerCompany { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
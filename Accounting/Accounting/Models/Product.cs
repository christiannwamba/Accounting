using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int UnitInStock { get; set; }

        public int UnitInOrder { get; set; }
        public int ReorderLevel { get; set; }
        public string ProductDescription { get; set; }
        public string Remarks { get; set; }

        public int CategoryID { get; set; }
        [Required]
        public virtual Category Category { get; set; }

        public int SupplierID { get; set; }
        [Required]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
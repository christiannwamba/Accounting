using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        [Column(TypeName="money")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Discount { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public int ProductID { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}
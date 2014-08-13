using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int Ordered { get; set; }

        public int CustomerID { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }

        public int EmployeeID { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
    }
}
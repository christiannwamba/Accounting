using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting.Models
{
    public class Order
    {
        public Order() {
            OrderDate = DateTime.Now;
        }
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int Ordered { get; set; }

        [Required]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public string EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

       
    }
}
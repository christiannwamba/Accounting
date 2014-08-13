namespace DefaultTemplate12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int CustomerID { get; set; }

        [StringLength(50)]
        public string ContactName { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int? StateID { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public DateTime? DateAdded { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Phone { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

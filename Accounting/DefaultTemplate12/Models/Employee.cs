namespace DefaultTemplate12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
            Orders1 = new HashSet<Order>();
        }

        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HireDate { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public int? StateID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Phone { get; set; }

        [StringLength(500)]
        public string PhotoPath { get; set; }

        public string Notes { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Order> Orders1 { get; set; }
    }
}

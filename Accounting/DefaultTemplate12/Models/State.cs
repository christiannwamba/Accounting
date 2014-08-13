namespace DefaultTemplate12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("State")]
    public partial class State
    {
        public State()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public int StateID { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
	
namespace Accounting.Models
{
    public class AccountingContext : DbContext
    {
        public AccountingContext() : base("name=DefaultConnection") { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<Accounting.Models.OwnerCompany> OwnerCompanies { get; set; }
    }
}
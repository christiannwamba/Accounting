using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DefaultTemplate12.Models;

namespace DefaultTemplate12.ViewModels
{
    public class Sales
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
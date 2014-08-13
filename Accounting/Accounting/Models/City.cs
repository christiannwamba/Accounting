using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Accounting.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required]
        public string CityName { get; set; }

        //Nav. Props
        [Required]
        public int SatteID { get; set; }
        [Required]
        public virtual State State { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        [Required]
        public string CountryName { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
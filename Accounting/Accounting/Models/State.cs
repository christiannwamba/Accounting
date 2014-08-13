using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        [Required]
        public string StateName { get; set; }

        //Nav Prop
        [Required]
        public int CountryID { get; set; }
        [Required]
        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
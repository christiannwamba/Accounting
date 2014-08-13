using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage="Address should be less than 200 and more than 10 characters")]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage="Invalid Email Address")]
        public string Email { get; set; }
        
        public int Phone { get; set; }

        [StringLength(300)]
        public string PhotoPath { get; set; }


        //Navigation Properties
        public int CityID { get; set; }
        [Required]
        public virtual City City { get; set; }
        public virtual ICollection<Order> Order { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + Lastname;
            }
        }
    }
}
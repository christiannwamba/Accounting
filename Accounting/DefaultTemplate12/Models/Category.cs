namespace DefaultTemplate12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }

        public byte[] CategoryDescription { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

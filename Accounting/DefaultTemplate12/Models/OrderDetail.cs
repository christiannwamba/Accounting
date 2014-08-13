namespace DefaultTemplate12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        public int OrderDetailsID { get; set; }

        public int? ProductID { get; set; }

        public int? OrderID { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? Quantity { get; set; }

        public int? Discount { get; set; }

        public string Remarks { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}

namespace DefaultTemplate12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartItem
    {
        [Key]
        public int CartItemsID { get; set; }

        public int? CartID { get; set; }

        public int? ProductID { get; set; }

        public short? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public float? Discount { get; set; }

        public float? Total { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}

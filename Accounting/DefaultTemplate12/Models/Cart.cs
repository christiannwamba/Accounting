namespace DefaultTemplate12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartID { get; set; }

        public int? CustomerID { get; set; }

        public DateTime? DateCreated { get; set; }

        public short? CheckedOut { get; set; }

        public int? OrderID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Order Order { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}

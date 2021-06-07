using System;
using System.Collections.Generic;

#nullable disable

namespace E_CommerceClient.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ProductQuantity { get; set; }
        public double? TotalAmount { get; set; }

        public virtual ProductDetail Product { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace E_CommerceClient.Models
{
    public partial class ProductDetail
    {
        public ProductDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double? Price { get; set; }
        public int? ProductQuantity { get; set; }
        public string ImageUrl { get; set; }

       // public HttpStyleUriParser ImageUrl { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

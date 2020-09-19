using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Entities
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}

using ShopAction.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

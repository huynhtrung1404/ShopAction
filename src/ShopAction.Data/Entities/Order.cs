using ShopAction.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Entities
{
    public class Order:BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public string ShipPhoneNumber { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public AppUser AppUser { get; set; }
    }
}

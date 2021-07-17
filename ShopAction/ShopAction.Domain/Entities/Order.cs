using ShopAction.CrossCutting.Enumeration;
using ShopAction.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public string ShipPhoneNumber { get; set; }
        public OrderStatus Status { get; set; }
        public Employee Employee { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Customer> Customers { get; set; }
        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}

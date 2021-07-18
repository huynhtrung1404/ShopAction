using System;
using System.Collections.Generic;
using ShopAction.Domain.Entities.Base;

namespace ShopAction.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime HireDay { get; set; }
        public string Address { get; set; }
        public Guid ManagerId { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}

using System;
using ShopAction.Domain.Entities.Base;

namespace ShopAction.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string ContactName { get; set; }
        public string Emal { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Region { get; set; }
        public Order Order { get; set; }
        public Customer()
        {
            Id = Guid.NewGuid();
        }
    }
}

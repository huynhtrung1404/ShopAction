using System;
using System.Collections.Generic;
using ShopAction.Domain.Entities.Base;

namespace ShopAction.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Homepage { get; set; }
        public List<Product> Products { get; set; }
        public Supplier()
        {
            Id = Guid.NewGuid();
        }
    }
}

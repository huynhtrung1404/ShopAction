using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Entities
{
    public class Cart:BaseEntity
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }

        public DateTime DateCreated { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

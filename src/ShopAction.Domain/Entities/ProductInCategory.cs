using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities
{
    public class ProductInCategory
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}

using ShopAction.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Guid SupplierId { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        public string SeoAlias { get; set; }
        public bool Discontinued { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<Category> Categories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}

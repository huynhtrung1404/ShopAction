using System;
namespace ShopAction.Domain.Entities
{
    public class CategoryProduct
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

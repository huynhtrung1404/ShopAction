using System;
namespace ShopAction.Application.Dtos
{
    public class ProductDto
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
    }
}

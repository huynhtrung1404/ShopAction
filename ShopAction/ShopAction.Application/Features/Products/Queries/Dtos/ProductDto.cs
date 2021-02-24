using System;

namespace ShopAction.Application.Features.Products.Queries.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DateTime { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
    }
}
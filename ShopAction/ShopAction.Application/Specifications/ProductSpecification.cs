using System;
using System.Linq;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(Guid categoryId) : base(x => x.Categories.Any(x => x.Id == categoryId))
        {

        }
    }
}

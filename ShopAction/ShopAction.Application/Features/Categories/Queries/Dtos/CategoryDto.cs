using System;
using System.Collections.Generic;
using System.Text;
using ShopAction.Application.Common.Mappings;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Features.Categories.Queries.Dtos
{
    public class CategoryDto : IMapFrom<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsShowOnHome { get; set; }
        public string Language { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Application.Features.Categories.Queries.Dtos
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsShowOnHome { get; set; }
        public string Language { get; set; }
        
    }
}

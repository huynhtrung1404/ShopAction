using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ViewModels.Catalog.Categories
{
    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        public bool IsShowOnHome { get; set; }
        public string Name { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public Guid LanguageId { get; set; }
    }
}

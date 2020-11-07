using ShopAction.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Entities
{
    public class Category:BaseEntity
    {
        public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
        public Category()
        {
            Id = new Guid();
        }
    }
}

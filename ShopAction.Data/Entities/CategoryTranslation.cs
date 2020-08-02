using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Entities
{
    public class CategoryTranslation:BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string LanguageId { get; set; }
        public string SeoAlias { get; set; }
        public Category Category { get; set; }
        public Language Language { get; set; }
    }
}

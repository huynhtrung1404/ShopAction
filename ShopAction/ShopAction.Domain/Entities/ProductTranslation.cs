using ShopAction.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities
{
    public class ProductTranslation : BaseEntity
    {
        public Guid ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public Guid LanguageId { set; get; }
        public Product Product { get; set; }
        public Language Language { get; set; }
        public ProductTranslation()
        {
            Id = Guid.NewGuid();
        }
    }
}

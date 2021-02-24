using ShopAction.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
        public Language()
        {
            Id = Guid.NewGuid();
        }
    }
}

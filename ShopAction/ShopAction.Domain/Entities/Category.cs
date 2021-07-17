using ShopAction.CrossCutting.Enumeration;
using ShopAction.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace ShopAction.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Id = Guid.NewGuid();
        }
    }
}

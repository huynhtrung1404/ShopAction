using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Path { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }
        public int FileSize { get; set; }
        public Product Product { get; set; }
    }
}

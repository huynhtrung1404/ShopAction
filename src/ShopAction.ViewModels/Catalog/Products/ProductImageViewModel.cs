using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ViewModels.Catalog.Products
{
    public class ProductImageViewModel
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public bool IsDefault { get; set; }
        public long FileSize { get; set; }
    }
}

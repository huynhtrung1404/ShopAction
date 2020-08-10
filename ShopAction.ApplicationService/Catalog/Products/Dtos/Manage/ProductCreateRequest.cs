using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ApplicationService.Catalog.Products.Dtos.Manage
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

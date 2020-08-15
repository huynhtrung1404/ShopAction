using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ViewModels.Catalog.Products.Manage
{
    public class ProductUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public Guid LanguageId { get; set; }
        public IFormFile Img { get; set; }
    }
}

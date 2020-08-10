﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ApplicationService.Catalog.Products.Dtos.Manage
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
        public Guid LanguageId { set; get; }
    }
}

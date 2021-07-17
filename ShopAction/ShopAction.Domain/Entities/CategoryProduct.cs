﻿using System;
namespace ShopAction.Domain.Entities
{
    public class CategoryProduct
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

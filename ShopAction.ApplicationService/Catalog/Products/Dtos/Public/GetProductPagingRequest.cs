using ShopAction.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ApplicationService.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest: PagingRequestBase
    {
        public Guid? CategoryId { get; set; }
    }
}

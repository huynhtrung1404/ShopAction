using ShopAction.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ApplicationService.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> CategoryIds { get; set; }
    }
}

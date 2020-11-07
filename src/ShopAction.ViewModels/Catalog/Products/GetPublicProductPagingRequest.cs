using ShopAction.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public Guid? CategoryId { get; set; }
    }
}

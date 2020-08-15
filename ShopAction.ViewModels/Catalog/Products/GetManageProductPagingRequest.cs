using ShopAction.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> CategoryIds { get; set; }
    }
}

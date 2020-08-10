using ShopAction.ApplicationService.Catalog.Products.Dtos.Manage;
using ShopAction.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(Guid categoryId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}

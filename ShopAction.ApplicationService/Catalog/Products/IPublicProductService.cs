using ShopAction.ApplicationService.Catalog.Products.Dtos.Manage;
using ShopAction.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(Guid categoryId, int pageIndex, int pageSize);
    }
}

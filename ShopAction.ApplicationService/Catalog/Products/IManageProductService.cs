using ShopAction.ApplicationService.Catalog.Products.Dtos;
using ShopAction.ApplicationService.Catalog.Products.Dtos.Manage;
using ShopAction.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(Guid productId);
        Task<bool> UpdatePrice(Guid productId, decimal newPrice);
        Task<bool> UpdateStock(Guid productId, int addedQUantity);
        Task AddViewCount(Guid productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}

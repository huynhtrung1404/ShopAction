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
        Task<Guid> Update(ProductUpdateRequest request);
        Task<bool> Delete(Guid productId);
        Task<List<ProductViewModel>> GetAll();
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQUantity);
        Task AddViewCount(Guid productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}

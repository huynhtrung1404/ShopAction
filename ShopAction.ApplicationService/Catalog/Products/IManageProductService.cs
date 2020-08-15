using Microsoft.AspNetCore.Http;
using ShopAction.ViewModels.Catalog.Products;
using ShopAction.ViewModels.Catalog.Products.Manage;
using ShopAction.ViewModels.Commons;
using System;
using System.Collections.Generic;
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
        Task<int> AddImages(int productId, List<IFormFile> files);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImage(int imageId, string caption, bool isDefault);
    }
}

using Microsoft.AspNetCore.Http;
using ShopAction.ViewModels.Catalog.Products;
using ShopAction.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public interface IManageProductService
    {
        Task<Guid> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(Guid productId);
        Task<bool> UpdatePrice(Guid productId, decimal newPrice);
        Task<bool> UpdateStock(Guid productId, int addedQUantity);
        Task AddViewCount(Guid productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImages(Guid productId, List<IFormFile> files);
        Task<int> RemoveImages(Guid imageId);
        Task<int> UpdateImage(Guid imageId, string caption, bool isDefault);
        Task<ProductViewModel> GetProductById(Guid id, Guid languageId);
        Task<List<ProductImageViewModel>> GetListImage(Guid productId);
    }
}

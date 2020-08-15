using ShopAction.ViewModels.Catalog.Products;
using ShopAction.ViewModels.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);

        Task<List<ProductViewModel>> GetAll();
    }
}

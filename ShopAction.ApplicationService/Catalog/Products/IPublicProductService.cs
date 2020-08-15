using ShopAction.ViewModels.Catalog.Products;
using ShopAction.ViewModels.Catalog.Products.Public;
using ShopAction.ViewModels.Commons;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}

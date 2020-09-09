using ShopAction.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategory();
        Task<bool> UpdateCategory(Guid id);
        Task<bool> DeleteCategory(Guid id);
    }
}

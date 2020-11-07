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
        Task<int> UpdateCategory(UpdateCategoryRequest request);
        Task<bool> DeleteCategory(Guid id);
        Task<int> AddNewCategory(AddCategoryRequest request);
    }
}

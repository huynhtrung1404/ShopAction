using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAction.ApplicationService.Catalog.Categories;
using ShopAction.ViewModels.Catalog.Categories;

namespace ShopAction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await categoryService.GetAllCategory();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]AddCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is invalid");
            }
            return Ok(await categoryService.AddNewCategory(request));
        }
    }
}

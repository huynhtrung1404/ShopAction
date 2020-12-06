using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAction.Application.Features.Categories.Commands;
using ShopAction.Application.Features.Categories.Queries;
using ShopAction.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAction.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await Mediator.Send(new GetAllCategoryQuery()));
        }

        [HttpPost]
        [Route("AddNewCategory")]
        public async Task<IActionResult> AddNewCategory(AddCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}

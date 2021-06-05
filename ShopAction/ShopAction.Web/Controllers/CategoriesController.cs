using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IMediator mediator):base(mediator)
        {

        }
        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await _mediator.Send(new GetAllCategoryQuery()));
        }

        [HttpPost]
        [Route("AddNewCategory")]
        public async Task<IActionResult> AddNewCategory(AddCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

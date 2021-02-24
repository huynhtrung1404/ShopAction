using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAction.Application.Features.Products.Commands;
using ShopAction.Application.Features.Products.Queries;
using ShopAction.Web.Controllers.Base;

namespace ShopAction.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetListProduct()));
        }
        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery(id)));
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Add(AddProductCommand command)
        {
            command.Id = Guid.NewGuid();
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("AddProductImage")]
        public async Task<IActionResult> AddImage([FromForm] UploadProductImageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] EditProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAction.Application.Features.Products.Queries;
using ShopAction.Web.Commons;

namespace ShopAction.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator):base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _mediator.Send(new GetAllProduct()));
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetAllProduct(int pageSize, int pageIndex)
        {
            return Ok(await _mediator.Send(new GetAllProductPaging(pageSize, pageIndex)));
        }
        
    }
}

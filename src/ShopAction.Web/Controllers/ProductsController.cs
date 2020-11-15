using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAction.Application.Features.Products.Queries;
using ShopAction.Web.Controllers.Base;

namespace ShopAction.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController{
        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAll(){
            return Ok(await Mediator.Send(new GetListProduct()));
        }
    }
}
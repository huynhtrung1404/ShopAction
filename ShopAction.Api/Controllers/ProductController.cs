using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAction.ApplicationService.Catalog.Products;

namespace ShopAction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService publicProductService;
        public ProductController(IPublicProductService publicProductService)
        {
            this.publicProductService = publicProductService;
        }
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> Get()
        {
            var result = await publicProductService.GetAll();
            return Ok(result);
        }
    }
}

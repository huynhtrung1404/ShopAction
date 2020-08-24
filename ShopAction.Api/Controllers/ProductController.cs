using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAction.ApplicationService.Catalog.Products;
using ShopAction.ViewModels.Catalog.Products;

namespace ShopAction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService publicProductService;
        private readonly IManageProductService manageProductService;
        public ProductController(IPublicProductService publicProductService,IManageProductService manageProductService)
        {
            this.publicProductService = publicProductService;
            this.manageProductService = manageProductService;
        }
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> Get()
        {
            var result = await publicProductService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await manageProductService.GetProductById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await publicProductService.GetAllByCategoryId(request);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductCreateRequest request)
        {
            var result = await manageProductService.Create(request);
            if (result == Guid.Empty)
            {
                return BadRequest();
            }

            var product = await manageProductService.GetProductById(result);
            return CreatedAtAction(nameof(GetProductById), new { id = result},product );
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductUpdateRequest request)
        {
            var result = await manageProductService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await manageProductService.Delete(id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery]Guid id, decimal newPrice)
        {
            var result = await manageProductService.UpdatePrice(id, newPrice);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}

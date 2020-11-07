using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAction.ApplicationService.Catalog.Products;
using ShopAction.ViewModels.Catalog.Products;

namespace ShopAction.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService publicProductService;
        private readonly IManageProductService manageProductService;
        public ProductsController(IPublicProductService publicProductService,IManageProductService manageProductService)
        {
            this.publicProductService = publicProductService;
            this.manageProductService = manageProductService;
        }
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> Get()
        {
            var result =   await publicProductService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetProductById/{productId}/{languageId}")]
        public async Task<IActionResult> GetProductById(Guid productId, Guid languageId)
        {
            var result = await manageProductService.GetProductById(productId, languageId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> Get(Guid languageId,[FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await publicProductService.GetAllByCategoryId(languageId,request);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await manageProductService.Create(request);
            if (result == Guid.Empty)
            {
                return BadRequest();
            }

            var product = await manageProductService.GetProductById(result,Guid.Parse(request.LanguageId));
            return Ok(product.Id);
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
        public async Task<IActionResult> Delete(Guid productId)
        {
            var result = await manageProductService.Delete(productId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery]Guid productId, decimal newPrice)
        {
            var result = await manageProductService.UpdatePrice(productId, newPrice);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}

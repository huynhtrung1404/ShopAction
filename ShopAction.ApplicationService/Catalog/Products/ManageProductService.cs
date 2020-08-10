using ShopAction.ApplicationService.Catalog.Products.Dtos.Manage;
using ShopAction.ApplicationService.Dtos;
using ShopAction.Data.Ef;
using ShopAction.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly ApplicationDbContext context;
        public ManageProductService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price            
            };
            context.Products.Add(product);
            return await context.SaveChangesAsync();
        }

        public async Task<Guid> Delete(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

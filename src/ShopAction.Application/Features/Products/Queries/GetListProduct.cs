using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Features.Products.Queries.Dtos;

namespace ShopAction.Application.Features.Products.Queries
{
    public class GetListProduct : IRequest<IList<ProductDto>>
    {

    }
    public class ProductQueryHandler : IRequestHandler<GetListProduct, IList<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        public ProductQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<ProductDto>> Handle(GetListProduct request, CancellationToken cancellationToken)
        {
            var result = from p in await _context.Products.ToListAsync()
                            join l in _context.ProductTranslations on p.Id equals l.ProductId
                            join ca in _context.ProductInCategories on p.Id equals ca.CategoryId
                            join c in _context.Categories on ca.CategoryId equals c.Id
                            select new ProductDto {
                                Id = p.Id,
                                DateTime = DateTime.Now.ToString(),
                                Description = l.Description,
                                Language = l.Language.Name,
                                Name = l.Name,
                                Category = c.Id.ToString()
                            };
            return result.ToList();

        }
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Features.Products.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Products.Queries
{
    public class GetProductByIdQuery :IRequest<ProductDto>
    { 
        public Guid Id { get; set; }
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IApplicationDbContext _context;
        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = from product in await _context.Products.ToListAsync()
                         where product.Id.Equals(request.Id)
                         join productTranslation in _context.ProductTranslations on product.Id equals productTranslation.ProductId
                         join productCategory in _context.ProductInCategories on product.Id equals productCategory.ProductId
                         join category in _context.Categories on productCategory.CategoryId equals category.Id
                         select new ProductDto
                         {
                             Id = product.Id,
                             Category = category.Id.ToString(),
                             DateTime = product.DateCreated.ToString(),
                             Name = productTranslation.Name,
                             Description = productTranslation.Description,
                             Language = productTranslation.Name
                         };
            return result.First();
                         
        }
    }
}

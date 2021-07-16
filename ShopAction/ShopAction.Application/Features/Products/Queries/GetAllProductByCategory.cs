using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopAction.Application.Dtos;

namespace ShopAction.Application.Features.Products.Queries
{
    public class GetAllProductByCategory : IRequest<IEnumerable<ProductDto>>
    {
        public GetAllProductByCategory(string categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class GetAllProductByCategoryHandler : IRequestHandler<GetAllProductByCategory, IEnumerable<ProductDto>>
    {
        public Task<IEnumerable<ProductDto>> Handle(GetAllProductByCategory request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

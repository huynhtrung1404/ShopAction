using System;
using System.Collections.Generic;
using MediatR;
using ShopAction.Application.Dtos;

namespace ShopAction.Application.Features.Products.Queries
{
    public class GetAllProductByCategory : IRequest<IEnumerable<ProductDto>>
    {
        
    }
}

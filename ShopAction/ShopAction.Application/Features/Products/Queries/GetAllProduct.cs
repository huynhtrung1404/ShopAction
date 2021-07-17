using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopAction.Application.Dtos;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Application.Features.Products.Queries
{
    public class GetAllProduct : IRequest<IEnumerable<ProductDto>>
    {
        
    }

    public class GetAllProductHandler : IRequestHandler<GetAllProduct, IEnumerable<ProductDto>>
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IRepository<Product, Guid> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProduct request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products.ToList());
        }
    }
}

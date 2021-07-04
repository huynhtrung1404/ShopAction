using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopAction.Application.Common.Extensions;
using ShopAction.Application.Dtos;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Application.Features.Products.Queries
{
    public class GetAllProductPaging : IRequest<IEnumerable<ProductDto>>
    {
        public GetAllProductPaging(int pageSize, int pageIndex)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }

    public class GetAllProductPagingHandler : IRequestHandler<GetAllProductPaging, IEnumerable<ProductDto>>
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductPagingHandler(IRepository<Product, Guid> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductPaging request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAndPagingAsync(request.PageSize, request.PageIndex);

            var results = _mapper.Map<IEnumerable<ProductDto>>(products);

            return results;
        }
    }
}

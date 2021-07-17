using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopAction.Application.Dtos;
using ShopAction.Application.Models;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Application.Features.Products.Queries
{
    public class GetAllProductPaging : IRequest<IEnumerable<ProductDto>>
    {
        public GetAllProductPaging(int pageSize, int pageIndex)
        {
            PagingModel = new PagingModel(pageSize, pageIndex);
        }

        public PagingModel PagingModel { get; set; }
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
            var products = await _productRepository.GetAllIncludePagingAsync(request.PagingModel.PageSize, request.PagingModel.PageNumber);

            var results = _mapper.Map<IEnumerable<ProductDto>>(products);

            return results;
        }
    }
}

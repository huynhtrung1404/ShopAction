using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetAllProductByCategory : IRequest<IEnumerable<ProductDto>>
    {
        public GetAllProductByCategory(Guid categoryId, int pageSize, int pageNumber)
        {
            CategoryId = categoryId;
            PagingModel = new PagingModel(pageSize, pageNumber);
        }

        public Guid CategoryId { get; set; }
        public PagingModel PagingModel { get; set; }
    }

    public class GetAllProductByCategoryHandler : IRequestHandler<GetAllProductByCategory, IEnumerable<ProductDto>>
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductByCategoryHandler(IRepository<Product, Guid> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductByCategory request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAllAsync(x => x.Categories.Where(x => x.Id.Equals(request.CategoryId)),request.PagingModel.PageSize,request.PagingModel.PageNumber);
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
    }
}

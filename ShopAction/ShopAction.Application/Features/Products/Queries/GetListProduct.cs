using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<ProductDto>> Handle(GetListProduct request, CancellationToken cancellationToken)
        {
            var data = await Task.Run(() => unitOfWork.ProductRepo.GetAllData());
            var result = mapper.Map<IList<ProductDto>>(data);

            return result;
        }

    }
}
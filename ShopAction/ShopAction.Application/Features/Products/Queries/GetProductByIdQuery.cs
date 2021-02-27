using AutoMapper;
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
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await Task.Run(() => unitOfWork.ProductRepo.Find(x => x.Id == request.Id).FirstOrDefault());
            var result = mapper.Map<ProductDto>(data);
            return result;

        }
    }
}

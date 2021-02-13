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
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() => from product in unitOfWork.ProductRepo.Find(x => x.Id == request.Id)
                                              join productTranslation in unitOfWork.ProductTranslationRepo.GetAllData() on product.Id equals productTranslation.ProductId
                                              join productCategory in unitOfWork.ProductInCategoryRepo.GetAllData() on product.Id equals productCategory.ProductId
                                              join category in unitOfWork.CategoryRepo.GetAllData() on productCategory.CategoryId equals category.Id
                                              join categoryTranslation in unitOfWork.CategoryTranslationRepo.GetAllData() on category.Id equals categoryTranslation.CategoryId
                                              select new ProductDto
                                              {
                                                  Id = product.Id,
                                                  Category = categoryTranslation.Name,
                                                  DateTime = product.DateCreated.ToString(),
                                                  Name = productTranslation.Name,
                                                  Description = productTranslation.Description,
                                                  Language = productTranslation.Name
                                              });
            return result.FirstOrDefault();

        }
    }
}

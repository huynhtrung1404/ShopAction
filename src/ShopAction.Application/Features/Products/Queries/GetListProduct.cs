using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Features.Products.Queries.Dtos;

namespace ShopAction.Application.Features.Products.Queries
{
    public class GetListProduct : IRequest<IQueryable<ProductDto>>
    {

    }
    public class ProductQueryHandler : IRequestHandler<GetListProduct, IQueryable<ProductDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<ProductDto>> Handle(GetListProduct request, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() => from p in unitOfWork.ProductRepo.GetAllData()
                                              join l in unitOfWork.ProductTranslationRepo.GetAllData() on p.Id equals l.ProductId
                                              join ca in unitOfWork.ProductInCategoryRepo.GetAllData() on p.Id equals ca.ProductId
                                              join c in unitOfWork.CategoryRepo.GetAllData() on ca.CategoryId equals c.Id
                                              join lang in unitOfWork.LanguageRepo.GetAllData() on l.LanguageId equals lang.Id
                                              join cat in unitOfWork.CategoryTranslationRepo.GetAllData() on c.Id equals cat.CategoryId
                                              select new ProductDto
                                              {
                                                  Id = p.Id,
                                                  DateTime = DateTime.Now.ToString(),
                                                  Description = l.Description,
                                                  Language = lang.Name,
                                                  Name = l.Name,
                                                  Category = cat.Name
                                              });
            return result;
        }

    }
}
using MediatR;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Features.Categories.Queries.Dtos;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopAction.Application.Features.Categories.Queries
{
    public class GetAllCategoryQuery : IRequest<IQueryable<CategoryDto>>
    {
    }

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IQueryable<CategoryDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() => from c in unitOfWork.CategoryRepo.GetAllData()
                                              join ci in unitOfWork.CategoryTranslationRepo.GetAllData() on c.Id equals ci.CategoryId
                                              join lang in unitOfWork.LanguageRepo.GetAllData() on ci.LanguageId equals lang.Id
                                              select new CategoryDto
                                              {
                                                  Id = c.Id.ToString(),
                                                  Description = ci.SeoDescription,
                                                  Language = lang.Name,
                                                  IsShowOnHome = c.IsShowOnHome,
                                                  Name = ci.Name
                                              });
            return result;

        }
    }
}

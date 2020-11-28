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
    public class GetAllCategoryQuery :IRequest<IList<CategoryDto>>
    {
    }

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IList<CategoryDto>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllCategoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = from c in _context.Categories
                         join ci in _context.CategoryTranslations on c.Id equals ci.CategoryId
                         join lang in _context.Languages on ci.LanguageId equals lang.Id
                         select new CategoryDto
                         {
                             Id = c.Id.ToString(),
                             Description = ci.SeoDescription,
                             Language = lang.Name,
                             IsShowOnHome = c.IsShowOnHome,
                             Name = ci.Name
                         };
            return await result.ToListAsync();

        }
    }
}

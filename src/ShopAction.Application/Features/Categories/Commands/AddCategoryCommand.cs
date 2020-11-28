using MediatR;
using ShopAction.Application.Common.Interface;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Enum;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Categories.Commands
{
    public class AddCategoryCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsShowOnHome { get; set; }
        public int Status { get; set; }
        public string SeoTile { get; set; }
        public Guid LanguageId { get; set; }
    }

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public AddCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryId = Guid.NewGuid();
            await _context.Categories.AddAsync(new Category
            {
                Id = categoryId,
                Status = Status.Active,
                SortOrder = 1,
                IsShowOnHome = request.IsShowOnHome
            });

            await _context.CategoryTranslations.AddAsync(new CategoryTranslation
            {
                CategoryId = categoryId,
                Id = Guid.NewGuid(),
                LanguageId = request.LanguageId,
                SeoDescription = request.Description,
                Name = request.Name
            });

            var result = await _context.SaveChangeAsync(cancellationToken);

            return result.Equals(1);
        }
    }
}

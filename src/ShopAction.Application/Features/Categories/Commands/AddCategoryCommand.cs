using MediatR;
using ShopAction.Application.Common.Interface;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Enum;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Categories.Commands
{
    public class AddCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsShowOnHome { get; set; }
        public int Status { get; set; }
        public string SeoTile { get; set; }
        public Guid LanguageId { get; set; }
    }

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CategoryRepo.AddAsync(new Category
            {
                Status = Status.Active,
                SortOrder = 1,
                IsShowOnHome = request.IsShowOnHome
            });

            await unitOfWork.CategoryTranslationRepo.AddAsync(new CategoryTranslation
            {
                Id = Guid.NewGuid(),
                LanguageId = request.LanguageId,
                SeoDescription = request.Description,
                Name = request.Name
            });

            var result = await unitOfWork.Completed();

            return result;
        }
    }
}

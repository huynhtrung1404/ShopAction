using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAction.Application.Common.Exceptions;
using ShopAction.Application.Common.Interface;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Enum;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsShowOnHome { get; set; }
        public int Status { get; set; }

    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var info = await _context.Categories.FindAsync(request.Id);
            var infoName = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == request.Id);
            if (info == null)
            {
                throw new NotFoundException("Category doesn't exist");
            }

            info.IsShowOnHome = request.IsShowOnHome;
            info.Status = request.Status == 1 ? Status.Active : Status.InActive;
            infoName.Name = request.Name;

            var result = await _context.SaveChangeAsync(cancellationToken);

            return result == 1;
           
        }
    }
}

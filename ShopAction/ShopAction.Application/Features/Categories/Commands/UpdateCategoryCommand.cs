using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAction.Application.Common.Exceptions;
using ShopAction.Application.Common.Interface;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Enum;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsShowOnHome { get; set; }
        public int Status { get; set; }

    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var info = unitOfWork.CategoryRepo.Find(x => x.Id == request.Id).FirstOrDefault();
            if (info == null)
            {
                throw new NotFoundException("Category doesn't exist");
            }

            info.IsShowOnHome = request.IsShowOnHome;
            info.Status = request.Status == 1 ? Status.Active : Status.InActive;
            info.Name = request.Name;

            var result = await unitOfWork.Completed();

            return result;

        }
    }
}

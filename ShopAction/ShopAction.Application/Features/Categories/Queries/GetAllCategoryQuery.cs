using MediatR;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Features.Categories.Queries.Dtos;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ShopAction.Application.Features.Categories.Queries
{
    public class GetAllCategoryQuery : IRequest<IList<CategoryDto>>
    {
    }

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IList<CategoryDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var data = await Task.Run(() => unitOfWork.CategoryRepo.GetAllData());

            var result = mapper.Map<IList<CategoryDto>>(data);

            return result;

        }
    }
}

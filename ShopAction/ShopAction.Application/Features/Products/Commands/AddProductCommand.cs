using MediatR;
using ShopAction.Application.Common.Interface;
using ShopAction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Products.Commands
{
    public class AddProductCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.ProductRepo.AddAsync(new Product
            {
                Id = request.Id,
                Price = request.Price,
                DateCreated = DateTime.Now,
                OriginalPrice = request.Price,
                Stock = request.Stock,
                Name = request.Name,

            });

            await unitOfWork.ProductInCategoryRepo.AddAsync(new ProductInCategory
            {
                CategoryId = request.CategoryId,
                ProductId = request.Id
            });

            return await unitOfWork.Completed();

        }
    }
}

using MediatR;
using ShopAction.Application.Common.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopAction.Application.Common.Exceptions;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Features.Products.Commands
{
    public class EditProductCommand : IRequest<int>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        public EditProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = unitOfWork.ProductRepo.Find(x => x.Id == request.ProductId).FirstOrDefault();
            var productName = unitOfWork.ProductTranslationRepo.Find(x => x.ProductId == request.ProductId).FirstOrDefault();
            if (product == null || productName == null)
            {
                throw new NotFoundException();
            }

            product.Price = request.Price;
            product.Stock = request.Stock;
            productName.Name = request.Name;


            return await unitOfWork.Completed();

        }
    }
}

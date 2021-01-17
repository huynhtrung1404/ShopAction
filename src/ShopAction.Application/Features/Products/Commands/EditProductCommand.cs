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
    public class EditProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public EditProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);
            var productName = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.ProductId);
            if (product == null)
            {
                throw new NotFoundException();
            }

            product.Price = request.Price;
            product.Stock = request.Stock;
            productName.Name = request.Name;
            var result = await _context.SaveChangeAsync(cancellationToken);

            return result ==1;

        }
    }
}

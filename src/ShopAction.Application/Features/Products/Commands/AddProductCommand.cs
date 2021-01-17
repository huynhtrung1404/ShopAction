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
    public class AddProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public Guid CategoryId { get; set; }
        public Guid Language { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public AddProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(new Product
            {
                Id = request.Id,
                Price = request.Price,
                DateCreated = DateTime.Now,
                OriginalPrice = request.Price,
                Stock = request.Stock
            });
            await _context.ProductTranslations.AddAsync(new ProductTranslation
            {
                Description = request.Description,
                ProductId = request.Id,
                Name = request.Name,
                LanguageId = request.Language,
                SeoTitle = request.Name,
                Id = Guid.NewGuid()
            });

            await _context.ProductInCategories.AddAsync(new ProductInCategory
            {
                CategoryId = request.CategoryId,
                ProductId = request.Id
            });

            var result = await _context.SaveChangeAsync(cancellationToken);
            return result == 1;
        }
    }
}

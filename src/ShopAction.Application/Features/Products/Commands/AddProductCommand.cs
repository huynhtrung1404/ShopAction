using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Products.Commands
{
    public class AddProductCommand:IRequest<bool>
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
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        public Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

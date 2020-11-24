using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Application.Features.Products.Commands
{
    public class EditProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
    }

    public class EditProductCommandHandler :IRequestHandler<EditProductCommand, bool>
    {

    }
}

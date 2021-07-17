using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopAction.Application.Dtos;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Application.Features.Products.Commands
{
    public class AddNewProduct : IRequest<bool>
    {
        public AddNewProduct(ProductDto product)
        {
            Product = product;
        }
        public ProductDto Product;
    }

    public class AddNewProductHandler : IRequestHandler<AddNewProduct, bool>
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<CategoryProduct, Guid> _categoryProduct;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddNewProductHandler(IRepository<Product, Guid> productRepository, IRepository<CategoryProduct, Guid> categoryProduct, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryProduct = categoryProduct;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddNewProduct request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);

            await _productRepository.AddAsync(product);
            await _unitOfWork.CommitChangesAsync();

            return true;
        }
    }
}

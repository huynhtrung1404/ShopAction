using MediatR;
using Microsoft.AspNetCore.Http;
using ShopAction.Application.Common.Interface;
using ShopAction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Products.Commands
{
    public class UploadProductImageCommand : IRequest<string>
    {
        public Guid ProductId { get; set; }
        public IList<IFormFile> Files { get; set; }
    }
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand, string>
    {
        private const string FOLDER_NAME = "Assets/Images";
        private readonly IApplicationDbContext _context;
        public UploadProductImageCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
        {
            foreach (var formFile in request.Files)
            {
                if (formFile.Length > 0)
                {
                    Directory.CreateDirectory(FOLDER_NAME);
                    var folder = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME);
                    var filePath = Path.Combine(folder, formFile.FileName);
                    using (var stream = File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                        await _context.ProductImages.AddAsync(
                            new ProductImage { 
                                Id = Guid.NewGuid(),
                                Path = filePath,
                                ProductId = request.ProductId,
                                FileSize = request.Files.Sum(x => x.Length),
                                DateCreated = DateTime.Now
                            });
                        await _context.SaveChangeAsync(cancellationToken);
                        return formFile.FileName;
                    }
                }
            }
            return string.Empty;
        }
    }
}

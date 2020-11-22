using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Features.Products.Commands
{
    public class UploadProductImageCommand : IRequest<string>
    {
        public IList<IFormFile> Files { get; set; }
    }
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand, string>
    {
        private const string FOLDER_NAME = "Assets/Images";
        public async Task<string> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
        {
            foreach (var formFile in request.Files)
            {
                if (formFile.Length > 0)
                {
                    Directory.CreateDirectory(FOLDER_NAME);
                    var folder = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME);
                    var filePath = Path.Combine(folder, formFile.FileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                        return formFile.FileName;
                    }
                }
            }
            return string.Empty;
        }
    }
}

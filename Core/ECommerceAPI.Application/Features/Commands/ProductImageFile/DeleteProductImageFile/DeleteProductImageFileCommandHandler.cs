using ECommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pro = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Commands.ProductImageFile.DeleteProductImageFile
{
    public class DeleteProductImageFileCommandHandler : IRequestHandler<DeleteProductImageFileCommandRequest, DeleteProductImageFileCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

        public DeleteProductImageFileCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository, IProductReadRepository productReadRepository)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<DeleteProductImageFileCommandResponse> Handle(DeleteProductImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            pro.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                        .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            pro.ProductImageFile? productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if(productImageFile != null)
                product?.ProductImageFiles.Remove(productImageFile);

            await _productImageFileWriteRepository.SaveAsync();

            return new();
        }
    }
}

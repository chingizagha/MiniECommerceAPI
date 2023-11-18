using ECommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pro = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImageFiles
{
    public class GetProductImageFilesQueryHandler : IRequestHandler<GetProductImageFilesQueryRequest, List<GetProductImageFilesQueryResponse>>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetProductImageFilesQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetProductImageFilesQueryResponse>> Handle(GetProductImageFilesQueryRequest request, CancellationToken cancellationToken)
        {
            pro.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                        .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            return product?.ProductImageFiles.Select(p => new GetProductImageFilesQueryResponse
            {
                Path = p.Path,
                FileName = p.FileName,
                Id = p.Id
            }).ToList();

        }
    }
}

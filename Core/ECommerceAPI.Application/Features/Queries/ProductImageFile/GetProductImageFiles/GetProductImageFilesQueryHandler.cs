using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImageFiles
{
    public class GetProductImageFilesQueryHandler : IRequestHandler<GetProductImageFilesQueryRequest, GetProductImageFilesQueryResponse>
    {
        public Task<GetProductImageFilesQueryResponse> Handle(GetProductImageFilesQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

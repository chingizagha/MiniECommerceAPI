using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImageFiles
{
    public class GetProductImageFilesQueryRequest : IRequest<List<GetProductImageFilesQueryResponse>>
    {
        public string Id { get; set; }
    }
}

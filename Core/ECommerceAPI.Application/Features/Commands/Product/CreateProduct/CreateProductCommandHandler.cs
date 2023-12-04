using ECommerceAPI.Application.Abstractions.Hubs;
using ECommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly ILogger<CreateProductCommandHandler> _logger;
        readonly IProductHubService _productHubService;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, ILogger<CreateProductCommandHandler> logger, IProductHubService productHubService)
        {
            _productWriteRepository = productWriteRepository;
            _logger = logger;
            _productHubService = productHubService;
        }


        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });
            await _productWriteRepository.SaveAsync();
            _logger.LogInformation("Product added");
            await _productHubService.ProductAddedMessageAsync($"{request.Name} product is added");
            return new();
        }
    }
}

using ECommerceAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.Basket.RemoveBasket
{
    public class RemoveBasketCommandHandler : IRequestHandler<RemoveBasketCommandRequest, RemoveBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public RemoveBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<RemoveBasketCommandResponse> Handle(RemoveBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.RemoveBasketItemAsync(request.BasketItemId);

            return new();
        }
    }
}

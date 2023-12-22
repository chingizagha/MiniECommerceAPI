using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.Basket.RemoveBasket
{
    public class RemoveBasketCommandRequest : IRequest<RemoveBasketCommandResponse>
    {
        public string BasketItemId { get; set; }
    }
}

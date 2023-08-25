using ECommerceAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly IProductReadRepository _productReadRepository;

        public ValuesController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }



        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddAsync(new() { Name = "C prod", Price = 1.500F, Stock = 10, CreatedDate = DateTime.UtcNow });
            await _productWriteRepository.SaveAsync();
        }
    }
}

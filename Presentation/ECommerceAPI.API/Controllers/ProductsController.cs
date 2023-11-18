using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Commands.Product.DeleteProduct;
using ECommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImageFile.DeleteProductImageFile;
using ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImageFile;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetByIdProduct;
using ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImageFiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
           GetAllProductQueryResponse response =  await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response =  await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response =  await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse response =  await _mediator.Send(deleteProductCommandRequest);
            return Ok();
        }


       [HttpPost("[action]")]
       public async Task<IActionResult> Upload([FromQuery] UploadProductImageFileCommandRequest uploadProductImageFileCommandRequest)
       {
            uploadProductImageFileCommandRequest.Files = Request.Form.Files;
            UploadProductImageFileCommandResponse response = await _mediator.Send(uploadProductImageFileCommandRequest);
            return Ok();
       }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImageFilesQueryRequest getProductImageFilesQueryRequest)
        {
            List<GetProductImageFilesQueryResponse> response = await _mediator.Send(getProductImageFilesQueryRequest);
            return Ok(response);
        }


        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] DeleteProductImageFileCommandRequest deleteProductImageFileCommandRequest, [FromQuery] string imageId)
        {
            deleteProductImageFileCommandRequest.ImageId = imageId;
            DeleteProductImageFileCommandResponse response = await _mediator.Send(deleteProductImageFileCommandRequest);
            return Ok();
        }
    }
}

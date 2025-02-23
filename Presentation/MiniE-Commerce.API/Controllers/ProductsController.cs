using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniE_Commerce.Application.Consts;
using MiniE_Commerce.Application.CustomAttributes;
using MiniE_Commerce.Application.Enums;
using MiniE_Commerce.Application.Features.Commands.Product.CreateProduct;
using MiniE_Commerce.Application.Features.Commands.Product.RemoveProduct;
using MiniE_Commerce.Application.Features.Commands.Product.UpdateProduct;
using MiniE_Commerce.Application.Features.Commands.ProductImageFile.ChangeShowCaseImage;
using MiniE_Commerce.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using MiniE_Commerce.Application.Features.Commands.ProductImageFile.UploadProductImage;
using MiniE_Commerce.Application.Features.Queries.Product.GetAllProduct;
using MiniE_Commerce.Application.Features.Queries.Product.GetByIdProduct;
using MiniE_Commerce.Application.Features.Queries.ProductImageFile.GetProductImage;
using System.Net;

namespace MiniE_Commerce.API.Controllers
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
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest request)
        {
            GetAllProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Product Images")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImageQueryRequest request)
        {
            List<GetProductImageQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Create Product")]
        public async Task<IActionResult> Post(CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Updating Product")]
        public async Task<IActionResult> Put(UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest request)
        {
            RemoveProductCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product Images")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest request, [FromQuery] string imageId)
        {
            request.ImageId = imageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("upload")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product File")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest request)
        {
            request.Files = Request.Form.Files;
            UploadProductImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Change Show Case")]
        public async Task<IActionResult> ChangeShowCase(ChangeShowCaseImageCommandRequest request)
        {
            ChangeShowCaseImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

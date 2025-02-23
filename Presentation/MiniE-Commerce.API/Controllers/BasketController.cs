using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniE_Commerce.Application.Consts;
using MiniE_Commerce.Application.CustomAttributes;
using MiniE_Commerce.Application.Enums;
using MiniE_Commerce.Application.Features.Commands.Basket.AddItemToBasket;
using MiniE_Commerce.Application.Features.Commands.Basket.RemoveBasketItem;
using MiniE_Commerce.Application.Features.Commands.Basket.UpdateQuantity;
using MiniE_Commerce.Application.Features.Queries.Basket.GetBasketItem;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Basket, ActionType = ActionType.Writing, Definition = "Add Items Basket")]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest request)
        {
            AddItemToBasketCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Basket, ActionType = ActionType.Reading, Definition = "Get Basket Items")]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemQueryRequest request)
        {
            List<GetBasketItemQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Basket, ActionType = ActionType.Updating, Definition = "Update Quantity")]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest request)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("BasketItemId")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Basket, ActionType = ActionType.Deleting, Definition = "Remove Basket Item")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest request)
        {
            RemoveBasketItemCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

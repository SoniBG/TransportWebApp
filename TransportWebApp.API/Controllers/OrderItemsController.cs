using Common.Models;
using Microsoft.AspNetCore.Mvc;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Exceptions;

namespace TransportWebApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemService orderItemService;

    public OrderItemsController(IOrderItemService orderItemService)
    {
        this.orderItemService = orderItemService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderItemDto>> GetAsync(int id)
    {
        try
        {
            var model = await orderItemService.GetOrderItemAsync(id);
            return Ok(model);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderItemDto>>> GetAsync()
    {
        try
        {
            var modelList = await orderItemService.GetOrderItemsAsync();
            return Ok(modelList);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] OrderItemDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var id = await orderItemService.CreateOrderItemAsync(model);
        return CreatedAtAction(nameof(GetAsync), new { id }, null);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] OrderItemDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await orderItemService.UpdateOrderItemAsync(model);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await orderItemService.DeleteOrderItemAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}

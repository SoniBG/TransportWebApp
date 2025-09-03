using Common.Models;
using Microsoft.AspNetCore.Mvc;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Exceptions;

namespace TransportWebApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService orderService;

    public OrdersController(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDto>> GetAsync(int id)
    {
        try
        {
            var model = await orderService.GetOrderAsync(id);
            return Ok(model);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> GetAsync()
    {
        try
        {
            var modelList = await orderService.GetOrdersAsync();
            return Ok(modelList);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] OrderDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var id = await orderService.CreateOrderAsync(model);
        return CreatedAtAction(nameof(GetAsync), new { id }, null);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] OrderDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await orderService.UpdateOrderAsync(model);
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
            await orderService.DeleteOrderAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}

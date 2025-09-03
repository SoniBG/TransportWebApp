using Common.Models;
using Microsoft.AspNetCore.Mvc;
using TransportWebApp.Application.Services;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Exceptions;

namespace TransportWebApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GoodsController : ControllerBase
{
    private readonly IGoodService goodService;

    public GoodsController(IGoodService goodService)
    {
        this.goodService = goodService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GoodDto>> GetAsync(int id)
    {
        try
        {
            var model = await goodService.GetGoodAsync(id);
            return Ok(model);
        }
        catch(NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<GoodDto>>> GetAsync()
    {
        try
        {
            var modelList = await goodService.GetGoodsAsync();
            return Ok(modelList);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<GoodDto>> CreateAsync([FromBody] GoodDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var id = await goodService.CreateGoodAsync(model);

        return CreatedAtAction(nameof(GetAsync), new { id }, null);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] GoodDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await goodService.UpdateGoodAsync(model);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await goodService.DeleteGoodAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}

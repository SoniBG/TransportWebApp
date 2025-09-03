using Common.Models;
using Microsoft.AspNetCore.Mvc;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Exceptions;

namespace TransportWebApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService vehicleService;

    public VehiclesController(IVehicleService vehicleService)
    {
        this.vehicleService = vehicleService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VehicleDto>> GetAsync(int id)
    {
        try
        {
            var model = await vehicleService.GetVehicleAsync(id);
            return Ok(model);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<VehicleDto>>> GetAsync()
    {
        try
        {
            var modelList = await vehicleService.GetVehiclesAsync();
            return Ok(modelList);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] VehicleDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var id = await vehicleService.CreateVehicleAsync(model);
        return CreatedAtAction(nameof(GetAsync), new { id }, null);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] VehicleDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await vehicleService.UpdateVehicleAsync(model);
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
            await vehicleService.DeleteVehicleAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}

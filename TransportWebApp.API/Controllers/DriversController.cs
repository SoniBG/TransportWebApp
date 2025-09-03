using Common.Models;
using Microsoft.AspNetCore.Mvc;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Exceptions;

namespace TransportWebApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriversController : ControllerBase
{
    private readonly IDriverService driverService;

    public DriversController(IDriverService driverService)
    {
        this.driverService = driverService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DriverDto>> GetAsync(int id)
    {
        try
        {
            var model = await driverService.GetDriverAsync(id);
            return Ok(model);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<DriverDto>>> GetAsync()
    {
        try
        {
            var modelList = await driverService.GetDriversAsync();
            return Ok(modelList);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] DriverDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var id = await driverService.CreateDriverAsync(model);
        return CreatedAtAction(nameof(GetAsync), new { id }, null);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] DriverDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await driverService.UpdateDriverAsync(model);
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
            await driverService.DeleteDriverAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}

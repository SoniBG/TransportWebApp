using Common.Models;
using Microsoft.AspNetCore.Mvc;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Exceptions;

namespace TransportWebApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceLinesController : ControllerBase
{
    private readonly IInvoiceLineService invoiceLineService;

    public InvoiceLinesController(IInvoiceLineService invoiceLineService)
    {
        this.invoiceLineService = invoiceLineService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<InvoiceLineDto>> GetAsync(int id)
    {
        try
        {
            var model = await invoiceLineService.GetInvoiceLineAsync(id);
            return Ok(model);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<InvoiceLineDto>>> GetAsync()
    {
        try
        {
            var modelList = await invoiceLineService.GetInvoiceLinesAsync();
            return Ok(modelList);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] InvoiceLineDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var id = await invoiceLineService.CreateInvoiceLineAsync(model);
        return CreatedAtAction(nameof(GetAsync), new { id }, null);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] InvoiceLineDto model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await invoiceLineService.UpdateInvoiceLineAsync(model);
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
            await invoiceLineService.DeleteInvoiceLineAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}

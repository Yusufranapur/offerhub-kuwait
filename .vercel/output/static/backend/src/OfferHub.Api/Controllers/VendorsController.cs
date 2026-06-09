using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OfferHub.Application.Features.Vendors.Commands;

namespace OfferHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Placeholder for GET request using MediatR
        await Task.CompletedTask;
        return Ok(new { Message = "Vendors endpoint working." });
    }

    [HttpPut("{id}/verification")]
    public async Task<IActionResult> UpdateVerification(Guid id, [FromBody] UpdateVendorVerificationCommand command)
    {
        if (id != command.VendorId)
        {
            return BadRequest("Vendor ID mismatch.");
        }

        var result = await _mediator.Send(command);
        
        if (result.Succeeded)
        {
            return Ok(new { Message = "Verification details updated successfully." });
        }

        return BadRequest(result.Errors);
    }
}
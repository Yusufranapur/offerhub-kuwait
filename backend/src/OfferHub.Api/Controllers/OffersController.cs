using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OfferHub.Application.Features.Offers.Commands;
using OfferHub.Application.Features.Offers.Queries;

namespace OfferHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OffersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OffersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetOffersQuery query)
    {
        var result = await _mediator.Send(query);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOfferCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok(result.Data);
    }
}
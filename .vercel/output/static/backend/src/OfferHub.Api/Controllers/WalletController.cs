using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OfferHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletController : ControllerBase
{
    private readonly IMediator _mediator;

    public WalletController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Placeholder for GET request using MediatR
        await Task.CompletedTask;
        return Ok(new { Message = "Wallet endpoint working." });
    }
}
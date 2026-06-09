using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OfferHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Placeholder for GET request using MediatR
        await Task.CompletedTask;
        return Ok(new { Message = "Files endpoint working." });
    }
}
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OfferHub.Application.Features.Files.Commands;

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

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using var stream = file.OpenReadStream();
        var command = new UploadFileCommand(stream, file.FileName, file.ContentType);
        
        var result = await _mediator.Send(command);
        
        if (result.Succeeded)
            return Ok(new { Url = result.Data });
            
        return BadRequest(result.Errors);
    }
}
using Microsoft.AspNetCore.Mvc;
using Playground.API.Services;

namespace Playground.API.Controllers;

[ApiController]
[Route("uploads")]
public class UploadsController : ControllerBase
{
    private readonly UploadsService _uploadsService;

    public UploadsController(UploadsService uploadsService)
    {
        _uploadsService = uploadsService;
    }
    
    [HttpPost("add-image")]
    public IActionResult Index(IFormFile file)
    {
        return Ok(_uploadsService.HandleImages(file));
    }
}
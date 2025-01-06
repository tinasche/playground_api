using Microsoft.AspNetCore.Mvc;
using Playground.API.Models.Dtos;
using Playground.API.Services;

namespace Playground.API.Controllers;

[ApiController]
[Route("emails")]
public class CommunicationsController : ControllerBase
{
    private readonly CommunicationsService _service;

    public CommunicationsController(CommunicationsService communicationsService)
    {
        _service = communicationsService;
    }

    [HttpPost("send-email")]
    public IActionResult SendEmail([FromBody] SendEmailDto sendEmailDto)
    {
        var username = _service.SendEmail(sendEmailDto);
        return Ok(username);
    }
}
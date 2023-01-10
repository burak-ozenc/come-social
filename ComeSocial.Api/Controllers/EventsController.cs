using Microsoft.AspNetCore.Mvc;

namespace ComeSocial.Api.Controllers;

[Route("events")]
public class EventsController : ApiController
{
    [HttpGet("listEvents")]
    public IActionResult ListEvents()
    {
        return Ok(Array.Empty<string>());
    }
}
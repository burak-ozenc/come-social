using ComeSocial.Application.SocialEvent.Commands;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComeSocial.Api.Controllers;


// [Authorize]
[Route("events")]
public class SocialEventsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public SocialEventsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet("listEvents")]
    public IActionResult ListEvents()
    {
        return Ok(Array.Empty<string>());
    }
    [HttpPost("CreateEvent")]
    public async Task<IActionResult> CreateEvent(CreateSocialEventRequest request)
    {
        // CreateEventRequest request
        var command = _mapper.Map<CreateSocialEventCommand>(request);
        var createEventResult = await _mediator.Send(command);
        
     
        return Ok(createEventResult);
    }
}
using ComeSocial.Application.ComeEventType.Commands.CreateComeEventType;
using ComeSocial.Application.Contracts.ComeEventType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComeSocial.Api.Controllers;

[Route("comeEventTypes")]
public class ComeEventTypeController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public ComeEventTypeController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("CreateComeEventType")]
    public async Task<IActionResult> CreateComeEventType(CreateComeEventTypeRequest request)
    {
        var command = _mapper.Map<CreateComeEventTypeCommand>(request);

        var createComeEventResult = await _mediator.Send(command);

        return Ok(_mapper.Map<CreateComeEventTypeResponse>(createComeEventResult));
    }
}
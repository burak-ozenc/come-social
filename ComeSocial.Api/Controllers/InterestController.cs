using ComeSocial.Application.Contracts.Interest;
using ComeSocial.Application.Interest.Commands.CreateInterestCommand;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComeSocial.Api.Controllers;

[Route("interests")]
public class InterestController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public InterestController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("CreateInterest")]
    public async Task<IActionResult> CreateInterest(CreateInterestRequest request)
    {
        var command = _mapper.Map<CreateInterestCommand>(request);

        var createInterestResult = await _mediator.Send(command);

        return Ok(_mapper.Map<CreateInterestResponse>(createInterestResult));
    }
}
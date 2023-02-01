using ComeSocial.Application.Contracts.Group;
using ComeSocial.Application.Group.Commands.CreateGroupCommand;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComeSocial.Api.Controllers;

[Route("group")]
public class GroupController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public GroupController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("CreateGroup")]
    public async Task<IActionResult> CreateTag(CreateGroupRequest request)
    {
        var command = _mapper.Map<CreateGroupCommand>(request);

        var createGroupResult = await _mediator.Send(command);

        return Ok(_mapper.Map<CreateGroupResponse>(createGroupResult));
    }
}
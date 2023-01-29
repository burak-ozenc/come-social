using ComeSocial.Application.Contracts.Tag;
using ComeSocial.Application.Tag.Commands;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComeSocial.Api.Controllers;

[Route("tags")]
public class TagsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public TagsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("CreateTag")]
    public async Task<IActionResult> CreateTag(CreateTagRequest request)
    {
        var command = _mapper.Map<CreateTagCommand>(request);

        var createTagResult = await _mediator.Send(command);

        return Ok(_mapper.Map<CreateTagResponse>(createTagResult));

    }
}
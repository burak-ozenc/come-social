using ComeSocial.Application.ChatMessage.Commands.SendMessage;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Application.Contracts.Message;
using ComeSocial.Infrastructure.Services;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ComeSocial.Api.Controllers;

// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("message")]
public class MessageController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    // private readonly IHubContext<MessageService> _hubContext;
    private readonly IMessageService _messageService;

    public MessageController(ISender mediator, 
        IMapper mapper, 
        IHubContext<MessageService> hubContext,
        IMessageService messageService)
    {
        _mediator = mediator;
        _mapper = mapper;
        // _hubContext = hubContext;
        _messageService = messageService;
    }
    
    
    [HttpPost("SendMessage")]
    public async Task<IActionResult> SendMessage([FromBody]ChatMessageRequest request)
    {
        var command = _mapper.Map<SendMessageCommand>(request);
        var sendMessageResult = await _mediator.Send(command);
        //
        // return Ok(_mapper.Map<CreateSocialEventResponse>(createEventResult));    
        
        return Ok(Array.Empty<string>());
    }
}
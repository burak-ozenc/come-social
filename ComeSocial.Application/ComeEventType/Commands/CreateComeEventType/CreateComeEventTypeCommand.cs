using MediatR;

namespace ComeSocial.Application.ComeEventType.Commands.CreateComeEventType;

public record CreateComeEventTypeCommand(
        string Name,
        DateTime? CreatedDateTime,
        DateTime? UpdatedDateTime
    ) 
    : IRequest<Domain.ComeEventType.ComeEventType>;
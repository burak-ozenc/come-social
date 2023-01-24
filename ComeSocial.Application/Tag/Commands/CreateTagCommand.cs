using MediatR;

namespace ComeSocial.Application.Tag.Commands;

public record CreateTagCommand(
    string Name, 
    DateTime? UpdatedDateTime,
    DateTime? CreatedDateTime) : IRequest<Domain.Tag.Tag>;
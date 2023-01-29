using MediatR;

namespace ComeSocial.Application.Tag.Commands;

public record CreateTagCommand(
    string Name, 
    // List<string> InterestIds,
    DateTime? UpdatedDateTime,
    DateTime? CreatedDateTime) : IRequest<Domain.Tag.Tag>;
using MediatR;

namespace ComeSocial.Application.Interest.Commands.CreateInterestCommand;

public record CreateInterestCommand(
    string Name,
    List<string> TagIds,
    DateTime? UpdatedDateTime,
    DateTime? CreatedDateTime) : IRequest<Domain.Interest.Interest>;
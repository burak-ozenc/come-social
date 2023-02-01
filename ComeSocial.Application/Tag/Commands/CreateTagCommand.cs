using MediatR;

namespace ComeSocial.Application.Tag.Commands;

public record CreateTagCommand(
<<<<<<< HEAD
    string Name,
=======
    string Name, 
    // List<string> InterestIds,
>>>>>>> 3859e355bf2b322bb20dc646a539f83c4f807a39
    DateTime? UpdatedDateTime,
    DateTime? CreatedDateTime) : IRequest<Domain.Tag.Tag>;
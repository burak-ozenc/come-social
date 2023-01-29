using ComeSocial.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace ComeSocial.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password
    ) : IRequest<AuthenticationResult>;
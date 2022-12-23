using ComeSocial.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace ComeSocial.Application.Authentication.Commands.Register;

public record LoginQuery (
    string Email,
    string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
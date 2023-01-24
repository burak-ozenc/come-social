using ComeSocial.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace ComeSocial.Application.Authentication.Queries.Login;

public record LoginQuery (
    string Email,
    string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
using ComeSocial.Application.Authentication.Common;
using FluentResults;
using MediatR;


namespace ComeSocial.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password
    ) : IRequest<Result<AuthenticationResult>>;
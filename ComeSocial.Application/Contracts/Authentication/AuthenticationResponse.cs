namespace ComeSocial.Application.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Token
    );
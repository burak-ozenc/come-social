namespace ComeSocial.Application.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
    );
using ComeSocial.Domain.Entities;

namespace ComeSocial.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
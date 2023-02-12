using ComeSocial.Domain.Common.Authentication;

namespace ComeSocial.Application.Authentication.Common;

public record AuthenticationResult(
    ApplicationUser User,
    string Token);


using ComeSocial.Domain.Common.Authentication;
using ComeSocial.Domain.User;

namespace ComeSocial.Application.Authentication.Common;

public record AuthenticationResult(
    ApplicationUser User,
    string Token);
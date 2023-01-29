using ComeSocial.Domain.Common.Authentication;
using ComeSocial.Domain.User;

namespace ComeSocial.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(ApplicationUser user);
}
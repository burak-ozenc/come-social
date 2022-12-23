using ComeSocial.Domain.Entities;

namespace ComeSocial.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
using ComeSocial.Application.Authentication.Commands.Register;
using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Authentication.Queries.Login;
using ComeSocial.Application.Contracts.Authentication;
using Mapster;

namespace ComeSocial.Api.Common.Mapping.Configurations;

public class AuthenticationMappingConfig : IRegister 
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.Id, src => src.User.Id);
    }
}
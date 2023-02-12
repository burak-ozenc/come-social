using ComeSocial.Application.Authentication.Commands.Register;
using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Authentication.Queries.Login;
using ComeSocial.Application.Contracts.Authentication;
using ComeSocial.Domain.Common.Authentication;
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
            .Map(dest => dest.Id, src => src.User.Id)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.UserName, src => src.User.UserName)
            .Map(dest => dest.Email, src => src.User.Email);


    }
}
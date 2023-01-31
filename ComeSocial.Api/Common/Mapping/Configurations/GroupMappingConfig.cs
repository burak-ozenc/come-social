using ComeSocial.Application.Contracts.Group;
using ComeSocial.Application.Group.Commands.CreateGroupCommand;
using ComeSocial.Domain.Group;
using ComeSocial.Domain.Group.ValueObjects;
using Mapster;

namespace ComeSocial.Api.Common.Mapping.Configurations;

public class GroupMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateGroupRequest, CreateGroupCommand>()
            .Map(dest => dest.UserIds,
                src => src.Users.ConvertAll(u => u.Id));
        // .Map(dest => dest.SocialEventId,
        // src => src.SocialEventId);

        config.NewConfig<Group, CreateGroupResponse>()
            .Map(dest => dest.SocialEventId,
                src => src.SocialEventId.Value)
            .Map(dest => dest.Users,
                src => src.Users.Select(u => u.Value));

        config.NewConfig<GroupId, GroupUsersResponse>()
            .Map(dest => dest.Id, src => src.Value);
        
        


    }
}
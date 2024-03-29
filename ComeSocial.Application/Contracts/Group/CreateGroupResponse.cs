﻿namespace ComeSocial.Application.Contracts.Group;

public record CreateGroupResponse(
    string Id,
    string Name,
    string GroupAvatar,
    string SocialEventId,
    DateTime SocialEventDate,
    List<GroupUsersResponse> Users);

public record GroupUsersResponse(string Id);
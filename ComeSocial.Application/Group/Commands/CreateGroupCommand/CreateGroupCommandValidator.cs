using FluentValidation;

namespace ComeSocial.Application.Group.Commands.CreateGroupCommand;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.UserIds).NotEmpty();
        RuleFor(x => x.SocialEventId).NotEmpty();
        RuleFor(x => x.SocialEventDate).NotEmpty();
    }
}
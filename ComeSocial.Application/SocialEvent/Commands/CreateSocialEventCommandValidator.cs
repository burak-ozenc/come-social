using FluentValidation;

namespace ComeSocial.Application.SocialEvent.Commands;

public class CreateSocialEventValidator :  AbstractValidator<CreateSocialEventCommand>
{
    public CreateSocialEventValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
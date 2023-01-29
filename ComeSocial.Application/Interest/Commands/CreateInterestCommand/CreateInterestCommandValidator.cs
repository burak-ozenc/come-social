using FluentValidation;

namespace ComeSocial.Application.Interest.Commands.CreateInterestCommand;

public class CreateInterestCommandValidator : AbstractValidator<CreateInterestCommand>
{
    public CreateInterestCommandValidator()
    {
        RuleFor(i => i.Name).NotEmpty();
        // RuleFor(i => i.TagIds).NotEmpty();
    }
}
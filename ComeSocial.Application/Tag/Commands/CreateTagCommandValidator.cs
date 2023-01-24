using FluentValidation;

namespace ComeSocial.Application.Tag.Commands;

public class CreateTagCommandValidator : AbstractValidator<Domain.Tag.Tag>
{
    public CreateTagCommandValidator()
    {
        RuleFor(t => t.Name).NotEmpty();
    }
}
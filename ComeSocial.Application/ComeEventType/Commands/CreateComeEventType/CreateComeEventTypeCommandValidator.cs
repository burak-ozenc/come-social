using FluentValidation;

namespace ComeSocial.Application.ComeEventType.Commands.CreateComeEventType;

public class CreateComeEventTypeCommandValidator : AbstractValidator<CreateComeEventTypeCommand>
{
    public CreateComeEventTypeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }    
}
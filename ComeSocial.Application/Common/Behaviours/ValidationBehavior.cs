using ComeSocial.Application.Authentication.Commands.Register;
using ComeSocial.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
 
namespace ComeSocial.Application.Common.Behaviours;

// public class ValidationBehaviours()
// {
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;
    
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }
    
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult is null)
            return await next();

        var errors =
            validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
                .ToList();
        // after handler
        return (dynamic)errors;
        // return await _pipelineBehaviorImplementation.Handle(request, next, cancellationToken);
    }
}
// }
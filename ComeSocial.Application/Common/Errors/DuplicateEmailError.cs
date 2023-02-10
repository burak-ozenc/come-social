using FluentResults;

namespace ComeSocial.Application.Common.Errors;

public record struct DuplicateEmailError : IError
{
    public string Message => "Email is already in use.";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();

    public List<IError> Reasons => throw new NotImplementedException();
}
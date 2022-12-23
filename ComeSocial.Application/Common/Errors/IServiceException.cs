using System.Net;

namespace ComeSocial.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exists.";
}
using ErrorOr;

namespace ComeSocial.Domain.Common.Errors;

public static class ErrorsAuthentication
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Validation(code: "Auth.InvalidCredentials", description: " Invalid credentials.");
    }
}
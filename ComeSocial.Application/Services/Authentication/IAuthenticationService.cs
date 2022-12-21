namespace ComeSocial.Application.Authentication;

public interface IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password);
    public AuthenticationResult Login(string email, string password);
}
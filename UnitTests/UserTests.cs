using ComeSocial.Application.Authentication.Commands.Register;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Common.Authentication;
using Moq;
using Shouldly;

namespace UnitTests;

public class UserTests
{
    // this repositories cannot be injected
    // thus they needed to be eagerly created
    private readonly Mock<IUserRepository> _mockUserRepository = new ();
    private readonly Mock<IUserService> _mockUserService = new ();
    private readonly Mock<IJwtTokenGenerator> _mockJwtTokenGenerator = new ();
    
    
    // TODO
    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenEmailIsNotUnique()
    {
        // arrange

        _mockUserService.Setup(service =>
            service.GetUserByEmail(It.IsAny<string>())).Returns((ApplicationUser)null);

        _mockUserRepository.Setup(service =>
            service.GetUserByEmail(It.IsAny<string>())).Returns((ApplicationUser)null);

        _mockJwtTokenGenerator.Setup(tokenGen =>
            tokenGen.GenerateToken(It.IsAny<ApplicationUser>())).Returns(It.IsAny<string>());

        var command = new RegisterCommand("test", "test", "test", "test@mail.test", "test");

        var handler = new RegisterCommandHandler(
            _mockJwtTokenGenerator.Object,
            _mockUserService.Object,
            _mockUserRepository.Object);

        // act
        var result = await handler.Handle(command, new CancellationToken());
        
        // // assert
        result.ShouldBe(null);
    }
}
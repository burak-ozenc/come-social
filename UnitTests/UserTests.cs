using ComeSocial.Application.Authentication.Commands.Register;
using ComeSocial.Application.Authentication.Queries.Login;
using ComeSocial.Application.Common.Errors;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Common.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace UnitTests;

public class UserTests
{
    // this repositories cannot be injected
    // thus they needed to be eagerly created
    private readonly Mock<IUserService> _mockUserService = new();
    private readonly Mock<IJwtTokenGenerator> _mockJwtTokenGenerator = new();
    private readonly Mock<IUserRepository> _mockUserRepository = new();


    // TODO
    [Fact]
    public async Task Handle_Register_Should_ReturnSuccess()
    {
        // arrange

        _mockUserService.Setup(service =>
            service.IsEmailUnique(It.IsAny<string>())).ReturnsAsync(true);

        _mockUserService.Setup(service =>
            service.CreateUser(It.IsAny<ApplicationUser>())).ReturnsAsync(It.IsAny<ApplicationUser>());

        _mockJwtTokenGenerator.Setup(tokenGen =>
            tokenGen.GenerateToken(It.IsAny<ApplicationUser>())).Returns(It.IsAny<string>());

        var command = new RegisterCommand(
            "test",
            "test",
            "test",
            "test@mail.test",
            "test");

        var handler = new RegisterCommandHandler(
            _mockJwtTokenGenerator.Object,
            _mockUserService.Object);

        // act
        var result = await handler.Handle(command, new CancellationToken());

        // assert
        result.Value.User.ShouldBeOfType<ApplicationUser>();
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenEmailIsNotUnique()
    {
        // arrange

        _mockUserService.Setup(service =>
            service.IsEmailUnique(It.IsAny<string>())).ReturnsAsync(false);

        _mockJwtTokenGenerator.Setup(tokenGen =>
            tokenGen.GenerateToken(It.IsAny<ApplicationUser>())).Returns(It.IsAny<string>());

        var command = new RegisterCommand(
            "test",
            "test",
            "test",
            "test@mail.test",
            "test");

        var handler = new RegisterCommandHandler(
            _mockJwtTokenGenerator.Object,
            _mockUserService.Object);

        // act
        var result = await handler.Handle(command, new CancellationToken());

        // assert
        var res = result.Errors;
        res.ShouldNotBeEmpty();
    }

    // TODO
    [Fact]
    public async Task Handle_Login_Should_ReturnSuccess()
    {
        // arrange
        _mockUserService 
            .Setup(service => service.GetUserByEmail(It.IsAny<string>()))
            .Returns(It.IsAny<ApplicationUser>());

        _mockUserService
            .Setup(service => service.CheckPasswordAsync( It.IsAny<ApplicationUser>(),It.IsAny<string>()))
            .ReturnsAsync(It.IsAny<bool>());

        var command = new LoginQuery("test@t.t", "test");
        _mockJwtTokenGenerator.Setup(tokenGen =>
        tokenGen.GenerateToken(It.IsAny<ApplicationUser>())).Returns(It.IsAny<string>());

        

        var handler = new LoginQueryHandler(_mockJwtTokenGenerator.Object, _mockUserService.Object);

        // act

        var result = await handler.Handle(command, new CancellationToken());


        // assert
        result.User.ShouldBeOfType<ApplicationUser>();
        result.Token.ShouldBeOfType<string>();
    }
}
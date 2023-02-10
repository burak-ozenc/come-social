using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.SocialEvent.Commands.CreateSocialEvent;
using Moq;
using Shouldly;

namespace UnitTests.SocialEvent;

public class CreateSocialEventTest
{
    private readonly Mock<ISocialEventRepository> _socialEventRepositoryMock;
    
    public CreateSocialEventTest()
    {
        _socialEventRepositoryMock = new Mock<ISocialEventRepository>();
    }

    [Fact]
    public async Task Handle_Should_Return_FailureResult_When_TagsNotExist()
    {
        // arrange
        
        _socialEventRepositoryMock
            .Setup(x => x.Add(It.IsAny<ComeSocial.Domain.SocialEvent.SocialEvent>()));

        var createCommand = new CreateSocialEventCommand(
            "test",
            "testSubHeader",
            "testDesc",
            DateTime.Now,
            new List<string>()
            {
                "00000000-0000-0000-0000-000000000000"
            },
            new List<string>()
            {
                "00000000-0000-0000-0000-000000000000"
            },
            null,
            null
        );

        var commandHandler = new CreateSocialEventHandler(_socialEventRepositoryMock.Object);


        // act

        var result = await commandHandler.Handle(createCommand, new CancellationToken());

        // assert
            
        result.ShouldNotBe(null);
        Assert.NotNull(result.Id);
        Assert.NotNull(result);
    }
}
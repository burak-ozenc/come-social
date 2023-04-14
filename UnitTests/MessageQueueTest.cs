namespace UnitTests;

public class MessageQueueTest
{
    
    [Fact]
    public async Task sendMessage_should_send_the_user_and_message_to_all_clients()
    {
        // // Arrange
        // _factory.CreateClient(); // need to create a client for the server property to be available
        // var server = _factory.Server;
	       //
        // var connection = await StartConnectionAsync(server.CreateHandler(), "chat");
        //
        // connection.Closed += async error =>
        // {
        //     await Task.Delay(new Random().Next(0, 5) * 1000);
        //     await connection.StartAsync();
        // };
        //
        // // Act
        // string user = null;
        // string message = null;
        // connection.On<string,string>("OnReceiveMessage", (u, m) =>
        // {
        //     user = u;
        //     message = m;
        // });
        // await connection.InvokeAsync("SendMessage", "super_user", "Hello World!!");
        //
        // //Assert
        // user.Should().Be("super_user");
        // message.Should().Be("Hello World!!");
    }
}
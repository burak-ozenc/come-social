// using ComeSocial.Application.ChatMessage.Commands.SendMessage;
// using ComeSocial.Application.Contracts.Message;
// using MediatR;
// using Microsoft.AspNetCore.SignalR;
//
// namespace ComeSocial.Infrastructure.Services.Hubs;
//
// public class MessageHub : Hub
// {
//     
//     // TODO
//     // after upgrading to gRPC
//     // this method will receive parameters as an object
//     // reason : now, unable to test as an object from Postman
//     public async Task SendMessage(string from, string to, string message, string sentOn)
//     {
//         await Clients.All.SendAsync("ReceiveMessage", new
//         {
//             from,
//             to,
//             message,
//             createdOn = DateTime.Parse(sentOn)
//         });
//     }
//
//     public void SendMQMessage(string from, string to, string message, string sentOn)
//     {
//         Clients.All.SendAsync("ReceiveMQMessage", new
//         {
//             from,
//             to,
//             message,
//             createdOn = DateTime.Parse(sentOn)
//         });
//     }
//     
// }
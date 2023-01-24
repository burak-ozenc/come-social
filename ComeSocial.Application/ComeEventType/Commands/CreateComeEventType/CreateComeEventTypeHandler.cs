using ComeSocial.Application.Common.Interfaces.Persistence;
using MediatR;

namespace ComeSocial.Application.ComeEventType.Commands.CreateComeEventType;

public class CreateComeEventTypeHandler : IRequestHandler<CreateComeEventTypeCommand, Domain.ComeEventType.ComeEventType>
{
    private readonly IComeEventTypeRepository _comeEventTypeRepository;

    public CreateComeEventTypeHandler(IComeEventTypeRepository comeEventTypeRepository)
    {
        _comeEventTypeRepository = comeEventTypeRepository;
    }
    public async Task<Domain.ComeEventType.ComeEventType> Handle(
        CreateComeEventTypeCommand request, 
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var socialEventType = Domain.ComeEventType.ComeEventType.CreateComeEventType(
            name: request.Name,
            createdDateTime: request.CreatedDateTime,
            updatedDateTime: request.UpdatedDateTime
        );
        
        _comeEventTypeRepository.Add(socialEventType);

        return socialEventType;
    }
}
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Tag.ValueObjects;
using MediatR;

namespace ComeSocial.Application.Interest.Commands.CreateInterestCommand;

public class CreateInterestCommandHandler : IRequestHandler<CreateInterestCommand, Domain.Interest.Interest>
{
    private readonly IInterestRepository _interestRepository;

    public CreateInterestCommandHandler(IInterestRepository interestRepository)
    {
        _interestRepository = interestRepository;
    }

    public async Task<Domain.Interest.Interest> Handle(CreateInterestCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var interest = Domain.Interest.Interest.CreateInterest(
            name: request.Name,
            tags: request.TagIds.ConvertAll(t => TagId.Create(Guid.Parse(t))),
            createdDateTime: request.CreatedDateTime,
            updatedDateTime: request.UpdatedDateTime
        );
        
        _interestRepository.Add(interest);

        return interest;
    }
}
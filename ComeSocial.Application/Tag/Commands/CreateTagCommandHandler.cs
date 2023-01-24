using ComeSocial.Application.Common.Interfaces.Persistence;
using MediatR;

namespace ComeSocial.Application.Tag.Commands;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Domain.Tag.Tag>
{
    private readonly ITagRepository _tagRepository;

    public CreateTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    
    public async Task<Domain.Tag.Tag> Handle(
        CreateTagCommand request, 
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var tag = Domain.Tag.Tag.CreateTag(
            name: request.Name,
            createdDateTime: request.CreatedDateTime,
            updatedDateTime: request.UpdatedDateTime
        );
        
        _tagRepository.Add(tag);

        return tag;
    }
}
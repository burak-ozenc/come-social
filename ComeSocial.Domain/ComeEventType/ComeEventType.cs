using ComeSocial.Domain.ComeEventType.ValueObjects;
using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.ComeEventType;

public sealed class ComeEventType : AggregateRoot<ComeEventTypeId>
{
    public string Name { get; private set; }
    public DateTime? CreatedDateTime { get; private set; }
    public DateTime? UpdatedDateTime { get; private set; }

    private ComeEventType(
        ComeEventTypeId id,
        string name,
        DateTime? createdDateTime,
        DateTime? updatedDateTime
    ) : base(id)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static ComeEventType Create(
        string name,
        DateTime? createdDateTime,
        DateTime? updatedDateTime)
        => new(ComeEventTypeId.CreateUnique(),
            name,
            createdDateTime,
            updatedDateTime);
    
    private ComeEventType() {}
}
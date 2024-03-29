﻿using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.Interest.ValueObjects;

public sealed class InterestId : ValueObject
{
    public Guid Value { get; set; }

    private InterestId(Guid value)
    {
        Value = value;
    }
    
    public static InterestId CreateUnique() => new(Guid.NewGuid());

    public static InterestId Create(Guid value) => new InterestId(value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private InterestId(){}
}
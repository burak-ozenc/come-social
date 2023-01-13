﻿namespace ComeSocial.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();
    
    public override bool Equals(object? obj)
    {
        if(obj is null || obj.GetType() != GetType())
            return false;
        var valueObject = (ValueObject)obj;

        return GetEqualityComponents()
            .SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(c => c?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    }
    
    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }
}

public class Tag : ValueObject
{
    public string Name { get; private set; }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}


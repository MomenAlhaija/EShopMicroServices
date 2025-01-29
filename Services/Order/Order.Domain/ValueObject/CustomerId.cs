﻿namespace Order.Domain.ValueObject;

public record CustomerId
{
    public Guid Value { get;}

    private CustomerId(Guid value) => Value = value;
    
    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("Customer Id Can't Be Empty");
        }
       return new CustomerId(value);
    }
}

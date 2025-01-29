namespace Order.Domain.ValueObject;

public record OrderItemId
{
    public Guid Value { get; }
    
    private OrderItemId(Guid value)=>Value = value;

    public static OrderItemId Of(Guid value)
    {
        if (value == Guid.Empty)
            throw new DomainException("OrderItemId Can't be Empty");

        return new OrderItemId(value);  
    }
}
